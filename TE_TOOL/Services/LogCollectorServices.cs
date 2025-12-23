
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using TE_TOOL.CONFIG;
using TE_TOOL.Models;

namespace TE_TOOL.Services
{

    public class LogCollectorService
    {

        public ValidationResult ValidateFormData(LogCollectorFormData data)
        {
            if (!data.IsLocalScanMode)
            {

                if (data.PortNumber < 1 || data.PortNumber > 65535)
                    return ValidationResult.Fail("Port number phải nằm trong khoảng 1–65535!");

                if (data.MaxThreadScan < 1 || data.MaxThreadScan > 1000)
                    return ValidationResult.Fail("Max thread scan phải nằm trong khoảng 1–1000!");

                if (string.IsNullOrWhiteSpace(data.Host))
                    return ValidationResult.Fail("Host không được để trống!");

                if (string.IsNullOrWhiteSpace(data.User))
                    return ValidationResult.Fail("User không được để trống!");

                if (string.IsNullOrWhiteSpace(data.Protocol))
                    return ValidationResult.Fail("Vui lòng chọn Protocol!");

                if (string.IsNullOrWhiteSpace(data.WinscpDLLPath))
                    return ValidationResult.Fail("Chưa chọn WinscpDLL file!");
            }


            if (string.IsNullOrWhiteSpace(data.LocalDownloadDestination))
                return ValidationResult.Fail("Chưa chọn thư mục download!");

            if (data.RemoteFolderPaths == null || data.RemoteFolderPaths.Count == 0)
                return ValidationResult.Fail("Chưa có đường dẫn nguồn scan!");

            if (string.IsNullOrWhiteSpace(data.MacFilePath))
                return ValidationResult.Fail("Chưa chọn Mac file!");

            return ValidationResult.Success();
        }

        public void SaveConfiguration(string filePath, LogCollectorFormData data)
        {
            var config = new LogCollectorConfig
            {
                Host = data.Host,
                User = data.User,
                Password = data.Password,
                Protocol = data.Protocol,
                PortNumber = data.PortNumber.ToString(),
                LocalDownloadDestination = data.LocalDownloadDestination,
                WinscpDLL = data.WinscpDLLPath,
                RemoteFolderScan = data.RemoteFolderPaths,
                MaxThreadScan = data.MaxThreadScan.ToString(),
                MacFilePath = data.MacFilePath,
                ScanLocalMode = data.IsLocalScanMode
            };

            var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }


        public LogCollectorFormData LoadConfiguration(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new LogCollectorFormData
                {
                    RemoteFolderPaths = new List<string>()
                };
            }

            var json = File.ReadAllText(filePath);
            var config = JsonSerializer.Deserialize<LogCollectorConfig>(json);

            if (config == null)
            {
                return new LogCollectorFormData
                {
                    RemoteFolderPaths = new List<string>()
                };
            }

            return new LogCollectorFormData
            {
                Host = config.Host ?? "",
                User = config.User ?? "",
                Password = config.Password ?? "",
                Protocol = config.Protocol ?? "",
                PortNumber = int.TryParse(config.PortNumber, out int port) ? port : 22,
                LocalDownloadDestination = config.LocalDownloadDestination ?? "",
                WinscpDLLPath = config.WinscpDLL ?? "",
                RemoteFolderPaths = config.RemoteFolderScan?
                    .Select(p => p.TrimEnd('\\'))
                    .ToList() ?? new List<string>(),
                MaxThreadScan = int.TryParse(config.MaxThreadScan, out int maxThread) ? maxThread : 1,
                MacFilePath = config.MacFilePath ?? "",
                IsLocalScanMode = config.ScanLocalMode
            };
        }


        public void ExecuteScanProcess(LogCollectorFormData data, string scriptBasePath)
        {
            foreach (var sourcePath in data.RemoteFolderPaths)
            {
                if (data.IsLocalScanMode)
                {
                    ExecuteLocalScan(sourcePath, data, scriptBasePath);
                }
                else
                {
                    ExecuteRemoteScan(sourcePath, data, scriptBasePath);
                }
            }
        }

        private void ExecuteLocalScan(string sourcePath, LogCollectorFormData data, string scriptBasePath)
        {
            string scriptPath = PATH_FILE_CONSTANT.SCRIPT_LOG_COLLECTION_LOCAL;

            if (!File.Exists(scriptPath))
                throw new FileNotFoundException("Không tìm thấy script scan-local.ps1!");

            string arguments = $"-NoExit -ExecutionPolicy Bypass -File \"{scriptPath}\" " +
                             $"-SourceFolder \"{sourcePath}\" " +
                             $"-DestinationFolder \"{data.LocalDownloadDestination}\" " +
                             $"-MacFilePath \"{data.MacFilePath}\" " +
                             $"-MaxScanThreads {data.MaxThreadScan}";

            StartPowerShellProcess(arguments, Path.Combine(scriptBasePath, "log_collection_ps1"));
        }

        private void ExecuteRemoteScan(string sourcePath, LogCollectorFormData data, string scriptBasePath)
        {
            string scriptPath = PATH_FILE_CONSTANT.SCRIPT_LOG_COLLECTION;

            if (!File.Exists(scriptPath))
                throw new FileNotFoundException($"Không tìm thấy hash-set.ps1 tại:\n{scriptPath}");

            string arguments = $"-NoExit -ExecutionPolicy Bypass -File \"{scriptPath}\" " +
                             $"-ScpHost \"{data.Host}\" " +
                             $"-Port \"{data.PortNumber}\" " +
                             $"-ScpUser \"{data.User}\" " +
                             $"-ScpPassword \"{data.Password}\" " +
                             $"-Protocol \"{data.Protocol}\" " +
                             $"-RemoteFolder \"{sourcePath}\" " +
                             $"-LocalDestination \"{data.LocalDownloadDestination}\" " +
                             $"-winscpDllPath \"{data.WinscpDLLPath}\" " +
                             $"-MacFilePath \"{data.MacFilePath}\" " +
                             $"-MaxScanThreads {data.MaxThreadScan}";

            StartPowerShellProcess(arguments, Path.Combine(scriptBasePath, "log_collection_ps1"));
        }
        private void StartPowerShellProcess(string arguments, string workingDir)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = arguments,
                UseShellExecute = true,
                CreateNoWindow = false,
                WorkingDirectory = workingDir
            };

            Process.Start(psi);
        }
    }
}