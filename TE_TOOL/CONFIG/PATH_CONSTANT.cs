using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TE_TOOL.CONFIG
{
    public static class PATH_FILE_CONSTANT
    {
        private static readonly string _appDirectory;
        public static readonly string _scriptFolder;
        public static readonly string _scripRegexFolder;
        public static readonly string SCRIPT_PATH_LOC_LOG;
        public static readonly string SCRIPT_PATH_LOC_LOG_OLD_FORMAT;
        public static readonly string SCRIPT_PATH_GET_DATA_BY_REGEX;


        static PATH_FILE_CONSTANT()
        {
            // path loc log script
            _appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _scriptFolder = Path.Combine(_appDirectory, "loc-log-ps1");
            SCRIPT_PATH_LOC_LOG = Path.Combine(_scriptFolder, "merge.ps1");
            SCRIPT_PATH_LOC_LOG_OLD_FORMAT = Path.Combine(_scriptFolder, "merge-old-format.ps1");


            // path get data by regex script
            _scripRegexFolder = Path.Combine(_appDirectory, "get-data-by-regex-ps1");
            SCRIPT_PATH_GET_DATA_BY_REGEX = Path.Combine(_scripRegexFolder, "get-data-by-regex.ps1");

            // Có thể thêm các đường dẫn tệp khác tại đây
        }
    }
}
