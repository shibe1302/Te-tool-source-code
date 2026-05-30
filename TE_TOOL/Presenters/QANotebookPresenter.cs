using TE_TOOL.Models;
using TE_TOOL.Services;
using TE_TOOL.Views._06_tab_Switch_GPT;

namespace TE_TOOL.Presenters
{
    public class QANotebookPresenter
    {
        private readonly IQANotebookView _view;
        private readonly DatabaseService _db;
        private readonly SftpSyncService _sync;
        private readonly string _localDbPath;

        private List<QAItem> _currentResults = new();
        private int _remainingSeconds = 20 * 60;
        private bool _isSyncing = false;   // Guard: tránh spam
        private bool _isExpired = false; // Guard: tránh hiện nhiều MessageBox khi hết giờ

        // ─────────────────────────────────────────────────────────────────
        public QANotebookPresenter(
            IQANotebookView view,
            DatabaseService db,
            SftpSyncService sync,
            string localDbPath)
        {
            _view = view;
            _db = db;
            _sync = sync;
            _localDbPath = localDbPath;

            // Đăng ký sự kiện từ View
            _view.SearchTextChanged += OnSearchTextChanged;
            _view.SearchExecuted += OnSearchExecuted;
            _view.ItemSelected += OnItemSelected;
            _view.AddClicked += OnAddClicked;
            _view.EditClicked += OnEditClicked;
            _view.DeleteClicked += OnDeleteClicked;
            _view.ImportClicked += OnImportClicked;
            _view.TimerTicked += OnTimerTicked;
            _view.ViewLoaded += OnViewLoaded;     // auto-check khi khởi động
            _view.SyncClicked += OnSyncClicked;    // manual sync

            LoadAllData();
        }

        // ── Data ──────────────────────────────────────────────────────────
        private void LoadAllData()
        {
            var items = _db.GetAll();
            DisplayItems(items);
        }

        private void DisplayItems(List<QAItem> items)
        {
            _currentResults = items;
            var previews = items.Select(q =>
                q.Question.Length > 80 ? q.Question[..80] + "..." : q.Question).ToList();
            _view.DisplayResults(previews);
            _view.StatusMessage = $"Tìm thấy {items.Count} kết quả";
        }

        // ── Search ────────────────────────────────────────────────────────
        private async void OnSearchTextChanged(object sender, EventArgs e)
        {
            string snap = _view.SearchQuery;
            await Task.Delay(300);
            if (_view.SearchQuery == snap) SearchAndDisplay(snap);
        }

        private void OnSearchExecuted(object sender, EventArgs e) =>
            SearchAndDisplay(_view.SearchQuery);

        private void SearchAndDisplay(string query)
        {
            var results = _db.Search(query, topN: 20);
            DisplayItems(results);
        }

        private void OnItemSelected(object sender, EventArgs e)
        {
            int idx = _view.SelectedIndex;
            if (idx < 0 || idx >= _currentResults.Count) return;
            var item = _currentResults[idx];
            _view.DisplayAnswer(item.Question, item.Answer, item.Tags);
        }

        // ── CRUD ──────────────────────────────────────────────────────────
        private async void OnAddClicked(object sender, EventArgs e)
        {
            var result = _view.ShowAddEditDialog();
            if (!result.IsOk) return;

            _db.AddQA(result.Question, result.Answer, result.Tags);
            SearchAndDisplay(_view.SearchQuery);
            _view.StatusMessage = "✅ Đã thêm! Đang đồng bộ lên server...";

            // Auto-upload sau khi thêm mới
            await PerformUploadAsync();
        }

        private void OnEditClicked(object sender, EventArgs e)
        {
            int idx = _view.SelectedIndex;
            if (idx < 0 || idx >= _currentResults.Count)
            {
                _view.ShowMessageBox("Vui lòng chọn một câu hỏi để sửa!", "Thông báo");
                return;
            }
            var item = _currentResults[idx];
            var result = _view.ShowAddEditDialog(item);
            if (!result.IsOk) return;

            _db.UpdateQA(item.Id, result.Question, result.Answer, result.Tags);
            SearchAndDisplay(_view.SearchQuery);
            _view.StatusMessage = "✅ Đã cập nhật thành công!";
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            int idx = _view.SelectedIndex;
            if (idx < 0 || idx >= _currentResults.Count) return;

            var item = _currentResults[idx];
            if (!_view.ConfirmAction($"Xoá câu hỏi:\n{item.Question}?", "Xác nhận xóa")) return;

            _db.DeleteQA(item.Id);
            SearchAndDisplay(_view.SearchQuery);
            _view.StatusMessage = "❌ Đã xóa thành công!";
        }

        private void OnImportClicked(object sender, EventArgs e)
        {
            string filePath = _view.ShowOpenFileDialog();
            if (string.IsNullOrEmpty(filePath)) return;
            if (!_view.ConfirmAction($"Import dữ liệu từ:\n{filePath}\n\nTiếp tục?", "Xác nhận Import")) return;

            try
            {
                _view.StatusMessage = "⏳ Đang import...";
                var (success, failed) = _db.ImportFromCsv(filePath);
                SearchAndDisplay(_view.SearchQuery);
                _view.ShowMessageBox(
                    $"✅ Import hoàn tất!\n\n• Thành công: {success} bản ghi\n• Lỗi/bỏ qua: {failed} dòng",
                    "Kết quả Import");
                _view.StatusMessage = $"✅ Đã import {success} câu hỏi";
            }
            catch (Exception ex)
            {
                _view.ShowMessageBox($"❌ Lỗi khi import:\n{ex.Message}", "Lỗi", isError: true);
                _view.StatusMessage = "❌ Import thất bại";
            }
        }

        // ── Timer ─────────────────────────────────────────────────────────
        private void OnTimerTicked(object sender, EventArgs e)
        {
            if (_isExpired) return;   // ← chặn ngay nếu đã xử lý rồi

            _remainingSeconds--;
            if (_remainingSeconds <= 0)
            {
                _isExpired = true;    // ← set trước khi ShowMessageBox
                _view.ShowMessageBox("Phiên làm việc đã hết hạn. Ứng dụng sẽ đóng.", "Thông báo");
                _view.CloseView();
                return;
            }

            var t = TimeSpan.FromSeconds(_remainingSeconds);
            _view.CountdownText = $"{t.Minutes:D2}:{t.Seconds:D2}";
            if (_remainingSeconds <= 60) _view.CountdownColor = Color.Red;
        }

        // ── Sync: auto khi khởi động ──────────────────────────────────────
        private async void OnViewLoaded(object sender, EventArgs e)
        {
            try
            {
                _view.StatusMessage = "🔍 Đang kiểm tra cập nhật từ server...";
                int localCount = _db.GetAll().Count;                                      // thêm dòng này
                var checkResult = await _sync.CheckForUpdateAsync(_localDbPath, localCount); // thêm localCount

                switch (checkResult)
                {
                    case SyncCheckResult.ServerNewer:
                        _view.StatusMessage = "🔄 Phát hiện bản mới — đang tải về...";
                        await PerformDownloadAsync(silent: true);
                        break;
                    case SyncCheckResult.UpToDate:
                        _view.StatusMessage = "✅ DB đã là phiên bản mới nhất";
                        break;
                    case SyncCheckResult.ServerSmaller:
                        _view.StatusMessage = "⚠️ Server nghi bị lỗi (file nhỏ hơn local) — bỏ qua";
                        break;
                    case SyncCheckResult.NoMetadata:
                    case SyncCheckResult.NetworkError:
                        _view.StatusMessage = "⚠️ Không thể kết nối server — chạy offline";
                        break;
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessageBox($"❌ Lỗi kết nối server:\n{ex.Message}", "Lỗi", isError: true);
                _view.StatusMessage = $"⚠️ Không thể kết nối server — chạy offline";
            }

        }

        // ── Sync: manual bấm nút Update ──────────────────────────────────
        private async void OnSyncClicked(object sender, EventArgs e)
        {
            if (_isSyncing) return;
            try
            {
                _view.StatusMessage = "🔍 Đang kiểm tra server...";
                int localCount = _db.GetAll().Count;                                      // thêm dòng này
                var checkResult = await _sync.CheckForUpdateAsync(_localDbPath, localCount); // thêm localCount

                switch (checkResult)
                {
                    case SyncCheckResult.ServerNewer:
                        await PerformDownloadAsync(silent: false);
                        break;
                    case SyncCheckResult.UpToDate:
                        _view.StatusMessage = "✅ Đã là phiên bản mới nhất — không cần cập nhật!";
                        break;
                    case SyncCheckResult.ServerSmaller:
                        _view.ShowMessageBox(
                            "⚠️ File DB trên server nhỏ hơn local!\n\nCó thể server đang bị lỗi hoặc bị thay file xấu.\nBỏ qua để bảo toàn dữ liệu.",
                            "Cảnh báo an toàn");
                        _view.StatusMessage = "⚠️ Từ chối cập nhật: server nghi bị lỗi";
                        break;
                    case SyncCheckResult.NoMetadata:
                        _view.StatusMessage = "ℹ️ Server chưa có data — chưa ai upload lần nào";
                        break;
                    case SyncCheckResult.NetworkError:
                        _view.StatusMessage = "❌ Không thể kết nối server";
                        break;
                }
            }
            catch (Exception ex)
            {

                _view.ShowMessageBox($"❌ Lỗi kết nối server:\n{ex.Message}", "Lỗi", isError: true);
                _view.StatusMessage = "❌ Không thể kết nối server";
            }

        }

        // ── Shared: thực hiện download ────────────────────────────────────
        /// <param name="silent">true = auto startup (không hỏi), false = manual (hiện thông báo xong)</param>
        private async Task PerformDownloadAsync(bool silent = false)
        {
            if (_isSyncing) return;
            _isSyncing = true;
            _view.SetUpdateButtonEnabled(false);
            _view.SetProgressVisible(true);
            _view.SetProgress(0);

            try
            {
                var progress = new Progress<int>(p =>
                {
                    _view.SetProgress(p);
                    _view.StatusMessage = $"⏳ Đang tải về... {p}%";
                });

                // ✅ BƯỚC 1: Đóng DB trước khi download để giải phóng file lock
                _db.CheckpointAndClose();

                // ✅ BƯỚC 2: Download (ghi vào .tmp rồi atomic swap — logic đã có trong SftpSyncService)
                await _sync.DownloadDatabaseAsync(_localDbPath, progress);

                

                // ✅ BƯỚC 4: Reload data lên View
                LoadAllData();
                _view.StatusMessage = "✅ Cập nhật DB thành công!";

                if (!silent)
                    _view.ShowMessageBox("✅ Cập nhật DB thành công!", "Sync");
            }
            catch (Exception ex)
            {

                
                _view.ShowMessageBox($"❌ Lỗi khi tải về:\n{ex.Message}", "Lỗi", isError: true);
                _view.StatusMessage = "❌ Cập nhật thất bại";
            }
            finally
            {
                _isSyncing = false;
                _view.SetUpdateButtonEnabled(true);
                _view.SetProgressVisible(false);
            }
        }

        // ── Shared: thực hiện upload ──────────────────────────────────────
        private async Task PerformUploadAsync()
        {
            if (_isSyncing) return;
            _isSyncing = true;
            _view.SetUpdateButtonEnabled(false);
            _view.SetProgressVisible(true);
            _view.SetProgress(0);

            try
            {
                int recordCount = _db.GetAll(int.MaxValue).Count;
                _db.CheckpointAndClose();
                var progress = new Progress<int>(p =>
                {
                    _view.SetProgress(p);
                    _view.StatusMessage = $"⏳ Đang upload... {p}%";
                });

                await _sync.UploadDatabaseAsync(
                    _localDbPath,
                    uploaderMachine: Environment.MachineName,
                    recordCount: recordCount,
                    progress: progress);

                _view.StatusMessage = "✅ Đã thêm & đồng bộ lên server thành công!";
            }
            catch (Exception ex)
            {
                _view.ShowMessageBox(
                    $"⚠️ Đã lưu local nhưng upload server thất bại:\n{ex.Message}",
                    "Cảnh báo upload");
                _view.StatusMessage = "⚠️ Lưu local OK — upload server thất bại";
            }
            finally
            {
                _isSyncing = false;
                _view.SetUpdateButtonEnabled(true);
                _view.SetProgressVisible(false);
            }
        }
    }
}