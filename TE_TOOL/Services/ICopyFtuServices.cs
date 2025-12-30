using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TE_TOOL.Services
{
    public interface ICopyFtuServices
    {
        List<string> GetFunctionTest(string content);
        string TxtListFunctionTest { get; set; }
        List<string> ListItemTest { get; set; }
        JsonElement LoadJsonOrderItems(string pathFile, string items);
        JsonElement ReorderJsonItem(string itemsFromLog);
        void SaveFullJsonWithUpdatedItems(string pathFile);
        void RunFtu(string pathFTU);
    }
}
