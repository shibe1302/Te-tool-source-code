using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.Services;
using TE_TOOL.ShowDialogForm;
using TE_TOOL.Views._03_tab_copy_ftu;

namespace TE_TOOL.Presenters
{
    public class CopyFtuPresenter
    {
        private readonly ICopyFtuUserControl _view;
        private readonly IDialogOldFtuView _viewDialog;
        private readonly ICopyFtuServices _service;
        public CopyFtuPresenter(ICopyFtuUserControl view, IDialogOldFtuView viewDialog, ICopyFtuServices service)
        {

            _view = view;
            _viewDialog = viewDialog;
            _service = service;

            RegisterEven();
            view.SetDialog(_viewDialog);


        }

        private void RegisterEven()
        {
            _view.btnOldFtuClicked += btnOldFtuClicked;
            _viewDialog.SaveClicked += OnSaveClicked;
            _viewDialog.btnGetFuntionTestClicked += OnGetFuntionTestClicked;
        }

        private void OnGetFuntionTestClicked(object? sender, EventArgs e)
        {
            _service.GetFunctionTest(_viewDialog.LogText);
            _viewDialog.setRichTextBoxContent( _service.TxtListFunctionTest);
            _view.DocListITem(_service.ListItemTest);
            Debug.WriteLine("GetFuntionTestClicked in Presenter called");
        }

        private void OnSaveClicked(object? sender, EventArgs e)
        {
            var content = _service.ListItemTest;
            _view.UpdateStatus(content);
            _viewDialog.CloseView();
        }

        private void btnOldFtuClicked(object? sender, EventArgs e)
        {
            _view.showForm();
        }
    }
}
