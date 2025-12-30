
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TE_TOOL.CONFIG;
using TE_TOOL.Presenters;
using TE_TOOL.Services;

namespace TE_TOOL.Views._02_tab_thu_thap_log
{

    public partial class LogCollectorView : UserControl, ILogCollectorView
    {
        private LogCollectorPresenter _presenter;

        public LogCollectorView()
        {
            InitializeComponent();
            var service = new LogCollectorService();
            _presenter = new LogCollectorPresenter(this, service, CONFIG_CONSTANT.CONFIG_LOG_COLLECTOR);
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            // Button events
            BTN_saveFormInfo.Click += (s, e) => SaveFormInfoClicked?.Invoke(s, e);
            BTN_startScanLog.Click += (s, e) => StartScanLogClicked?.Invoke(s, e);
            BTN_localFolderDownloadLog.Click += OnBrowseLocalFolder;
            BTN_winscpDll_file.Click += OnBrowseWinscpDll;
            BTN_macFilePath.Click += OnBrowseMacFile;

            // CheckBox events
            CB_LocalScan.CheckedChanged += OnLocalScanModeChanged;
            CB_showPass.CheckedChanged += OnShowPasswordChanged;

            // TextBox events
            TB_severScan.Click += OnRemoteFolderScanClick;
            TB_portNumber.KeyPress += TB_portNumber_KeyPress;
            TB_maxThread.KeyPress += TB_maxThread_KeyPress;
        }


        public string Host
        {
            get => TB_host.Text;
            set => TB_host.Text = value;
        }

        public string User
        {
            get => TB_user.Text;
            set => TB_user.Text = value;
        }

        public string Password
        {
            get => TB_password.Text;
            set => TB_password.Text = value;
        }

        public string Protocol
        {
            get => CBB_protocol.SelectedItem?.ToString() ?? "";
            set => CBB_protocol.SelectedItem = value;
        }

        public string PortNumber
        {
            get => TB_portNumber.Text;
            set => TB_portNumber.Text = value;
        }

        public string LocalDownloadDestination
        {
            get => TB_localDestinationDownload.Text;
            set => TB_localDestinationDownload.Text = value;
        }

        public string WinscpDLLPath
        {
            get => TB_winscpDLL.Text;
            set => TB_winscpDLL.Text = value;
        }

        public string RemoteFolderScan
        {
            get => TB_severScan.Text;
            set => TB_severScan.Text = value;
        }

        public string MaxThreadScan
        {
            get => TB_maxThread.Text;
            set => TB_maxThread.Text = value;
        }

        public string MacFilePath
        {
            get => TB_MacFilePath.Text;
            set => TB_MacFilePath.Text = value;
        }

        public bool IsLocalScanMode
        {
            get => CB_LocalScan.Checked;
            set => CB_LocalScan.Checked = value;
        }

        public bool ShowPassword
        {
            get => CB_showPass.Checked;
            set => CB_showPass.Checked = value;
        }


        public void ShowMessage(string message, string title, MessageType type)
        {
            MessageBoxIcon icon = type switch
            {
                MessageType.Information => MessageBoxIcon.Information,
                MessageType.Warning => MessageBoxIcon.Warning,
                MessageType.Error => MessageBoxIcon.Error,
                _ => MessageBoxIcon.None
            };

            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void SetRemoteFolderLabel(string text)
        {
            label11.Text = text;
        }

        public void EnableControls(bool enabled)
        {

        }

        public event EventHandler SaveFormInfoClicked;
        public event EventHandler StartScanLogClicked;
        public event EventHandler BrowseLocalFolderClicked;
        public event EventHandler BrowseWinscpDllClicked;
        public event EventHandler BrowseMacFileClicked;
        public event EventHandler LocalScanModeChanged;
        public event EventHandler ShowPasswordChanged;



        private void OnBrowseLocalFolder(object sender, EventArgs e)
        {
            if (FBD_localDesDownLoad.ShowDialog() == DialogResult.OK)
            {
                LocalDownloadDestination = FBD_localDesDownLoad.SelectedPath;
                BrowseLocalFolderClicked?.Invoke(this, EventArgs.Empty);
            }
        }


        private void OnBrowseWinscpDll(object sender, EventArgs e)
        {
            OFD_winscpDLL_File.Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*";
            OFD_winscpDLL_File.Title = "Chọn WinscpDLL file";

            if (OFD_winscpDLL_File.ShowDialog() == DialogResult.OK)
            {
                WinscpDLLPath = OFD_winscpDLL_File.FileName;
                BrowseWinscpDllClicked?.Invoke(this, EventArgs.Empty);
            }
        }


        private void OnBrowseMacFile(object sender, EventArgs e)
        {
            OFD_macFilePath.Filter = "Tất cả các file (*.*)|*.*";
            OFD_macFilePath.Title = "Chọn file MAC";

            if (OFD_macFilePath.ShowDialog() == DialogResult.OK)
            {
                MacFilePath = OFD_macFilePath.FileName;
                BrowseMacFileClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnLocalScanModeChanged(object sender, EventArgs e)
        {
            LocalScanModeChanged?.Invoke(sender, e);
        }


        private void OnShowPasswordChanged(object sender, EventArgs e)
        {
            TB_password.UseSystemPasswordChar = !ShowPassword;
            ShowPasswordChanged?.Invoke(sender, e);
        }


        private void OnRemoteFolderScanClick(object sender, EventArgs e)
        {
            List<string> currentPaths = RemoteFolderScan
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToList();


            Form2 f2 = new Form2(currentPaths);
            f2.PathsSaved += (paths) => _presenter.UpdateRemoteFolderPaths(paths);
            f2.ShowDialog();
        }


        private void TB_portNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void TB_maxThread_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}