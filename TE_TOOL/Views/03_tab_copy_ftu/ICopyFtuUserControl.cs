using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TE_TOOL.Services;
using TE_TOOL.ShowDialogForm;

namespace TE_TOOL.Views._03_tab_copy_ftu
{
    public interface ICopyFtuUserControl
    {
        event EventHandler btnOldFtuClicked;
        event EventHandler textChangeSelectedTextbox;
        event EventHandler btnLoadClicked;
        event EventHandler btnReoderClicked;
        event EventHandler btnOpenFtuClicked;

        string JsonReorderPath { get;  }
        string ItemFromLog { get; }
        string getFtuPath { get; }

        void showForm();
        void UpdateStatus(List<string> list);
        void SetDialog(IDialogOldFtuView dialog);
        void DocListITem(List<string> list);
        void SaveDatatoIni();
        void LoadItemToCheckListBox(JsonElement items);

        void SetSelectedItemToIni();

        public void addItemToHashSet();
        public void enableBtnReoder();
    }
}
