using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.ShowDialogForm;
using TE_TOOL.Views._03_tab_copy_ftu;

namespace TE_TOOL.Presenters
{
    public class CopyFtuPresenter
    {
        private readonly ICopyFtuUserControl _view;
        private readonly IDialogOldFtuView _viewDialog;
        public CopyFtuPresenter(ICopyFtuUserControl view, IDialogOldFtuView _viewDialog)
        {
            Debug.WriteLine("Presenter created");
            this._view = view;
            this._viewDialog = _viewDialog;
            this._view.btnOldFtuClicked += btnOldFtuClicked;
            _viewDialog.SaveClicked += OnSaveClicked;
            view.SetDialog(_viewDialog);
            
        }

        private void OnSaveClicked(object? sender, EventArgs e)
        {
            string content = _viewDialog.LogText;
            _view.UpdateStatus(content);
            _viewDialog.CloseView();
        }

        private void btnOldFtuClicked(object? sender, EventArgs e)
        {
            _view.showForm();
        }
    }
}
