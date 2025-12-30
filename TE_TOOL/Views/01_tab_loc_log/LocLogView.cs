using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TE_TOOL.Views._01_tab_loc_log;

namespace TE_TOOL.Views
{
    /// <summary>
    /// View trong mô hình MVP
    /// - Chỉ chịu trách nhiệm hiển thị UI và nhận input từ user
    /// - KHÔNG chứa business logic
    /// - Communicate với Presenter qua Events và Interface methods
    /// </summary>
    public partial class LocLogView : UserControl, ILocLogView
    {
        // ===========================================
        // EVENTS - Raise khi user tương tác với UI
        // ===========================================
        public event EventHandler RunScriptClicked;
        public event EventHandler OpenMacFileClicked;
        public event EventHandler LogPathDropped;

        // ===========================================
        // PROPERTIES - Expose UI controls data
        // ===========================================

        /// <summary>
        /// Lấy/Set giá trị trong textbox log path
        /// Presenter sẽ đọc property này khi cần
        /// </summary>
        public string LogPathInput
        {
            get => txtFolderLog.Text.Trim();
            set => txtFolderLog.Text = value;
        }

        /// <summary>
        /// MAC path input (để dành cho tương lai)
        /// </summary>
        public string MacPathInput
        {
            get => txtMacPath.Text.Trim(); // Chưa có control
            set => txtMacPath.Text = value; // Chưa implement
        }

        public string modeLog
        {
            get => cbbTypeLog.SelectedItem.ToString();
        }

        // ===========================================
        // CONSTRUCTOR
        // ===========================================
        public LocLogView()
        {
            InitializeComponent();
            SetupEventHandlers();
            SetupDragDrop();
            InitSetupUI();
        }

        private void InitSetupUI()
        {
            cbbTypeLog.SelectedIndex = 0;
            pictureBox1.Image = Image.FromFile("Resources\\happy.png");
        }

        // ===========================================
        // PRIVATE METHODS - Chỉ liên quan đến UI
        // ===========================================

        /// <summary>
        /// Đăng ký các event handlers cho controls
        /// </summary>
        private void SetupEventHandlers()
        {
            // Khi user click nút Run, raise event cho Presenter biết
            buttonRunPS.Click += (sender, e) => RunScriptClicked?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Setup drag & drop cho form
        /// </summary>
        private void SetupDragDrop()
        {
            this.AllowDrop = true;
            this.DragEnter += OnDragEnter;
            this.DragDrop += OnDragDrop;
        }

        /// <summary>
        /// Xử lý khi file được drag vào vùng drop
        /// </summary>
        private void OnDragEnter(object sender, DragEventArgs e)
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

        /// <summary>
        /// Xử lý khi file được thả vào
        /// View chỉ lấy đường dẫn và hiển thị, KHÔNG validate
        /// Validation sẽ do Presenter xử lý
        /// </summary>
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files != null && files.Length > 0)
                {
                    // Chỉ lấy file đầu tiên
                    LogPathInput = files[0];

                    // Raise event để Presenter biết đã có file được drop
                    LogPathDropped?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                // View chỉ hiển thị lỗi UI-related
                ShowError($"Không thể đọc file: {ex.Message}");
            }
        }

        // ===========================================
        // PUBLIC METHODS - Implement ILocLogView
        // Presenter gọi các methods này để update UI
        // ===========================================

        /// <summary>
        /// Hiển thị status message với màu tương ứng
        /// </summary>
        public void SetStatus(string message, Color color)
        {
            labelStatus.Text = message;
            labelStatus.ForeColor = color;
        }

        /// <summary>
        /// Enable/Disable nút Run
        /// Presenter disable nút này khi đang xử lý
        /// </summary>
        public void SetRunButtonEnabled(bool enabled)
        {
            buttonRunPS.Enabled = enabled;
        }

        /// <summary>
        /// Hiển thị MessageBox cảnh báo
        /// </summary>
        public void ShowWarning(string message)
        {
            MessageBox.Show(message, "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Hiển thị MessageBox lỗi
        /// </summary>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Hiển thị MessageBox thông tin
        /// </summary>
        public void ShowInfo(string message)
        {
            MessageBox.Show(message, "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Reset form về trạng thái ban đầu
        /// </summary>
        public void ClearForm()
        {
            txtFolderLog.Clear();
            labelStatus.Text = string.Empty;
            labelStatus.ForeColor = Color.Black;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {

            {
                odfMacPath.Filter = "Text files (*.txt)|*.txt";
                if (odfMacPath.ShowDialog() == DialogResult.OK)
                {
                    MacPathInput = odfMacPath.FileName;

                }
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("Resources\\sad.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            // Dispose previous image to avoid file lock/memory leak
            pictureBox1.Image?.Dispose();
            // Use a valid resource that exists, e.g., QR (as per your Resources class)
            pictureBox1.Image = Properties.Resources.happy;
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("Resources\\du_sad.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            // Dispose previous image to avoid file lock/memory leak
            pictureBox2.Image?.Dispose();
            // Use a valid resource that exists, e.g., QR (as per your Resources class)
            pictureBox2.Image = Properties.Resources.du_happy;
        }
    }
}