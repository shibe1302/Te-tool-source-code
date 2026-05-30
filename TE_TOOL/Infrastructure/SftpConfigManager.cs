using TE_TOOL.Infrastructure;

namespace TE_TOOL.Services
{
    /// <summary>
    /// Quản lý vòng đời của SftpSyncConfig:
    ///   - Load khi khởi động
    ///   - Expose instance dùng chung (singleton nhẹ)
    ///   - Save khi người dùng bấm lưu trong UI settings
    /// </summary>
    public static class SftpConfigManager
    {
        private static SftpSyncConfig? _instance;
        private static string? _loadedPath;

        // ── Instance dùng chung toàn app ──────────────────────────────────
        public static SftpSyncConfig Current
        {
            get
            {
                if (_instance == null) Load();
                return _instance!;
            }
        }

        // ── Load (gọi lúc khởi động app hoặc sau khi người dùng đổi đường dẫn) ──
        public static SftpSyncConfig Load(string? configPath = null)
        {
            _loadedPath = configPath ?? SftpSyncConfig.DefaultConfigPath;
            _instance = SftpSyncConfig.Load(_loadedPath);
            return _instance;
        }

        // ── Save (gọi sau khi người dùng chỉnh sửa trên UI) ──────────────
        public static void Save() => _instance?.Save(_loadedPath);

        // ── Reload: đọc lại từ file (discard thay đổi chưa save) ──────────
        public static SftpSyncConfig Reload() => Load(_loadedPath);

        // ── Đường dẫn file đang dùng ──────────────────────────────────────
        public static string ConfigFilePath =>
            _loadedPath ?? SftpSyncConfig.DefaultConfigPath;
    }
}