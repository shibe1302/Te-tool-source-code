using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.Models;

namespace TE_TOOL.Services
{
    public interface ISearchingService
    {
        public List<ProductNameModel> ReadFromFile();
        public void LoadFromCsvOrTxt(string inputFilePath);
        public List<ProductNameModel> FindByModel(string modelKeyword);
        public List<ProductNameModel> FindByProductName(string productNameKeyword);
    }
}
