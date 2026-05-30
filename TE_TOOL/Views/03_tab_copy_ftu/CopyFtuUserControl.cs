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
        HashSet<int> itemHashSet = new HashSet<int>();

        public CopyFtuUserControl()
        {
            InitializeComponent();
            DangKySuKien();
            loadDataFromIni();
            disbaleSelectedBTN();
            enableBtnReoder();
            this.AllowDrop = true;
            this.DragEnter += OnDragEnter;
            this.DragDrop += OnDragDrop;


        }

        private void OnDragDrop(object? sender, DragEventArgs e)
        {
            string[] dropped = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (dropped == null || dropped.Length == 0) return;

            // Lấy folder: nếu kéo thả folder thì lấy thẳng, nếu kéo file thì lấy thư mục cha
            string folder = Directory.Exists(dropped[0])
                ? dropped[0]
                : Path.GetDirectoryName(dropped[0]);

            AutoFillPaths(folder);
        }

        private void OnDragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void AutoFillPaths(string rootFolder)
        {
            // --- 1. Tìm *_reorder.json (tìm đệ quy trong folder) ---
            var reorderFiles = Directory.GetFiles(rootFolder, "*_reorder.json", SearchOption.AllDirectories);
            if (reorderFiles.Length > 0)
                txtReorderJson.Text = reorderFiles[0];
            else
                MessageBox.Show("Không tìm thấy file *_reorder.json", "Thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // --- 2. Tìm selected_items.ini ---
            var selectedFiles = Directory.GetFiles(rootFolder, "selected_items.ini", SearchOption.AllDirectories);
            if (selectedFiles.Length > 0)
                txtSelectedItem.Text = selectedFiles[0];
            else
                MessageBox.Show("Không tìm thấy file selected_items.ini", "Thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // --- 3. Tìm FTU_*.exe ---
            var ftuFiles = Directory.GetFiles(rootFolder, "FTU_*.exe", SearchOption.AllDirectories);
            if (ftuFiles.Length > 0)
                txtFTUexe.Text = ftuFiles[0];
            else
                MessageBox.Show("Không tìm thấy file FTU_*.exe", "Thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            saveDatatoIni();
        }

        public string JsonReorderPath { get => txtReorderJson.Text; }

        // CopyFtuUserControl.cs
        public string ItemFromLog { get => txtGetItemFormLog.Text.Replace(" ", ""); }

        public string getFtuPath { get => txtFTUexe.Text; }

        public void addItemToHashSet()
        {
            var items = txtGetItemFormLog.Text.Split(',')
                .Select(s => s.Trim());
            itemHashSet.Clear();
            foreach (var item in items)
            {
                if (int.TryParse(item, out int id))
                {
                    itemHashSet.Add(id);
                }
            }
        }
        private void disbaleSelectedBTN()
        {
            if (!string.IsNullOrEmpty(txtReorderJson.Text))
                btnSelectedItem.Enabled = true;
            else
                btnSelectedItem.Enabled = false;



        }

        public void enableBtnReoder()
        {
            if (clb_item_from_json.Items.Count == 0 || !File.Exists(txtSelectedItem.Text))
            {
                btnReoder.Visible = false; // ẩn nút
            }
            else
            {
                btnReoder.Visible = true;
            }
        }

        void loadDataFromIni()
        {
            this.tab3Ini = new Tab3Ini(AppDomain.CurrentDomain.BaseDirectory);
            string selectedItemLog = tab3Ini.Item;
            string reorderJsonPath = tab3Ini.Reoder;
            string selectedItem = tab3Ini.Select;
            string exePath = tab3Ini.exePath;
            txtGetItemFormLog.Text = selectedItemLog;
            txtReorderJson.Text = reorderJsonPath;
            txtSelectedItem.Text = selectedItem;
            txtFTUexe.Text = exePath;

        }
        public void SetSelectedItemToIni()
        {
            try
            {
                if (string.IsNullOrEmpty(txtSelectedItem.Text)) return;
                IniFile a = new IniFile(txtSelectedItem.Text);
                a.Write("ITEMS", "id", ItemFromLog);

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
                if (!string.IsNullOrEmpty(txtFTUexe.Text))
                    tab3Ini.exePath = txtFTUexe.Text;
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
            btnOpenFTU.Click += (s, e) =>
            {
                btnOpenFtuClicked?.Invoke(this, EventArgs.Empty);
            };

        }

        public event EventHandler btnOldFtuClicked;
        public event EventHandler textChangeSelectedTextbox;
        public event EventHandler btnLoadClicked;
        public event EventHandler btnReoderClicked;
        public event EventHandler btnOpenFtuClicked;

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
            txtSelectedItem.Text = "";
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

        private void txtGetItemFormLog_Leave(object sender, EventArgs e)
        {
            addItemToHashSet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofdFTUexe.Filter = "EXE files (*.exe)|*.exe|All files (*.*)|*.*";

            if (ofdFTUexe.ShowDialog() == DialogResult.OK)
            {
                txtFTUexe.Text = ofdFTUexe.FileName;
            }
        }



        // Trong file CopyFtuUserControl.cs
        // CHỈ CẦN SỬA method này:

        void ICopyFtuUserControl.LoadItemToCheckListBox(JsonElement items)
        {
            addItemToHashSet();
            clb_item_from_json.Items.Clear();
            if (items.ValueKind != JsonValueKind.Array) return;

            var count = 0;
            foreach (var item in items.EnumerateArray())
            {
                count++;

                // SỬA PHẦN NÀY - Sử dụng helper method giống Services
                int id = GetIdFromJsonElement(item);
                string name = item.GetProperty("Name").GetString();

                bool isChecked = itemHashSet.Contains(id);
                clb_item_from_json.Items.Add($"{id} - {name}", isChecked);
            }

            lbTotalItems.Text = $"Total items: {count}";
        }

        // THÊM helper method này vào class CopyFtuUserControl
        private int GetIdFromJsonElement(JsonElement item)
        {
            JsonElement idElement = item.GetProperty("ID");

            if (idElement.ValueKind == JsonValueKind.Number)
            {
                return idElement.GetInt32();
            }
            else if (idElement.ValueKind == JsonValueKind.String)
            {
                string idStr = idElement.GetString();
                if (int.TryParse(idStr, out int id))
                {
                    return id;
                }
                else
                {
                    MessageBox.Show(
                        $"Invalid ID format: {idStr}",
                        "Lỗi convert ID!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return -1; // hoặc throw exception
                }
            }
            else
            {
                MessageBox.Show(
                    "ID has an unsupported format.",
                    "Lỗi định dạng ID!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return -1;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Đặt link bạn muốn mở
            string url = "https://www.google.com/search?q=check+diff+text+online";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở link: " + ex.Message);
            }

        }
    }
}
