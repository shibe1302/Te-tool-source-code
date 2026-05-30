using System.Text.Json;
using System.Text.Json.Serialization;

namespace TE_TOOL.Infrastructure
{
    /// <summary>
    /// Cấu hình kết nối SFTP server.
    /// Tự động đọc từ sftp_config.json khi khởi động.
    /// Nếu file không tồn tại, tạo mới với giá trị mặc định.
    /// </summary>
    public class SftpSyncConfig
    {
        // ── Các trường config ─────────────────────────────────────────────
        public string Host { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 22;
        public string Username { get; set; } = "lam";
        public string Password { get; set; } = "shibe1302!";

        // Đường dẫn tuyệt đối trên server Linux/Windows-SFTP
        public string RemoteDbPath { get; set; } = "/qa_sync/qa_notebook.db";
        public string RemoteMetaPath { get; set; } = "/qa_sync/meta.json";

        // ── JSON options ──────────────────────────────────────────────────
        [JsonIgnore]
        private static readonly JsonSerializerOptions _jsonOpts = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        // ── Đường dẫn file config mặc định (cùng thư mục exe) ─────────────
        [JsonIgnore]
        public static string DefaultConfigPath =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sftp_config.json");

        // ── Load: đọc từ file, nếu chưa có thì tạo mới ───────────────────
        /// <summary>
        /// Load config từ file JSON.
        /// - Nếu file chưa tồn tại → tạo file với giá trị default rồi trả về.
        /// - Nếu file lỗi / không parse được → trả về default, KHÔNG crash.
        /// </summary>
        public static SftpSyncConfig Load(string? configPath = null)
        {
            configPath ??= DefaultConfigPath;

            if (!File.Exists(configPath))
            {
                var defaultCfg = new SftpSyncConfig();
                defaultCfg.Save(configPath); // tạo file mẫu
                return defaultCfg;
            }

            try
            {
                string json = File.ReadAllText(configPath);
                return JsonSerializer.Deserialize<SftpSyncConfig>(json, _jsonOpts)
                       ?? new SftpSyncConfig();
            }
            catch
            {
                // File bị corrupt hoặc sai format → dùng default, không crash app
                return new SftpSyncConfig();
            }
        }

        // ── Save: ghi ra file JSON ─────────────────────────────────────────
        /// <summary>
        /// Lưu config hiện tại ra file JSON.
        /// Ghi vào .tmp trước rồi atomic-swap để tránh mất file khi ghi dở.
        /// </summary>
        public void Save(string? configPath = null)
        {
            configPath ??= DefaultConfigPath;

            string tmpPath = configPath + ".tmp";
            string json = JsonSerializer.Serialize(this, _jsonOpts);

            File.WriteAllText(tmpPath, json);

            if (File.Exists(configPath)) File.Delete(configPath);
            File.Move(tmpPath, configPath);
        }
    }
}