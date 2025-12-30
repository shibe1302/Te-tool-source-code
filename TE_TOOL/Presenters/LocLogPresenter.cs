using System;
using System.Drawing;
using TE_TOOL.Services;
using TE_TOOL.Views._01_tab_loc_log;

namespace TE_TOOL.Presenters
{
    /// <summary>
    /// Presenter trong mô hình MVP
    /// - Là "người trung gian" giữa View và Model (Service)
    /// - Chứa TẤT CẢ business logic
    /// - Subscribe vào events từ View
    /// - Gọi Service để xử lý data
    /// - Update View thông qua Interface methods
    /// 
    /// LUỒNG HOẠT ĐỘNG:
    /// User click button → View raise event → Presenter xử lý 
    /// → Presenter gọi Service → Service trả kết quả 
    /// → Presenter cập nhật View
    /// </summary>
    internal class LocLogPresenter
    {
        // ===========================================
        // FIELDS
        // ===========================================
        private readonly ILocLogView _view;
        private readonly LocLogService _service;

        // ===========================================
        // CONSTRUCTOR - Dependency Injection
        // ===========================================

        /// <summary>
        /// Constructor nhận View và Service qua DI
        /// Đây là cách làm chuẩn của Clean Architecture
        /// </summary>
        /// <param name="view">View implement ILocLogView</param>
        /// <param name="service">Service xử lý business logic</param>
        public LocLogPresenter(ILocLogView view, LocLogService service)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _service = service ?? throw new ArgumentNullException(nameof(service));

            // Subscribe vào các events từ View
            SubscribeToViewEvents();
        }

        // ===========================================
        // PRIVATE METHODS - Event Handlers
        // ===========================================

        /// <summary>
        /// Đăng ký lắng nghe các events từ View
        /// Khi View raise event, Presenter sẽ xử lý
        /// </summary>
        private void SubscribeToViewEvents()
        {
            _view.RunScriptClicked += OnRunScriptClicked;
            _view.OpenMacFileClicked += OnOpenMacFileClicked;
            _view.LogPathDropped += OnLogPathDropped;
        }

        /// <summary>
        /// Xử lý khi user click nút "Run Script"
        /// ĐÂY LÀ NƠI CHỨA TẤT CẢ BUSINESS LOGIC
        /// </summary>
        private void OnRunScriptClicked(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu từ View
                string filePath = _view.LogPathInput;
                string macPath = _view.MacPathInput; 

                // 2. Validate input bằng Service
                if (!_service.ValidateFilePath(filePath))
                {
                    _view.ShowWarning(
                        "Vui lòng nhập đường dẫn hợp lệ!\n\n" +
                        "Bạn có thể:\n" +
                        "- Nhập đường dẫn vào ô text\n" +
                        "- Kéo thả file/folder vào đây"
                    );
                    return;
                }

                // 3. Kiểm tra script có tồn tại không
                if (!_service.CheckScriptExists())
                {
                    _view.ShowError(
                        $"Không tìm thấy PowerShell script!\n\n" +
                        $"Đường dẫn: {_service.GetScriptPath()}"
                    );
                    return;
                }

                // 4. Disable nút Run để tránh click nhiều lần
                _view.SetRunButtonEnabled(false);
                _view.SetStatus("Đang chạy script...", Color.Blue);

                // 5. Gọi Service để chạy script
                if (_view.modeLog == "Old format")
                {
                    _service.RunFilterScriptOldFormat(filePath, macPath);
                }
                else {
                    _service.RunFilterScript(filePath, macPath);
                }
                    

                // 6. Thông báo thành công
                _view.SetStatus(
                    "Script đã được chạy! Kiểm tra cửa sổ PowerShell.",
                    Color.Green
                );
                
            }
            catch (Exception ex)
            {
                // 7. Xử lý lỗi và hiển thị cho user
                _view.ShowError($"Lỗi khi chạy script:\n{ex.Message}");
                _view.SetStatus("Lỗi!", Color.Red);
            }
            finally
            {
                // 8. Luôn enable lại nút Run
                _view.SetRunButtonEnabled(true);
            }
        }

        /// <summary>
        /// Xử lý khi user drag-drop file
        /// Presenter validate và hiển thị tên file
        /// </summary>
        private void OnLogPathDropped(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy đường dẫn từ View
                string filePath = _view.LogPathInput;

                // 2. Validate
                if (!_service.ValidateFilePath(filePath))
                {
                    _view.SetStatus("Đường dẫn không hợp lệ!", Color.Red);
                    return;
                }

                // 3. Lấy display name và hiển thị
                string displayName = _service.GetDisplayName(filePath);
                _view.SetStatus($"Đã chọn: {displayName}", Color.Green);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi khi xử lý file: {ex.Message}");
                _view.SetStatus("Lỗi!", Color.Red);
            }
        }

        /// <summary>
        /// Xử lý khi user click "Open MAC File"
        /// Để dành cho tương lai
        /// </summary>
        private void OnOpenMacFileClicked(object sender, EventArgs e)
        {
            // TODO: Implement logic mở MAC file
            _view.ShowInfo("Tính năng đang được phát triển");
        }

        // ===========================================
        // PUBLIC METHODS - Các methods tiện ích
        // ===========================================

        /// <summary>
        /// Reset form về trạng thái ban đầu
        /// Method này có thể được gọi từ bên ngoài
        /// </summary>
        public void ResetForm()
        {
            _view.ClearForm();
            _view.SetStatus("Sẵn sàng", Color.Black);
        }

        /// <summary>
        /// Unsubscribe khỏi View events khi dispose
        /// Tránh memory leak
        /// </summary>
        public void Dispose()
        {
            _view.RunScriptClicked -= OnRunScriptClicked;
            _view.OpenMacFileClicked -= OnOpenMacFileClicked;
            _view.LogPathDropped -= OnLogPathDropped;
        }
    }
}