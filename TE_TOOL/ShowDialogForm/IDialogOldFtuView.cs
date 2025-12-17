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

        event EventHandler btnGetFuntionTestClicked;

        string TxtListFunctionTest { get; set; }
        void setRichTextBoxContent(string txt);
        void CloseView();
    }
}
