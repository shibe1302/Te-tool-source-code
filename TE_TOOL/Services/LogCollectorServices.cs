using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE_TOOL.Services
{
    internal class LogCollectorServices
    {



        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
