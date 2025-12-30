using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.Models;

namespace TE_TOOL.Services
{
    internal interface IGetAllTypeDataInLogService
    {
        void runScript(GetDataByRegexModel model);
    }
}
