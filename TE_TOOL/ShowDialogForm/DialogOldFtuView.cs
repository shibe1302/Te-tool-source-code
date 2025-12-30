using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TE_TOOL.ShowDialogForm;

namespace TE_TOOL
{
    public partial class DialogOldFtuView : Form,IDialogOldFtuView
    {
        public DialogOldFtuView()
        {
            InitializeComponent();
            BTN_save.Click += (s, e) => SaveClicked?.Invoke(this, EventArgs.Empty);
            btnGetFuntionTest.Click += (s, e) => btnGetFuntionTestClicked?.Invoke(this, EventArgs.Empty);
        }

        public string LogText { get => rtbLogContainer.Text; set => rtbLogContainer.Text=value; }
        public string TxtListFunctionTest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler SaveClicked;
        public event EventHandler btnGetFuntionTestClicked;

        public void CloseView()
        {
            this.Close();
        }

        public void setRichTextBoxContent(string log)
        {
            rtbLogContainer.Text = log;
        }
    }
}
