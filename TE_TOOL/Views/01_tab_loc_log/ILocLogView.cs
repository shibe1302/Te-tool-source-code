using System;
using System.Drawing;

namespace TE_TOOL.Views._01_tab_loc_log
{

    public interface ILocLogView
    {

        string LogPathInput { get; set; }


        string MacPathInput { get; set; }
        string modeLog { get; }

        void SetStatus(string message, Color color);

        void SetRunButtonEnabled(bool enabled);


        void ShowWarning(string message);


        void ShowError(string message);


        void ShowInfo(string message);

        void ClearForm();

        event EventHandler RunScriptClicked;


        event EventHandler OpenMacFileClicked;

        event EventHandler LogPathDropped;
    }
}