
using System;

namespace TE_TOOL.Views._02_tab_thu_thap_log
{

    public interface ILogCollectorView
    {

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


 
        void ShowMessage(string message, string title, MessageType type);


        void SetRemoteFolderLabel(string text);


        void EnableControls(bool enabled);


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