using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE_TOOL.Models
{
    internal class GetDataByRegexModel
    {
        public string PrefixRegex { get; set; }
        public string ValueRegex { get; set; }
        public string PathLog { get; set; }
        public string SaveLocation { get; set; }
    }
}
