using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TE_TOOL.Presenters;
using TE_TOOL.ShowDialogForm;

namespace TE_TOOL.Views._03_tab_copy_ftu
{
    public partial class CopyFtuUserControl : UserControl, ICopyFtuUserControl
    {
        private IDialogOldFtuView _dialog;
        public CopyFtuUserControl()
        {
            InitializeComponent();
            DangKySuKien();
        }

        public void DangKySuKien()
        {
            btnFTUcu.Click += (s, e) =>
            {
                btnOldFtuClicked?.Invoke(this, EventArgs.Empty);
                Debug.Write(btnOldFtuClicked);
            };
            
        }

        public event EventHandler btnOldFtuClicked;

        public void UpdateStatus(string text)
        {
            lbFtuList.Text = text;
        }

        public void SetDialog(IDialogOldFtuView dialog)
        {
            _dialog = dialog;
        }

        public void showForm()
        {
            (_dialog as Form)?.ShowDialog();
        }

        public void DocListITem(List<string> list)
        {
            list.ForEach(x => Debug.WriteLine($"[{x}]"));
            
        }
    }
}
