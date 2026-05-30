using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TE_TOOL.Models;

namespace TE_TOOL.Views._06_tab_Switch_GPT
{
    public partial class AddEditForm : Form
    {
        public string Question => txtQuestion.Text.Trim();
        public string Answer => txtAnswer.Text.Trim();
        public string Tags => txtTags.Text.Trim();
        public AddEditForm(QAItem existing = null)
        {
            InitializeComponent();
            if (existing != null)
            {
                txtQuestion.Text = existing.Question;
                txtAnswer.Text = existing.Answer;
                txtTags.Text = existing.Tags;
                Text = "Sửa câu hỏi";
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Question) || string.IsNullOrWhiteSpace(Answer))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ câu hỏi và câu trả lời!");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
