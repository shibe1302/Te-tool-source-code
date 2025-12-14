using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE_TOOL.Views._01_tab_loc_log
{
    internal interface ILocLogView
    {
        // Inputs
        string LogPathInput { get; set; }
        string MacPathInput { get; set; }

        // UI updates
        void SetStatus(string message, System.Drawing.Color color);
        void SetRunButtonEnabled(bool enabled);
        void ShowWarning(string message);
        void ShowError(string message);
        void ShowInfo(string message);

        // Events
        event EventHandler RunScriptClicked;
        event EventHandler OpenMacFileClicked;
        event EventHandler LogPathDropped; // khi drag-drop xong
    }
}
