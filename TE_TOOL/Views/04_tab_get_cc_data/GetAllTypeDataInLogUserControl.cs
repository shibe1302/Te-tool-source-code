using System;
using System.Diagnostics;
using System.Windows.Forms;
using TE_TOOL.Models;

namespace TE_TOOL.Views._04_tab_get_cc_data
{
    public partial class GetAllTypeDataInLogUserControl : UserControl, IGetAllTypeDataInLog
    {
        private GetDataByRegexModel model1;
        private Tab5Ini tab5Ini;

        public event EventHandler btnGetDataClicked;

        GetDataByRegexModel IGetAllTypeDataInLog.model { get => model1; set => model1 = value; }

        public GetAllTypeDataInLogUserControl()
        {
            model1 = new GetDataByRegexModel();
            InitializeComponent();
            setLink();
            DangKySuKien();
            SetupDragDrop();
            loadDataFromIni();
        }

        private void SetupDragDrop()
        {
            this.DragEnter += OnDragEnter;
            this.DragDrop += OnDragDrop;
        }

        void loadDataFromIni()
        {
            this.tab5Ini = new Tab5Ini(AppDomain.CurrentDomain.BaseDirectory);
            textBox1.Text = tab5Ini.prefix;
            textBox2.Text = tab5Ini.value;
            textBox3.Text = tab5Ini.pathlog;
            textBox4.Text = tab5Ini.savelocation;
        }

        void saveDatatoIni()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                    tab5Ini.prefix = textBox1.Text;
                if (!string.IsNullOrEmpty(textBox2.Text))
                    tab5Ini.value = textBox2.Text;
                if (!string.IsNullOrEmpty(textBox3.Text))
                    tab5Ini.pathlog = textBox3.Text;
                if (!string.IsNullOrEmpty(textBox4.Text))
                    tab5Ini.savelocation = textBox4.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu vào file ini", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDragDrop(object? sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (paths != null && paths.Length > 0)
            {
                if (System.IO.Directory.Exists(paths[0]))
                {
                    textBox3.Text = paths[0];
                }
                else
                {
                    MessageBox.Show("Vui lòng thả folder, không phải file!");
                }
            }
        }

        private void OnDragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public void DangKySuKien()
        {
            // Đăng ký sự kiện ở đây
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            button3.Click += (s, e) => btnGetDataClicked?.Invoke(this, EventArgs.Empty);
        }

        void setLink()
        {
            linkLabel1.Text = "Hướng dẫn viết Regex, đọc để dùng được tool";

            string pdfPath = GetPdfPath();
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, pdfPath);
        }

        private string GetPdfPath()
        {
            // Thử tìm PDF ở thư mục output trước (cho cả Debug và Release)
            string outputPath = Path.Combine(Application.StartupPath, "Views", "04_tab_get_cc_data", "con cac.pdf");

            if (File.Exists(outputPath))
            {
                return outputPath;
            }

            // Nếu không tìm thấy, thử tìm ở thư mục project (fallback cho Debug)
            string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\"));
            string sourcePath = Path.Combine(projectPath, "Views", "04_tab_get_cc_data", "con cac.pdf");

            if (File.Exists(sourcePath))
            {
                return sourcePath;
            }

            // Nếu vẫn không tìm thấy, trả về đường dẫn output (sẽ báo lỗi sau)
            return outputPath;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string pdfPath = e.Link.LinkData.ToString();

                if (File.Exists(pdfPath))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = pdfPath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file PDF: " + pdfPath, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở file PDF: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            new cangoi().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fbdPathLog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = fbdPathLog.SelectedPath;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            saveDatatoIni();

        }

        public void AddDatatoModel()
        {
            model1.PrefixRegex = textBox1.Text;
            model1.ValueRegex = textBox2.Text;
            model1.PathLog = textBox3.Text;
            model1.SaveLocation = textBox4.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fbdSaveLocation.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = fbdSaveLocation.SelectedPath;
            }

        }
    }
}
