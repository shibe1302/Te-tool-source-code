using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QANotebook
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }
        // Trong LoginForm.cs
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string correctPass = SecurityHelper.GenerateDailyPassword();

            if (txtPassword.Text == correctPass)
            {
                this.DialogResult = DialogResult.OK; // Trả về kết quả thành công
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu nội bộ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
