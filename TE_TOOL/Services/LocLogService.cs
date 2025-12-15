using System;
using System.Diagnostics;
using System.IO;
using TE_TOOL.CONFIG;

namespace TE_TOOL.Services
{
    /// <summary>
    /// Service (Model layer) trong mô hình MVP
    /// - Chứa business logic và data access
    /// - KHÔNG biết gì về UI (không reference View)
    /// - Có thể reuse cho nhiều View khác nhau
    /// - Trả về dữ liệu thuần túy, không có MessageBox hay UI logic
    /// 
    /// Đây là "Model" trong MVP, chịu trách nhiệm:
    /// - Validate data
    /// - Xử lý file/folder operations
    /// - Gọi external processes (PowerShell)
    /// - Business rules
    /// </summary>
    public class LocLogService
    {
        // ===========================================
        // VALIDATION METHODS
        // ===========================================

        /// <summary>
        /// Kiểm tra đường dẫn file/folder có hợp lệ không
        /// </summary>
        /// <param name="path">Đường dẫn cần kiểm tra</param>
        /// <returns>True nếu path hợp lệ và tồn tại</returns>
        public bool ValidateFilePath(string path)
        {
            // Kiểm tra null, empty, whitespace
            if (string.IsNullOrWhiteSpace(path))
                return false;

            // Kiểm tra tồn tại (file hoặc folder đều OK)
            return File.Exists(path) || Directory.Exists(path);
        }

        /// <summary>
        /// Kiểm tra PowerShell script có tồn tại không
        /// </summary>
        /// <returns>True nếu script tồn tại</returns>
        public bool CheckScriptExists()
        {
            string scriptPath = GetScriptPath();
            return File.Exists(scriptPath);
        }

        // ===========================================
        // BUSINESS LOGIC METHODS
        // ===========================================

        /// <summary>
        /// Chạy PowerShell script để filter log
        /// </summary>
        /// <param name="filePath">Đường dẫn log file/folder</param>
        /// <returns>Process object của PowerShell</returns>
        /// <exception cref="ArgumentException">Nếu path không hợp lệ</exception>
        /// <exception cref="FileNotFoundException">Nếu script không tồn tại</exception>
        public Process RunFilterScript(string filePath, string fileMac)
        {
            // Validate input
            if (!ValidateFilePath(filePath)&& !ValidateFilePath(fileMac))
            {
                throw new ArgumentException(
                    "Đường dẫn file không hợp lệ",
                    nameof(filePath)
                );
            }

            // Kiểm tra script
            string scriptPath = GetScriptPath();
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(
                    $"Không tìm thấy script tại: {scriptPath}"
                );
            }

            // Cấu hình ProcessStartInfo
            var startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",

                // -NoExit: Giữ cửa sổ PowerShell mở sau khi chạy xong
                // -ExecutionPolicy Bypass: Bỏ qua chính sách execution
                // -File: Chạy file script
                Arguments = $"-NoExit -ExecutionPolicy Bypass -File \"{scriptPath}\" \"{filePath}\" \"{fileMac}\"",

                // UseShellExecute = true: Mở cửa sổ PowerShell mới
                UseShellExecute = true,

                // CreateNoWindow = false: Hiển thị cửa sổ
                CreateNoWindow = false,

                // Set working directory
                WorkingDirectory = PATH_FILE_CONSTANT._scriptFolder
            };

            // Start process và return
            return Process.Start(startInfo);
        }

        // ===========================================
        // HELPER METHODS
        // ===========================================

        /// <summary>
        /// Lấy đường dẫn đầy đủ của PowerShell script
        /// </summary>
        /// <returns>Đường dẫn script</returns>
        public string GetScriptPath()
        {
            return PATH_FILE_CONSTANT.SCRIPT_PATH_LOC_LOG;
        }

        /// <summary>
        /// Lấy tên hiển thị từ đường dẫn
        /// - Nếu là file: trả về tên file
        /// - Nếu là folder: trả về tên folder
        /// - Nếu lỗi: trả về đường dẫn gốc
        /// </summary>
        /// <param name="path">Đường dẫn đầy đủ</param>
        /// <returns>Tên hiển thị</returns>
        public string GetDisplayName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            try
            {
                // Nếu là file
                if (File.Exists(path))
                    return Path.GetFileName(path);

                // Nếu là folder
                if (Directory.Exists(path))
                    return new DirectoryInfo(path).Name;

                // Không tồn tại, trả về path gốc
                return path;
            }
            catch
            {
                // Nếu có lỗi, trả về path gốc
                return path;
            }
        }

        /// <summary>
        /// Kiểm tra file có phải là ZIP không
        /// </summary>
        /// <param name="path">Đường dẫn file</param>
        /// <returns>True nếu là .zip file</returns>
        public bool IsZipFile(string path)
        {
            return !string.IsNullOrEmpty(path) &&
                   path.EndsWith(".zip", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Kiểm tra file có phải là log file không
        /// </summary>
        /// <param name="path">Đường dẫn file</param>
        /// <returns>True nếu có extension .log hoặc .txt</returns>
        public bool IsLogFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            string extension = Path.GetExtension(path).ToLower();
            return extension == ".log" || extension == ".txt";
        }
    }
}