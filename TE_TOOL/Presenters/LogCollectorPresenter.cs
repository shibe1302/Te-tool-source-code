
using System;
using System.Collections.Generic;
using System.Linq;
using TE_TOOL.Models;
using TE_TOOL.Services;
using TE_TOOL.Views._02_tab_thu_thap_log;

namespace TE_TOOL.Presenters
{

    public class LogCollectorPresenter
    {
        private readonly ILogCollectorView _view;
        private readonly LogCollectorService _service;
        private readonly string _configPath;
        private List<string> _remoteFolderPaths;

        public LogCollectorPresenter(ILogCollectorView view, LogCollectorService service, string configPath)
        {
            _view = view;
            _service = service;
            _configPath = configPath;
            _remoteFolderPaths = new List<string>();

            // Subscribe to View events
            SubscribeToViewEvents();

            // Load initial configuration
            LoadConfiguration();
        }


        private void SubscribeToViewEvents()
        {
            _view.SaveFormInfoClicked += OnSaveFormInfo;
            _view.StartScanLogClicked += OnStartScanLog;
            _view.LocalScanModeChanged += OnLocalScanModeChanged;
            _view.ShowPasswordChanged += OnShowPasswordChanged;
        }


        private void LoadConfiguration()
        {
            try
            {
                var data = _service.LoadConfiguration(_configPath);
                PopulateView(data);
                _remoteFolderPaths = data.RemoteFolderPaths;
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi khi load cấu hình: {ex.Message}", "Lỗi", MessageType.Error);
            }
        }


        private void PopulateView(LogCollectorFormData data)
        {
            _view.Host = data.Host;
            _view.User = data.User;
            _view.Password = data.Password;
            _view.Protocol = data.Protocol;
            _view.PortNumber = data.PortNumber.ToString();
            _view.LocalDownloadDestination = data.LocalDownloadDestination;
            _view.WinscpDLLPath = data.WinscpDLLPath;
            _view.RemoteFolderScan = string.Join(";", data.RemoteFolderPaths);
            _view.MaxThreadScan = data.MaxThreadScan.ToString();
            _view.MacFilePath = data.MacFilePath;
            _view.IsLocalScanMode = data.IsLocalScanMode;

            UpdateRemoteFolderLabel(data.IsLocalScanMode);
        }

        private LogCollectorFormData GetFormData()
        {
            // Parse remote folder paths nếu list rỗng
            if (_remoteFolderPaths.Count == 0 && !string.IsNullOrWhiteSpace(_view.RemoteFolderScan))
            {
                _remoteFolderPaths = _view.RemoteFolderScan
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim().TrimEnd('\\'))
                    .ToList();
            }

            return new LogCollectorFormData
            {
                Host = _view.Host,
                User = _view.User,
                Password = _view.Password,
                Protocol = _view.Protocol,
                PortNumber = int.TryParse(_view.PortNumber, out int port) ? port : 0,
                LocalDownloadDestination = _view.LocalDownloadDestination,
                WinscpDLLPath = _view.WinscpDLLPath,
                RemoteFolderPaths = _remoteFolderPaths,
                MaxThreadScan = int.TryParse(_view.MaxThreadScan, out int maxThread) ? maxThread : 1,
                MacFilePath = _view.MacFilePath,
                IsLocalScanMode = _view.IsLocalScanMode
            };
        }


        private void OnSaveFormInfo(object sender, EventArgs e)
        {
            try
            {
                var data = GetFormData();
                var validation = _service.ValidateFormData(data);

                if (!validation.IsValid)
                {
                    _view.ShowMessage(validation.ErrorMessage, "Lỗi", MessageType.Warning);
                    return;
                }

                _service.SaveConfiguration(_configPath, data);
                _view.ShowMessage("Đã lưu cấu hình thành công!", "Thông báo", MessageType.Information);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lưu cấu hình thất bại!\nChi tiết: {ex.Message}", "Lỗi", MessageType.Error);
            }
        }

        private void OnStartScanLog(object sender, EventArgs e)
        {
            try
            {
                var data = GetFormData();
                var validation = _service.ValidateFormData(data);

                if (!validation.IsValid)
                {
                    _view.ShowMessage(validation.ErrorMessage, "Thiếu cấu hình", MessageType.Warning);
                    return;
                }

                // Lưu cấu hình trước khi chạy
                _service.SaveConfiguration(_configPath, data);

                // Chạy script
                string scriptBasePath = AppDomain.CurrentDomain.BaseDirectory;
                _service.ExecuteScanProcess(data, scriptBasePath);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Không thể chạy script!\nChi tiết: {ex.Message}", "Lỗi", MessageType.Error);
            }
        }

 
        private void OnLocalScanModeChanged(object sender, EventArgs e)
        {
            UpdateRemoteFolderLabel(_view.IsLocalScanMode);
        }


        private void UpdateRemoteFolderLabel(bool isLocalMode)
        {
            _view.SetRemoteFolderLabel(isLocalMode ? "Local folder scan" : "Remote folder scan");
        }


        private void OnShowPasswordChanged(object sender, EventArgs e)
        {
            // View tự xử lý, không cần logic ở đây
        }

        public void UpdateRemoteFolderPaths(List<string> paths)
        {
            _remoteFolderPaths = paths.Select(p => p.TrimEnd('\\')).ToList();
            _view.RemoteFolderScan = string.Join(";", paths);
        }
    }
}