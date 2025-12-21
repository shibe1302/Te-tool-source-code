using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.Services;
using TE_TOOL.Views._01_tab_loc_log;
using TE_TOOL.Views._04_tab_get_cc_data;

namespace TE_TOOL.Presenters
{
    internal class GetDataByRegexPresenter
    {
        private readonly IGetAllTypeDataInLog _view;
        private readonly IGetAllTypeDataInLogService _service;
        public GetDataByRegexPresenter(IGetAllTypeDataInLog view, IGetAllTypeDataInLogService service)
        {
            _view = view;
            _service = service;
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            _view.btnGetDataClicked += OnGetDataClicked;
        }

        private void OnGetDataClicked(object? sender, EventArgs e)
        {
            _view.AddDatatoModel();
            _service.runScript(_view.model);
        }
    }
}
