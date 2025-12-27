using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TE_TOOL.Presenters;
using TE_TOOL.Services;
using TE_TOOL.ShowDialogForm;

namespace TE_TOOL.Views._03_tab_copy_ftu
{
    public partial class CopyFtuUserControl : UserControl, ICopyFtuUserControl
    {
        private IDialogOldFtuView _dialog;
        private Tab3Ini tab3Ini;
        private List<string> listSelectedItem;


        public CopyFtuUserControl()
        {
            InitializeComponent();
            DangKySuKien();
            loadDataFromIni();
            disbaleSelectedBTN();
   
        }
        public string JsonReorderPath { get => txtReorderJson.Text; }

        public string ItemFromLog { get => txtGetItemFormLog.Text; }


        private void disbaleSelectedBTN()
        {
            if (!string.IsNullOrEmpty(txtReorderJson.Text))
                btnSelectedItem.Enabled = true;
            else
                btnSelectedItem.Enabled = false;
        }

        void loadDataFromIni()
        {
            this.tab3Ini = new Tab3Ini(AppDomain.CurrentDomain.BaseDirectory);
            string selectedItemLog = tab3Ini.Item;
            string reorderJsonPath = tab3Ini.Reoder;
            string selectedItem = tab3Ini.Select;
            txtGetItemFormLog.Text = selectedItemLog;
            txtReorderJson.Text = reorderJsonPath;
            txtSelectedItem.Text = selectedItem;
            
        }
        public void SetSelectedItemToIni()
        {
            try
            {
                if (string.IsNullOrEmpty(txtSelectedItem.Text)) return;
                IniFile a = new IniFile(txtSelectedItem.Text);
                a.Write("ITEMS", "id", txtGetItemFormLog.Text);
                MessageBox.Show("Ghi thanh cong !");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi ghi file selected_items.ini", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        void saveDatatoIni()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtGetItemFormLog.Text))
                    tab3Ini.Item = txtGetItemFormLog.Text;
                if (!string.IsNullOrEmpty(txtReorderJson.Text))
                    tab3Ini.Reoder = txtReorderJson.Text;
                if (!string.IsNullOrEmpty(txtSelectedItem.Text))
                    tab3Ini.Select = txtSelectedItem.Text;
                if (!string.IsNullOrEmpty(txtSelectedItem.Text))
                    getSelectedItem(txtSelectedItem.Text);
            }
            catch (Exception)
            {
                Debug.WriteLine("Lỗi khi lưu dữ liệu vào ini");
            }

        }
        public void DangKySuKien()
        {
            btnGetItemFromLog.Click += (s, e) =>
            {
                btnOldFtuClicked?.Invoke(this, EventArgs.Empty);
                
            };
            txtSelectedItem.TextChanged += (s, e) =>
            {
                textChangeSelectedTextbox?.Invoke(this, EventArgs.Empty);
            };
            btnLoad.Click += (s, e) =>
            {
                btnLoadClicked?.Invoke(this, EventArgs.Empty);
            };
            btnReoder.Click += (s, e) =>
            {
                btnReoderClicked?.Invoke(this, EventArgs.Empty);
            };

        }

        public event EventHandler btnOldFtuClicked;
        public event EventHandler textChangeSelectedTextbox;
        public event EventHandler btnLoadClicked;
        public event EventHandler btnReoderClicked;

        public void UpdateStatus(List<string> list)
        {
            string text = string.Join(",", list);
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
            saveDatatoIni();
        }

        private void btnReorder_Click(object sender, EventArgs e)
        {
            ofdReorderJson.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            ofdReorderJson.Title = "Tìm file reorder.json trong FTU/products";
            if (ofdReorderJson.ShowDialog() == DialogResult.OK)
            {
                txtReorderJson.Text = ofdReorderJson.FileName;
            }
            saveDatatoIni();
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void getSelectedItem(string filePath)
        {
            var selectedItems = new List<string>();
            var iniFilePath = new IniFile(filePath);
            string selectedItemsStr = iniFilePath.Read("ITEMS", "id");
            var ids = selectedItemsStr.Split(',')
                 .Select(s => s.Trim())
                 .ToList();
            listSelectedItem = ids;
        }

        public void SaveDatatoIni()
        {
            saveDatatoIni();

        }

        void ICopyFtuUserControl.LoadItemToCheckListBox(JsonElement items)
        {
            clb_item_from_json.Items.Clear();
            if (items.ValueKind != JsonValueKind.Array) return;
            var count = 0;
            foreach (var item in items.EnumerateArray())
            {
                count++;
                int id = item.GetProperty("ID").GetInt32();
                string name = item.GetProperty("Name").GetString();
               clb_item_from_json.Items.Add($"{id} - {name}");
            }
            lbTotalItems.Text = $"Total items: {count}";
        }
    }
}
