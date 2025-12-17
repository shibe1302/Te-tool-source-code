using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE_TOOL.Services
{
    public interface ICopyFtuServices
    {
        List<string> GetFunctionTest(string content);
        string TxtListFunctionTest { get; set; }

}
}
