using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace TE_TOOL.Services
{
    public class CopyFtuServices : ICopyFtuServices
    {
        string txtListFunctionTest = "";
        List<string> listItemTest = new List<string>();

        // Giữ nguyên JsonElement thay vì deserialize
        private JsonElement originalRootElement;
        private List<JsonElement> tempItemsList;

        // Cache kiểu dữ liệu ID để bảo toàn
        private Dictionary<int, JsonValueKind> idTypeCache = new Dictionary<int, JsonValueKind>();

        public string TxtListFunctionTest { get => txtListFunctionTest; set => txtListFunctionTest = value; }
        public List<string> ListItemTest { get => listItemTest; set => listItemTest = value; }

        public List<string> GetFunctionTest(string content)
        {
            Debug.WriteLine("GetFunctionTest in Service called");
            string logContent = GetContentInRange(content);
            if (string.IsNullOrEmpty(logContent))
            {
                MessageBox.Show(
                    "Không tìm thấy 'Total Test Items:' ",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
            ListItemTest = GetListItem(logContent);
            return ListItemTest;
        }

        private List<string> GetListItem(string txt)
        {
            string txtStart = "[";
            string txtEnd = "]";
            int startIdx = txt.IndexOf(txtStart);
            int endIdx = txt.IndexOf(txtEnd);

            if (startIdx == -1 || endIdx == -1)
            {
                return null;
            }

            var result = txt.Substring(startIdx + 1, endIdx - startIdx - 1);
            this.TxtListFunctionTest = txt;

            // Tách chuỗi và loại bỏ các ký tự không phải số
            List<string> listItem = result
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(item => item.Trim().Trim('\'', '"')) // Loại bỏ khoảng trắng và dấu ngoặc kép/đơn
                .Where(item => !string.IsNullOrWhiteSpace(item)) // Loại bỏ item rỗng
                .ToList();

            return listItem;
        }

        private string GetContentInRange(string text)
        {
            string textStart = "Total Test Items:";
            int startIndex = text.IndexOf(textStart);

            if (startIndex != -1)
            {
                int endIndex = text.IndexOf('\n', startIndex);
                string result;

                if (endIndex != -1)
                {
                    result = text.Substring(startIndex, endIndex - startIndex);
                }
                else
                {
                    result = text.Substring(startIndex);
                }

                return result.Trim();
            }

            return "";
        }



        // Phương thức helper để lấy ID từ JsonElement (hỗ trợ cả string và int)
        private int GetIdFromJsonElement(JsonElement item)
        {
            JsonElement idElement = item.GetProperty("ID");

            if (idElement.ValueKind == JsonValueKind.Number)
            {
                return idElement.GetInt32();
            }
            else if (idElement.ValueKind == JsonValueKind.String)
            {
                string idStr = idElement.GetString();
                if (int.TryParse(idStr, out int id))
                {
                    return id;
                }
            }

            throw new InvalidOperationException($"Cannot parse ID from element");
        }

        bool FindAndSwapItems(int currentIndex, int value)
        {
            for (int i = currentIndex; i < tempItemsList.Count; i++)
            {
                int id = GetIdFromJsonElement(tempItemsList[i]);

                if (id == value)
                {
                    if (i != currentIndex)
                    {
                        SwapItemsInList(currentIndex, i);
                    }
                    return true;
                }

                if (i == tempItemsList.Count - 1)
                {
                    MessageBox.Show(
                        $"Không tìm thấy item: {value}",
                        "Lỗi khi ghi file JSON",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
            }

            return false;
        }

        void SwapItemsInList(int idx1, int idx2)
        {
            if (idx1 < 0 || idx2 < 0 || idx1 >= tempItemsList.Count || idx2 >= tempItemsList.Count)
                throw new IndexOutOfRangeException();

            (tempItemsList[idx1], tempItemsList[idx2]) = (tempItemsList[idx2], tempItemsList[idx1]);
        }

        public JsonElement LoadJsonOrderItems(string pathFile, string ItemsTxt)
        {
            try
            {
                string jsonContent = File.ReadAllText(pathFile);
                using JsonDocument doc = JsonDocument.Parse(jsonContent);

                // Lưu toàn bộ root element
                originalRootElement = doc.RootElement.Clone();

                JsonElement items = originalRootElement.GetProperty("DiagTestItems");
                tempItemsList = items.EnumerateArray().ToList();

                // Cache kiểu dữ liệu ID
                CacheIdTypes(items);

                return items;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    e.Message,
                    "Kiểm tra lại file json !",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return new JsonElement();
            }
        }

        // Cache kiểu dữ liệu của ID để bảo toàn khi ghi lại
        private void CacheIdTypes(JsonElement items)
        {
            idTypeCache.Clear();

            foreach (var item in items.EnumerateArray())
            {
                JsonElement idElement = item.GetProperty("ID");
                int id = GetIdFromJsonElement(item);
                idTypeCache[id] = idElement.ValueKind;
            }
        }

        public JsonElement ReorderJsonItem(string itemsFromLog)
        {
            if (tempItemsList == null)
            {
                MessageBox.Show("Danh sách rỗng, không thể xử lý!");
                return default(JsonElement);
            }

            List<string> listItem = itemsFromLog.Split(",")
                .Select(x => x.Trim())
                .ToList();

            for (int i = 0; i < listItem.Count; i++)
            {
                FindAndSwapItems(i, int.Parse(listItem[i]));
            }

            // Không convert, giữ nguyên JsonElement
            return default(JsonElement); // Không cần return vì đã swap tại chỗ
        }

        public void SaveFullJsonWithUpdatedItems(string pathFile)
        {
            try
            {
                if (tempItemsList == null)
                {
                    MessageBox.Show(
                        "Dữ liệu DiagTestItems bị null, không thể lưu file!\nVui lòng kiểm tra lại dữ liệu.",
                        "Cảnh báo dữ liệu null",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (string.IsNullOrWhiteSpace(pathFile))
                {
                    MessageBox.Show(
                        "Đường dẫn file không hợp lệ!",
                        "Lỗi đường dẫn",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show(
                        $"File không tồn tại:\n{pathFile}",
                        "Lỗi file không tồn tại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // Sử dụng Utf8JsonWriter để bảo toàn hoàn toàn cấu trúc
                using var stream = new MemoryStream();
                using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
                {
                    Indented = true
                }))
                {
                    writer.WriteStartObject();

                    // Ghi lại tất cả properties của root trừ DiagTestItems
                    foreach (var prop in originalRootElement.EnumerateObject())
                    {
                        if (prop.Name == "DiagTestItems")
                        {
                            // Ghi DiagTestItems đã được reorder
                            writer.WritePropertyName("DiagTestItems");
                            writer.WriteStartArray();

                            foreach (var item in tempItemsList)
                            {
                                // Clone từng item để giữ nguyên 100% cấu trúc
                                item.WriteTo(writer);
                            }

                            writer.WriteEndArray();
                        }
                        else
                        {
                            // Giữ nguyên các properties khác
                            writer.WritePropertyName(prop.Name);
                            prop.Value.WriteTo(writer);
                        }
                    }

                    writer.WriteEndObject();
                }

                // Ghi file
                string jsonOutput = Encoding.UTF8.GetString(stream.ToArray());
                File.WriteAllText(pathFile, jsonOutput);
            }
            catch (JsonException ex)
            {
                MessageBox.Show(
                    $"Lỗi định dạng JSON:\n{ex.Message}",
                    "Lỗi JSON",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    $"Lỗi đọc/ghi file:\n{ex.Message}",
                    "Lỗi file I/O",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi không xác định:\n{ex.Message}",
                    "Lỗi khi ghi file JSON",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        string getRootDir(string fullPath)
        {
            return Path.GetDirectoryName(fullPath);
        }

        string getUniFi(string rootDir)
        {
            var targetPath = Path.Combine(rootDir, "data", "config_files");
            string[] subDirs = Directory.GetDirectories(targetPath);

            if (subDirs.Length == 1)
            {
                string folderName = Path.GetFileName(subDirs[0]);
                return folderName;
            }
            else
            {
                return "";
            }
        }

        string getFileName(string fullPath)
        {
            return Path.GetFileName(fullPath);
        }

        public void RunFtu(string pathFTU)
        {
            if (!File.Exists(pathFTU))
            {
                MessageBox.Show(
                    $"Kiểm tra đường dẫn đến FTU.exe:\n{pathFTU}",
                    "Lỗi file không tồn tại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var rootDir = getRootDir(pathFTU);
            var unifiFolder = getUniFi(rootDir);
            var FTUFileName = getFileName(pathFTU);

            if (string.IsNullOrEmpty(unifiFolder))
            {
                MessageBox.Show(
                    $"Không tìm thấy thư mục UniFiDrive trong:\n{Path.Combine(rootDir, "data", "config_files")}",
                    "Lỗi thư mục UniFiDrive",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.Arguments = $@"/k color b && cd /d ""{rootDir}"" && {FTUFileName} -p={unifiFolder}";
            psi.UseShellExecute = true;
            psi.CreateNoWindow = false;
            psi.WindowStyle = ProcessWindowStyle.Normal;

            Process process = new Process();
            process.StartInfo = psi;

            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi khởi chạy FTU:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}