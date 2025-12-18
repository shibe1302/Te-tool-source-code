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
            btnSelectedItem.Enabled = false;

        }

        public void DangKySuKien()
        {
            btnGetItemFromLog.Click += (s, e) =>
            {
                btnOldFtuClicked?.Invoke(this, EventArgs.Empty);
                Debug.Write(btnOldFtuClicked);
            };

        }

        public event EventHandler btnOldFtuClicked;

        public void UpdateStatus(List<string> list)
        {
            string text = string.Join(", ", list);
            txtGetItemFormLog.Text = text;
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

        private void btnSelectedItem_Click(object sender, EventArgs e)
        {
            ofdSelectedItemInit.Filter = "Text files (*.ini)|*.ini|All files (*.*)|*.*";
            ofdSelectedItemInit.Title = "Tìm file selected_items.ini trong FTU/data";
            if (ofdSelectedItemInit.ShowDialog() == DialogResult.OK)
            {
                txtSelectedItem.Text = ofdSelectedItemInit.FileName;
            }
        }

        private void btnReorder_Click(object sender, EventArgs e)
        {
            ofdReorderJson.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            ofdReorderJson.Title = "Tìm file reorder.json trong FTU/products";
            if (ofdReorderJson.ShowDialog() == DialogResult.OK)
            {
                txtReorderJson.Text = ofdReorderJson.FileName;
            }
        }

        private void txtReorderJson_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReorderJson.Text))
            {
                btnSelectedItem.Enabled = false;
            }
            else
            {
                btnSelectedItem.Enabled = true;
            }
        }
    }
}
