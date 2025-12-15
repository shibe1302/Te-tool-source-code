using System;
using System.Drawing;

namespace TE_TOOL.Views._01_tab_loc_log
{
    /// <summary>
    /// Interface định nghĩa contract giữa View và Presenter
    /// View chỉ biết hiển thị dữ liệu và nhận input từ user
    /// View KHÔNG chứa business logic
    /// </summary>
    public interface ILocLogView
    {
        // ===========================================
        // PROPERTIES - Lấy/Set dữ liệu từ UI controls
        // ===========================================

        /// <summary>
        /// Đường dẫn log file/folder mà user nhập hoặc drag-drop
        /// Presenter sẽ đọc giá trị này khi cần xử lý
        /// </summary>
        string LogPathInput { get; set; }

        /// <summary>
        /// Đường dẫn MAC file (nếu cần trong tương lai)
        /// </summary>
        string MacPathInput { get; set; }

        // ===========================================
        // METHODS - Presenter gọi để cập nhật UI
        // ===========================================

        /// <summary>
        /// Hiển thị trạng thái trên label status
        /// VD: "Đang xử lý...", "Hoàn thành!", "Lỗi!"
        /// </summary>
        /// <param name="message">Nội dung hiển thị</param>
        /// <param name="color">Màu chữ (Green/Red/Blue)</param>
        void SetStatus(string message, Color color);

        /// <summary>
        /// Enable/Disable nút Run để tránh user click nhiều lần
        /// </summary>
        void SetRunButtonEnabled(bool enabled);

        /// <summary>
        /// Hiển thị MessageBox cảnh báo (Warning)
        /// </summary>
        void ShowWarning(string message);

        /// <summary>
        /// Hiển thị MessageBox lỗi (Error)
        /// </summary>
        void ShowError(string message);

        /// <summary>
        /// Hiển thị MessageBox thông tin (Info)
        /// </summary>
        void ShowInfo(string message);

        /// <summary>
        /// Clear toàn bộ form về trạng thái ban đầu
        /// </summary>
        void ClearForm();

        // ===========================================
        // EVENTS - View raise events, Presenter subscribe
        // ===========================================

        /// <summary>
        /// Event khi user click nút "Run Script"
        /// Presenter sẽ subscribe event này để xử lý logic
        /// </summary>
        event EventHandler RunScriptClicked;

        /// <summary>
        /// Event khi user click nút "Open MAC File"
        /// </summary>
        event EventHandler OpenMacFileClicked;

        /// <summary>
        /// Event khi user drag-drop file/folder vào UI
        /// Presenter sẽ nhận event này và xử lý
        /// </summary>
        event EventHandler LogPathDropped;
    }
}