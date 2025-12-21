using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.CONFIG;
using TE_TOOL.Models;

namespace TE_TOOL.Services
{
    internal class GetAllTypeDataInLogService : IGetAllTypeDataInLogService
    {


        public void runScript(GetDataByRegexModel model)
        {
            if (!ValidateFilePath(model.SaveLocation) && !ValidateFilePath(model.PathLog))
            {
                throw new ArgumentException(
                    "Đường dẫn file không hợp lệ",
                    nameof(model.PathLog)
                );
            }

            string scriptPath = PATH_FILE_CONSTANT.SCRIPT_PATH_GET_DATA_BY_REGEX;
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(
                    $"Không tìm thấy script tại: {scriptPath}"
                );
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",

                Arguments = $"-NoExit -ExecutionPolicy Bypass -File \"{scriptPath}\" \"{model.PrefixRegex}\" \"{model.ValueRegex}\" \"{model.PathLog}\" \"{model.SaveLocation}\"",

                UseShellExecute = true,

                CreateNoWindow = false,

                WorkingDirectory = PATH_FILE_CONSTANT._scriptFolder
            };

            
        }

        public bool ValidateFilePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            return File.Exists(path) || Directory.Exists(path);
        }

        public bool CheckScriptExists()
        {
            string scriptPath = PATH_FILE_CONSTANT.SCRIPT_PATH_GET_DATA_BY_REGEX;
            return File.Exists(scriptPath);
        }
    }
}
