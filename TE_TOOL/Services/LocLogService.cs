using System;
using System.Diagnostics;
using System.IO;
using TE_TOOL.CONFIG;

namespace TE_TOOL.Services
{
    public class LocLogService
    {

        public bool ValidateFilePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            return File.Exists(path) || Directory.Exists(path);
        }

        public bool CheckScriptExists()
        {
            string scriptPath = GetScriptPath();
            return File.Exists(scriptPath);
        }


        public Process RunFilterScript(string filePath, string fileMac)
        {
            if (!ValidateFilePath(filePath) && !ValidateFilePath(fileMac))
            {
                throw new ArgumentException(
                    "Đường dẫn file không hợp lệ",
                    nameof(filePath)
                );
            }

            string scriptPath = GetScriptPath();
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(
                    $"Không tìm thấy script tại: {scriptPath}"
                );
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",

                Arguments = $"-NoExit -ExecutionPolicy Bypass -File \"{scriptPath}\" \"{filePath}\" \"{fileMac}\"",

                UseShellExecute = true,

                CreateNoWindow = false,

                WorkingDirectory = PATH_FILE_CONSTANT._scriptFolder
            };

            return Process.Start(startInfo);
        }
        public Process RunFilterScriptOldFormat(string filePath, string fileMac)
        {
            if (!ValidateFilePath(filePath) && !ValidateFilePath(fileMac))
            {
                throw new ArgumentException(
                    "Đường dẫn file không hợp lệ",
                    nameof(filePath)
                );
            }

            string scriptPath = GetScriptPathOldFormat();
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(
                    $"Không tìm thấy script tại: {scriptPath}"
                );
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",

                Arguments = $"-NoExit -ExecutionPolicy Bypass -File \"{scriptPath}\" \"{filePath}\" \"{fileMac}\"",

                UseShellExecute = true,

                CreateNoWindow = false,

                WorkingDirectory = PATH_FILE_CONSTANT._scriptFolder
            };

            return Process.Start(startInfo);
        }
        public string GetScriptPath()
        {
            return PATH_FILE_CONSTANT.SCRIPT_PATH_LOC_LOG;
        }
        public string GetScriptPathOldFormat()
        {
            return PATH_FILE_CONSTANT.SCRIPT_PATH_LOC_LOG_OLD_FORMAT;
        }


        public string GetDisplayName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            try
            {
                if (File.Exists(path))
                    return Path.GetFileName(path);

                if (Directory.Exists(path))
                    return new DirectoryInfo(path).Name;

                return path;
            }
            catch
            {
                return path;
            }
        }

        public bool IsZipFile(string path)
        {
            return !string.IsNullOrEmpty(path) &&
                   path.EndsWith(".zip", StringComparison.OrdinalIgnoreCase);
        }

        public bool IsLogFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            string extension = Path.GetExtension(path).ToLower();
            return extension == ".log" || extension == ".txt";
        }
    }
}