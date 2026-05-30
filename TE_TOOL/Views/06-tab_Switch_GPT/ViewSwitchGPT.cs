using hocWF;
using QANotebook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TE_TOOL.Infrastructure;
using TE_TOOL.Models;
using TE_TOOL.Presenters;
using TE_TOOL.Services;

namespace TE_TOOL.Views._06_tab_Switch_GPT
{
    public partial class ViewSwitchGPT : UserControl, IViewSwitchGPT
    {
        public ViewSwitchGPT()
        {
            InitializeComponent();
        }

        event EventHandler IViewSwitchGPT.btnStartDST
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        private void imgURLDST_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://hoanganhmobile.com/duoc-si-tien-he-lo-chat-dst-nen-tang-ai-vuot-troi-hon-ca-chatgpt-ra-mat-thang-10-toi",
                UseShellExecute = true
            });
        }

        private void btnStartDST_Click(object sender, EventArgs e)
        {
            using (LoginForm login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // 2. Khởi tạo Database Service (Tầng Model)
                    var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "qa_notebook.db");
                    var dbService = new DatabaseService(dbPath);

                    // 3. Khởi tạo View (Form1 của QANotebook)
                    QANotebookView qaForm = new QANotebookView();

                    // CONFIG
                    var config = SftpConfigManager.Load();

                    // SERVICE
                    var sync = new SftpSyncService(config);

                    // 4. Khởi tạo Presenter để ràng buộc View và Model lại với nhau
                    var presenter = new QANotebookPresenter(
    qaForm,
    dbService,
    sync,
    dbPath
);

                    // 5. Hiển thị Module lên dạng Dialog hoặc Show() tùy nhu cầu hệ thống của bạn
                    qaForm.ShowDialog();
                }
            }
        }
    }
}
