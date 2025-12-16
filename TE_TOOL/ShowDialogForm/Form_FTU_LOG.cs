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
    public partial class Form_FTU_LOG : Form,IDialogOldFtuView
    {
        public Form_FTU_LOG()
        {
            InitializeComponent();
            BTN_save.Click += (s, e) => SaveClicked?.Invoke(this, EventArgs.Empty);
        }

        public string LogText { get => richTextBox1.Text; set => richTextBox1.Text=value; }

        public event EventHandler SaveClicked;

        public void CloseView()
        {
            this.Close();
        }
    }
}
