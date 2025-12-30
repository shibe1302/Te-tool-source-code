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
        public static readonly string SCRIPT_LOG_COLLECTION;
        public static readonly string SCRIPT_LOG_COLLECTION_LOCAL;
        public static readonly string PATH_PRODUCT_NAME_JSON;


         static PATH_FILE_CONSTANT()
        {
            // path loc log script
            _appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _scriptFolder = Path.Combine(_appDirectory, "PS1File");
            SCRIPT_PATH_LOC_LOG = Path.Combine(_scriptFolder, "01-loc-log.ps1");
            SCRIPT_PATH_LOC_LOG_OLD_FORMAT = Path.Combine(_scriptFolder, "01-loc-log-old-format.ps1");
            SCRIPT_PATH_GET_DATA_BY_REGEX = Path.Combine(_scriptFolder, "03-get-data-by-regex.ps1");
            SCRIPT_LOG_COLLECTION = Path.Combine(_scriptFolder, "02-thu-thap-log.ps1");
            SCRIPT_LOG_COLLECTION_LOCAL = Path.Combine(_scriptFolder, "02-thu-thap-log-local.ps1");

            // FILE JSON PRODUCT NAME
            PATH_PRODUCT_NAME_JSON= Path.Combine(_appDirectory, "Resources", "products_data.json");
        }
    }
}
