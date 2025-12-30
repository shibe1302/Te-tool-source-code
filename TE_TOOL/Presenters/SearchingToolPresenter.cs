using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.Services;
using TE_TOOL.Views._05_tab_search_model_name;

namespace TE_TOOL.Presenters
{
    public class SearchingToolPresenter
    {
        private readonly IViewSearchModelName _view;
        private readonly ISearchingService _service;
        public SearchingToolPresenter(IViewSearchModelName view, ISearchingService service) {
            _view=view;
            _service=service;
            _view.AddProductRequested += OnAddProductRequested;
            _view.SearchTextChanged += OnSearchTextChanged;
        }

        private void OnSearchTextChanged(object? sender, EventArgs e)
        {
            var keyword = ((ViewSearchModelName)_view).GetSearchText();
            var products = string.IsNullOrEmpty(keyword)
    ? _service.ReadFromFile()
    : _service.FindByModel(keyword)
               .Concat(_service.FindByProductName(keyword))
               .Distinct()
               .ToList();

            _view.DisplayProducts(products);
        }

        private void OnAddProductRequested(string filePath)
        {
            _service.LoadFromCsvOrTxt(filePath);
            var products = _service.ReadFromFile();
            _view.DisplayProducts(products);
        }

        public void LoadAllProducts() { var products = _service.ReadFromFile(); 
            _view.DisplayProducts(products); }

    }
}
