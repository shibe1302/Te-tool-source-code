using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.Models;

namespace TE_TOOL.Views._04_tab_get_cc_data
{

    internal interface IGetAllTypeDataInLog
    {
        public GetDataByRegexModel model { get; set; }
        public void AddDatatoModel();

        event EventHandler btnGetDataClicked;
    }
}
