// ============================================
// FILE: Views/02_tab_thu_thap_log/ILogCollectorView.cs
// ============================================
using System;

namespace TE_TOOL.Views._02_tab_thu_thap_log
{
    /// <summary>
    /// Interface giữa View và Presenter
    /// Định nghĩa contract để Presenter có thể tương tác với View mà không phụ thuộc vào WinForms
    /// </summary>
    public interface ILogCollectorView
    {
        // ============================================
        // Properties - Presenter đọc/ghi dữ liệu qua đây
        // ============================================
        string Host { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string Protocol { get; set; }
        string PortNumber { get; set; }
        string LocalDownloadDestination { get; set; }
        string WinscpDLLPath { get; set; }
        string RemoteFolderScan { get; set; }
        string MaxThreadScan { get; set; }
        string MacFilePath { get; set; }
        bool IsLocalScanMode { get; set; }
        bool ShowPassword { get; set; }

        // ============================================
        // Methods - Presenter điều khiển View
        // ============================================

 
        void ShowMessage(string message, string title, MessageType type);


        void SetRemoteFolderLabel(string text);


        void EnableControls(bool enabled);

        // ============================================
        // Events - View thông báo Presenter khi có action
        // ============================================
        event EventHandler SaveFormInfoClicked;
        event EventHandler StartScanLogClicked;
        event EventHandler BrowseLocalFolderClicked;
        event EventHandler BrowseWinscpDllClicked;
        event EventHandler BrowseMacFileClicked;
        event EventHandler LocalScanModeChanged;
        event EventHandler ShowPasswordChanged;
    }

    public enum MessageType
    {
        Information,
        Warning,
        Error
    }
}