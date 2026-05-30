using TE_TOOL.Models;

namespace TE_TOOL.Views._06_tab_Switch_GPT
{
    public partial class QANotebookView : Form, IQANotebookView
    {
        public string SearchQuery
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }
        public string StatusMessage
        {
            set => lblStatus.Text = value;
        }
        public string CountdownText
        {
            set => lblCountdown.Text = value;
        }
        public Color CountdownColor
        {
            set => lblCountdown.ForeColor = value;
        }
        public int SelectedIndex => lstResults.SelectedIndex;

        // Khai báo các sự kiện
        public event EventHandler SearchTextChanged;
        public event EventHandler SearchExecuted;
        public event EventHandler ItemSelected;
        public event EventHandler AddClicked;
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler ImportClicked;
        public event EventHandler TimerTicked;
        public event EventHandler ViewLoaded;
        public event EventHandler SyncClicked;

        public QANotebookView()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            // Ủy thác trực tiếp các Event Control sang Event của Interface để Presenter bắt lấy
            txtSearch.TextChanged += (s, e) => SearchTextChanged?.Invoke(this, EventArgs.Empty);
            lstResults.SelectedIndexChanged += (s, e) => ItemSelected?.Invoke(this, EventArgs.Empty);
            this.Load += (s, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);
            btnAdd.Click += (s, e) => AddClicked?.Invoke(this, EventArgs.Empty);
            btnUpdateDB.Click += (s, e) => SyncClicked?.Invoke(this, EventArgs.Empty); // Gán nút Update vào Edit
            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
            button1.Click += (s, e) => ImportClicked?.Invoke(this, EventArgs.Empty); // Nút Import csv

            // Cài đặt Timer
            sessionTimer.Interval = 1000;
            sessionTimer.Tick += (s, e) => TimerTicked?.Invoke(this, EventArgs.Empty);
            sessionTimer.Start();

            // Vẽ Item tùy biến cho ListBox giữ nguyên phần Render UI cũ
            lstResults.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;
                e.DrawBackground();
                e.Graphics.DrawString(
                    lstResults.Items[e.Index]?.ToString(),
                    e.Font,
                    Brushes.Black,
                    e.Bounds);
                e.DrawFocusRectangle();
            };
        }

        public void DisplayResults(List<string> previews)
        {
            lstResults.Items.Clear();
            foreach (var item in previews)
            {
                lstResults.Items.Add(item);
            }
            if (lstResults.Items.Count > 0)
                lstResults.SelectedIndex = 0;
        }

        public void DisplayAnswer(string question, string answer, string tags)
        {
            txtAnswer.Clear();
            txtAnswer.AppendText($"❓ {question}\n");
            txtAnswer.AppendText(new string('─', 60) + "\n");
            txtAnswer.AppendText($"💡 {answer}\n");
            if (!string.IsNullOrEmpty(tags))
                txtAnswer.AppendText($"\n🏷 Tags: {tags}");
        }

        public void ClearAnswer() => txtAnswer.Clear();

        public void CloseView()
        {
            sessionTimer.Stop();
            this.Close();
        }

        public (bool IsOk, string Question, string Answer, string Tags) ShowAddEditDialog(QAItem existing = null)
        {
            using var dialog = new AddEditForm(existing);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return (true, dialog.Question, dialog.Answer, dialog.Tags);
            }
            return (false, null, null, null);
        }

        public bool ConfirmAction(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public string ShowOpenFileDialog()
        {
            using var openDialog = new OpenFileDialog
            {
                Title = "Chọn file CSV để import",
                Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Multiselect = false
            };
            return openDialog.ShowDialog() == DialogResult.OK ? openDialog.FileName : null;
        }

        public void ShowMessageBox(string message, string title, bool isError = false)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && txtSearch.Focused)
            {
                SearchExecuted?.Invoke(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void SetProgress(int percent)
        {
            progressBar1.Value = Math.Clamp(percent, 0, 100);
        }

        public void SetProgressVisible(bool visible)
        {
            progressBar1.Visible = visible;
        }

        public void SetUpdateButtonEnabled(bool enabled)
        {
            Console.WriteLine("cac");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
