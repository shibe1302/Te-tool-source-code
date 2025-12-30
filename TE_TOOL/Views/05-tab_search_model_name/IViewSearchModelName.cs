using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.Models;

namespace TE_TOOL.Views._05_tab_search_model_name
{
    public interface IViewSearchModelName
    {
        event EventHandler SearchModelKeyPressed;
        event EventHandler btnAddClicked;
        event Action<string> AddProductRequested;
        event EventHandler SearchTextChanged;
        public void DisplayProducts(List<ProductNameModel> products);
    }
}
