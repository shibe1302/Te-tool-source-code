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
                MessageBox.Show("Vui lòng kiểm tra lại đường dẫn lưu file hoặc đường dẫn log!", "Lỗi đường dẫn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string scriptPath = PATH_FILE_CONSTANT.SCRIPT_PATH_GET_DATA_BY_REGEX;
            if (!File.Exists(scriptPath))
            {
                MessageBox.Show("Script không tồn tại!", "Lỗi file script", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",

                Arguments = $"-NoExit -ExecutionPolicy Bypass -File \"{scriptPath}\" \"{model.PrefixRegex}\" \"{model.ValueRegex}\" \"{model.PathLog}\" \"{model.SaveLocation}\"",

                UseShellExecute = true,

                CreateNoWindow = false,

                WorkingDirectory = PATH_FILE_CONSTANT._scripRegexFolder
            };
            Process.Start(startInfo);

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
