using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE_TOOL.ShowDialogForm
{
    public interface IDialogOldFtuView
    {
        string LogText { get; set; }
        event EventHandler SaveClicked;
        void CloseView();
    }
}
