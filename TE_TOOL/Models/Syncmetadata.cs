using System.Text.Json.Serialization;

namespace TE_TOOL.Models
{
    /// <summary>
    /// File meta.json trên server — dùng để so sánh trước khi download.
    /// Chỉ cần size là đủ cho safety-check (data chỉ tăng, không giảm).
    /// </summary>
    public class SyncMetadata
    {
        [JsonPropertyName("fileSizeBytes")]
        public long FileSizeBytes { get; set; }

        [JsonPropertyName("lastModifiedUtc")]
        public DateTime LastModifiedUtc { get; set; }

        [JsonPropertyName("uploader")]
        public string Uploader { get; set; } = "";

        [JsonPropertyName("recordCount")]
        public int RecordCount { get; set; }   // Thông tin thêm để log
    }
}