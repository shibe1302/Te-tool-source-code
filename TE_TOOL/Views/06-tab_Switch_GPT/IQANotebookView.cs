using TE_TOOL.Models;

namespace TE_TOOL.Views._06_tab_Switch_GPT
{
    /// <summary>
    /// Contract giữa View và Presenter.
    /// Thêm: SyncClicked, ViewLoaded, SetProgress, SetProgressVisible, SetUpdateButtonEnabled.
    /// </summary>
    public interface IQANotebookView
    {
        // ── Properties ────────────────────────────────────────────────────
        string SearchQuery { get; set; }
        string StatusMessage { set; }
        string CountdownText { set; }
        Color CountdownColor { set; }
        int SelectedIndex { get; }

        // ── Events ────────────────────────────────────────────────────────
        event EventHandler SearchTextChanged;
        event EventHandler SearchExecuted;
        event EventHandler ItemSelected;
        event EventHandler AddClicked;
        event EventHandler EditClicked;
        event EventHandler DeleteClicked;
        event EventHandler ImportClicked;
        event EventHandler TimerTicked;

        /// <summary>Kích hoạt khi form hiện ra lần đầu — dùng để auto-check update.</summary>
        event EventHandler ViewLoaded;

        /// <summary>Nút Update bấm thủ công để sync DB từ server.</summary>
        event EventHandler SyncClicked;

        // ── Display methods ───────────────────────────────────────────────
        void DisplayResults(List<string> previews);
        void DisplayAnswer(string question, string answer, string tags);
        void ClearAnswer();
        void CloseView();

        // ── Sync UI helpers ───────────────────────────────────────────────
        /// <summary>Cập nhật giá trị ProgressBar (0–100).</summary>
        void SetProgress(int percent);

        /// <summary>Hiện / ẩn ProgressBar.</summary>
        void SetProgressVisible(bool visible);

        /// <summary>Enable / Disable nút Update để tránh spam.</summary>
        void SetUpdateButtonEnabled(bool enabled);

        // ── Dialog helpers ────────────────────────────────────────────────
        (bool IsOk, string Question, string Answer, string Tags) ShowAddEditDialog(QAItem? existing = null);
        bool ConfirmAction(string message, string title);
        string ShowOpenFileDialog();
        void ShowMessageBox(string message, string title, bool isError = false);
    }
}