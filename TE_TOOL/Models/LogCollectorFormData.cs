using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE_TOOL.Models
{
    public class LogCollectorFormData
    {
        public string Host { get; set; } = "";
        public string User { get; set; } = "";
        public string Password { get; set; } = "";
        public string Protocol { get; set; } = "";
        public int PortNumber { get; set; } = 22;
        public string LocalDownloadDestination { get; set; } = "";
        public string WinscpDLLPath { get; set; } = "";
        public List<string> RemoteFolderPaths { get; set; } = new List<string>();
        public int MaxThreadScan { get; set; } = 1;
        public string MacFilePath { get; set; } = "";
        public bool IsLocalScanMode { get; set; } = false;
    }
}
