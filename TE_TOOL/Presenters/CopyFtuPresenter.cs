using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        JsonElement items_from_json;
        string Items;
        public CopyFtuPresenter(ICopyFtuUserControl view, IDialogOldFtuView viewDialog, ICopyFtuServices service)
        {

            _view = view;
            _viewDialog = viewDialog;
            _service = service;

            RegisterEven();
            view.SetDialog(_viewDialog);

            Items = _view.ItemFromLog;
 

        }

        private void reloadJson()
        {
            
            items_from_json = _service.LoadJsonOrderItems(_view.JsonReorderPath, Items);
        }

        private void RegisterEven()
        {
            _view.btnOldFtuClicked += btnOldFtuClicked;
            _view.btnLoadClicked += OnLoadClicked;
            _viewDialog.SaveClicked += OnSaveClicked;
            _viewDialog.btnGetFuntionTestClicked += OnGetFuntionTestClicked;
            _view.btnReoderClicked += OnReoderClicked;
            _view.btnOpenFtuClicked += OnOpenFtuClicked;

        }

        private void OnOpenFtuClicked(object? sender, EventArgs e)
        {
            _view.SaveDatatoIni();
            _service.RunFtu(_view.getFtuPath);
        }

        private void OnReoderClicked(object? sender, EventArgs e)
        {
            try
            {
                _service.ReorderJsonItem(_view.ItemFromLog);
                _service.SaveFullJsonWithUpdatedItems(_view.JsonReorderPath);
                reloadJson();
            }
            catch (Exception)
            {
                
                MessageBox.Show("Lỗi");
                return;
            }

            _view.LoadItemToCheckListBox(items_from_json);
            _view.SaveDatatoIni();
            _view.SetSelectedItemToIni();
        }

        private void OnLoadClicked(object? sender, EventArgs e)
        {
            reloadJson();
            _view.LoadItemToCheckListBox(items_from_json);
            _view.enableBtnReoder();
            _view.SaveDatatoIni();
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
            _view.SaveDatatoIni();
            _viewDialog.CloseView();
        }

        private void btnOldFtuClicked(object? sender, EventArgs e)
        {
            _view.showForm();
        }
    }
}
