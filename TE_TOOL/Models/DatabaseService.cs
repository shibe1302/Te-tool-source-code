using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace TE_TOOL.Models
{
    public class QAItem
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Tags { get; set; }
    }
    public class DatabaseService
    {
        private readonly string _connectionString;

        private const string DB_PASSWORD = "Your_Internal_Secret_Key_2026";

        public DatabaseService(string dbPath)
        {
            _connectionString = $"Data Source={dbPath};Password={DB_PASSWORD}";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            // Bảng chính lưu dữ liệu gốc
            conn.Execute(@"
            CREATE TABLE IF NOT EXISTS qa_items (
                id      INTEGER PRIMARY KEY AUTOINCREMENT,
                question TEXT NOT NULL,
                answer   TEXT NOT NULL,
                tags     TEXT
            )");

            // Bảng FTS5 để full-text search (dùng BM25)
            conn.Execute(@"
            CREATE VIRTUAL TABLE IF NOT EXISTS qa_fts 
            USING fts5(
                question, 
                answer, 
                tags,
                content='qa_items',
                content_rowid='id',
                tokenize='unicode61'   -- hỗ trợ tiếng Việt có dấu
            )");

            // Trigger để tự đồng bộ FTS khi thêm/sửa/xoá
            conn.Execute(@"
            CREATE TRIGGER IF NOT EXISTS qa_ai AFTER INSERT ON qa_items BEGIN
                INSERT INTO qa_fts(rowid, question, answer, tags) 
                VALUES (new.id, new.question, new.answer, new.tags);
            END");

            conn.Execute(@"
            CREATE TRIGGER IF NOT EXISTS qa_ad AFTER DELETE ON qa_items BEGIN
                INSERT INTO qa_fts(qa_fts, rowid, question, answer, tags) 
                VALUES ('delete', old.id, old.question, old.answer, old.tags);
            END");

            conn.Execute(@"
            CREATE TRIGGER IF NOT EXISTS qa_au AFTER UPDATE ON qa_items BEGIN
                INSERT INTO qa_fts(qa_fts, rowid, question, answer, tags) 
                VALUES ('delete', old.id, old.question, old.answer, old.tags);
                INSERT INTO qa_fts(rowid, question, answer, tags) 
                VALUES (new.id, new.question, new.answer, new.tags);
            END");
        }

        // ✅ Thêm câu hỏi mới
        public void AddQA(string question, string answer, string tags = "")
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            conn.Execute(
                "INSERT INTO qa_items (question, answer, tags) VALUES (@q, @a, @t)",
                new { q = question, a = answer, t = tags });
        }

        // 🔍 Tìm kiếm theo FTS5 + sắp xếp theo BM25 score
        public List<QAItem> Search(string query, int topN = 10)
        {
            if (string.IsNullOrWhiteSpace(query)) return GetAll(topN);

            // Chuẩn bị query FTS: mỗi từ thêm * để prefix-match
            var ftsQuery = string.Join(" OR ",
                query.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(w => $"\"{w}\"*"));

            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            return conn.Query<QAItem>(@"
            SELECT q.id, q.question, q.answer, q.tags
            FROM qa_fts f
            JOIN qa_items q ON q.id = f.rowid
            WHERE qa_fts MATCH @query
            ORDER BY rank         -- rank = BM25, giá trị âm, nhỏ hơn = liên quan hơn
            LIMIT @topN",
                new { query = ftsQuery, topN })
                .ToList();
        }

        public List<QAItem> GetAll(int limit = 50)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            return conn.Query<QAItem>(
                "SELECT id, question, answer, tags FROM qa_items ORDER BY id DESC LIMIT @limit",
                new { limit }).ToList();
        }
        public void UpdateQA(int id, string question, string answer, string tags = "")
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            conn.Execute(@"
        UPDATE qa_items 
        SET question = @q, answer = @a, tags = @t 
        WHERE id = @id",
                new { q = question, a = answer, t = tags, id = id });
        }

        public void DeleteQA(int id)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            conn.Execute("DELETE FROM qa_items WHERE id = @id", new { id });
        }

        // Tiện ích: thực thi không trả về dữ liệu
        private void Execute(SqliteConnection conn, string sql, object param = null)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Flush WAL và giải phóng lock để file có thể được copy/upload.
        /// Gọi trước khi upload file .db lên server.
        /// </summary>
        public void CheckpointAndClose()
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            conn.Execute("PRAGMA wal_checkpoint(TRUNCATE);");
            conn.Close();

            // ✅ Force giải phóng tất cả connection pool của Microsoft.Data.Sqlite
            // Không có dòng này thì Windows vẫn giữ file handle dù conn đã Close()
            SqliteConnection.ClearAllPools();
        }
        
        public (int success, int failed) ImportFromCsv(string csvPath)
        {
            int success = 0, failed = 0;
            var lines = File.ReadAllLines(csvPath, Encoding.UTF8);

            // Bỏ qua dòng header (dòng đầu tiên)
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');
                if (parts.Length >= 2 &&
                    !string.IsNullOrWhiteSpace(parts[0]) &&
                    !string.IsNullOrWhiteSpace(parts[1]))
                {
                    AddQA(
                        parts[0].Trim(),
                        parts[1].Trim(),
                        parts.Length > 2 ? parts[2].Trim() : ""
                    );
                    success++;
                }
                else
                {
                    failed++;
                }
            }

            return (success, failed);
        }
    }
}
