using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE_TOOL.ShowDialogForm;

namespace TE_TOOL.Views._03_tab_copy_ftu
{
    public interface ICopyFtuUserControl
    {
        event EventHandler btnOldFtuClicked;
        void showForm();
        void UpdateStatus(string text);
        void SetDialog(IDialogOldFtuView dialog);
        void DocListITem(List<string> list);
    }
}
