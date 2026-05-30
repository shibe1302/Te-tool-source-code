using Renci.SshNet;
using System.Text.Json;
using System.Windows.Forms;
using TE_TOOL.Infrastructure;
using TE_TOOL.Models;

namespace TE_TOOL.Services
{
    public enum SyncCheckResult
    {
        ServerNewer,    // Server có file lớn hơn → cần download
        UpToDate,       // Cùng size → không cần làm gì
        ServerSmaller,  // Server nhỏ hơn local → nghi bị thay file rỗng, từ chối
        NoMetadata,     // Chưa có file meta trên server → chưa ai upload lần nào
        NetworkError    // Lỗi kết nối / timeout
    }


    public class SftpSyncService
    {
        private readonly SftpSyncConfig _config;
        private static readonly JsonSerializerOptions _jsonOpts = new() { WriteIndented = true };

        public SftpSyncService(SftpSyncConfig config) => _config = config;

        // ─── Factory helper ───────────────────────────────────────────────
        private SftpClient CreateClient() =>
            new(_config.Host, _config.Port, _config.Username, _config.Password);

        // ─── Lấy metadata từ server ───────────────────────────────────────
        public async Task<SyncMetadata?> GetServerMetadataAsync()
        {
            try
            {
                return await Task.Run(() =>
                {
                    using var client = CreateClient();

                    client.Connect();

                    if (!client.IsConnected)
                        throw new Exception("Không thể kết nối tới SFTP server.");

                    if (!client.Exists(_config.RemoteMetaPath))
                        return null;

                    using var ms = new MemoryStream();

                    client.DownloadFile(_config.RemoteMetaPath, ms);

                    ms.Position = 0;

                    return JsonSerializer.Deserialize<SyncMetadata>(ms);
                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Type: {ex.GetType().FullName}\nMessage: {ex.Message}", "DEBUG");
                throw CreateFriendlyException(ex);

            }
        }

        // ─── Convert exception thành message dễ hiểu ─────────────────────
        private Exception CreateFriendlyException(Exception ex)
        {
            // Unwrap AggregateException từ Task.Run
            if (ex is AggregateException agg)
                ex = agg.InnerException ?? ex;

            return ex switch
            {
                Renci.SshNet.Common.SshAuthenticationException =>
                    new Exception("Sai username hoặc password SFTP."),

                Renci.SshNet.Common.SshConnectionException =>
                    new Exception("Không thể kết nối tới SFTP server."),

                System.Net.Sockets.SocketException =>
                    new Exception("Hostname không tồn tại hoặc server không phản hồi."),

                TimeoutException =>
                    new Exception("Kết nối tới server bị timeout."),

                Renci.SshNet.Common.SftpPathNotFoundException =>
                    new Exception("Đường dẫn file/folder trên server không tồn tại."),

                Renci.SshNet.Common.SftpPermissionDeniedException =>
                    new Exception("Không có quyền truy cập file/folder trên server."),

                _ => new Exception($"Lỗi không xác định: {ex.GetType().Name} — {ex.Message}", ex)
            };
        }

        // ─── Kiểm tra server có bản mới hơn không ────────────────────────
        /// <summary>
        /// So sánh size server vs local.
        /// Safety rule: server phải >= local (data chỉ tăng không giảm).
        /// Nếu server nhỏ hơn → ai đó đã thay file xấu → từ chối.
        /// </summary>
        public async Task<SyncCheckResult> CheckForUpdateAsync(string localDbPath, int localRecordCount = -1)
        {
            try
            {
                var meta = await GetServerMetadataAsync();
                if (meta == null) return SyncCheckResult.NoMetadata;

                long localSize = File.Exists(localDbPath) ? new FileInfo(localDbPath).Length : 0;

                // SAFETY GATE 1: file size server nhỏ hơn local → từ chối
                if (meta.FileSizeBytes < localSize)
                    return SyncCheckResult.ServerSmaller;

                // SAFETY GATE 2: record count server ít hơn local → nghi file bị thay xấu
                if (localRecordCount >= 0 && meta.RecordCount < localRecordCount)
                    return SyncCheckResult.ServerSmaller;

                // An toàn rồi → kiểm tra có mới hơn không
                if (localRecordCount >= 0 && meta.RecordCount > localRecordCount)
                    return SyncCheckResult.ServerNewer;

                // Fallback timestamp: bắt trường hợp edit/update không đổi số lượng record
                DateTime localModified = File.Exists(localDbPath)
                    ? File.GetLastWriteTimeUtc(localDbPath)
                    : DateTime.MinValue;

                if (meta.LastModifiedUtc > localModified.AddSeconds(5))
                    return SyncCheckResult.ServerNewer;

                return SyncCheckResult.UpToDate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ─── Download DB từ server về local ──────────────────────────────
        /// <summary>
        /// Download vào file .tmp trước, sau đó atomic-swap để tránh corrupt
        /// nếu mất điện / mất mạng giữa chừng.
        /// </summary>
        public async Task DownloadDatabaseAsync(string localDbPath, IProgress<int>? progress = null)
        {
            string tmpPath = localDbPath + ".tmp";

            try
            {
                await Task.Run(() =>
                {
                    using var client = CreateClient();

                    client.Connect();

                    if (!client.IsConnected)
                        throw new Exception("Kết nối SFTP thất bại.");

                    var remoteFile = client.Get(_config.RemoteDbPath);

                    long totalBytes = remoteFile.Length;

                    using var fs = new FileStream(
                        tmpPath,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None);

                    client.DownloadFile(_config.RemoteDbPath, fs, bytesDownloaded =>
                    {
                        if (totalBytes > 0)
                            progress?.Report((int)((long)bytesDownloaded * 100 / totalBytes));
                    });
                });

                if (File.Exists(localDbPath))
                    File.Delete(localDbPath);

                File.Move(tmpPath, localDbPath);

                progress?.Report(100);
            }
            catch (Exception ex)
            {
                if (File.Exists(tmpPath))
                    File.Delete(tmpPath);

                throw CreateFriendlyException(ex);
            }
        }

        // ─── Upload DB lên server ─────────────────────────────────────────
        /// <summary>
        /// Upload .db lên server, rồi cập nhật meta.json.
        /// Ghi đè file cũ trên server.
        /// </summary>
        public async Task UploadDatabaseAsync(
            string localDbPath,
            string uploaderMachine = "",
            int recordCount = 0,
            IProgress<int>? progress = null)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (!File.Exists(localDbPath))
                        throw new FileNotFoundException("Không tìm thấy file database local.");

                    var fileInfo = new FileInfo(localDbPath);

                    long totalBytes = fileInfo.Length;

                    using var client = CreateClient();

                    client.Connect();

                    if (!client.IsConnected)
                        throw new Exception("Kết nối SFTP thất bại.");

                    EnsureRemoteDirectory(client, _config.RemoteDbPath);

                    using (var fs = new FileStream(
                        localDbPath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.ReadWrite))
                    {
                        client.UploadFile(fs, _config.RemoteDbPath, bytesUploaded =>
                        {
                            if (totalBytes > 0)
                                progress?.Report((int)((long)bytesUploaded * 100 / totalBytes));
                        });
                    }

                    var meta = new SyncMetadata
                    {
                        FileSizeBytes = totalBytes,
                        LastModifiedUtc = DateTime.UtcNow,
                        Uploader = uploaderMachine,
                        RecordCount = recordCount
                    };

                    var json = JsonSerializer.Serialize(meta, _jsonOpts);

                    using var metaMs = new MemoryStream(
                        System.Text.Encoding.UTF8.GetBytes(json));

                    client.UploadFile(metaMs, _config.RemoteMetaPath);
                });

                progress?.Report(100);
            }
            catch (Exception ex)
            {
                throw CreateFriendlyException(ex);
            }
        }

        // ─── Helper: tạo thư mục nếu chưa có ─────────────────────────────
        private static void EnsureRemoteDirectory(SftpClient client, string remoteFilePath)
        {
            var dir = System.IO.Path.GetDirectoryName(remoteFilePath)
                          ?.Replace('\\', '/');
            if (string.IsNullOrEmpty(dir) || dir == "/") return;

            var parts = dir.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string current = "";
            foreach (var part in parts)
            {
                current += "/" + part;
                if (!client.Exists(current))
                    client.CreateDirectory(current);
            }
        }
    }
}