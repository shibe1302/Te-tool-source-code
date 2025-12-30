using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TE_TOOL.Services
{
    public class CopyFtuServices : ICopyFtuServices
    {
        string txtListFunctionTest = "";
        List<string> listItemTest = new List<string>();
        JsonElement tempItems;
        List<JsonElement> tempItemsList;

        public string TxtListFunctionTest { get => txtListFunctionTest; set => txtListFunctionTest = value; }
        public List<string> ListItemTest { get => listItemTest; set => listItemTest = value; }

        public List<string> GetFunctionTest(string content)
        {
            Debug.WriteLine("GetFunctionTest in Service called");
            string logContent = GetContentInRange(content);
            if (logContent == "")
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
            List<string> listItem = result.Split(", ").ToList();
            return listItem;

        }


        bool FindAndSwapItems(int currentIndex, int value)
        {
            for (int i = currentIndex; i < tempItemsList.Count; i++)
            {
                int id = tempItemsList[i].GetProperty("ID").GetInt32();
                string name = tempItemsList[i].GetProperty("Name").GetString();
                if (id == value)
                {
                    if (i != currentIndex)
                    {
                        SwapItemsInList(currentIndex, i);
                    }
                    return true;
                }
                if (i== tempItemsList.Count-1)
                {
                    MessageBox.Show($"Không tìm thấy item: {value}", "Lỗi khi ghi file JSON", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }


        void SwapItemsInList( int idx1, int idx2)
        {
            if (idx1 < 0 || idx2 < 0 || idx1 >= tempItemsList.Count || idx2 >= tempItemsList.Count)
                throw new IndexOutOfRangeException();
            (tempItemsList[idx1], tempItemsList[idx2]) = (tempItemsList[idx2], tempItemsList[idx1]);
        }


        public JsonElement LoadJsonOrderItems(string pathFile,string ItemsTxt)
        {
            
            try
            {
                using JsonDocument doc = JsonDocument.Parse(File.ReadAllText(pathFile));
                JsonElement root = doc.RootElement;
                JsonElement items = root.GetProperty("DiagTestItems").Clone();
                tempItemsList = items.EnumerateArray().ToList();
                return items;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Kiểm tra lại file json !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new JsonElement();
            }

        }

        JsonElement ConvertListToJsonElement()
        {
            string json = JsonSerializer.Serialize(tempItemsList);
            using JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement.Clone();
        }

        JsonElement ICopyFtuServices.ReorderJsonItem(string itemsFromLog)
        {
            if (tempItemsList == null)
            {
                MessageBox.Show("Danh sách rỗng, không thể xử lý!");
                return default(JsonElement);
            }

            List<string> listItem = itemsFromLog.Split(",").Select(x => x.Trim()).ToList();
            for (int i = 0; i < listItem.Count; i++)
            {
                FindAndSwapItems(i, int.Parse(listItem[i]));
            }
            return ConvertListToJsonElement();
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

                // Kiểm tra file tồn tại
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

                using JsonDocument doc = JsonDocument.Parse(File.ReadAllText(pathFile));
                JsonElement root = doc.RootElement;
                var rootDict = JsonSerializer.Deserialize<Dictionary<string, object>>(root.GetRawText());

                if (rootDict == null)
                {
                    MessageBox.Show(
                        "Không thể đọc dữ liệu JSON từ file!",
                        "Lỗi đọc JSON",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                rootDict["DiagTestItems"] = tempItemsList;

                string updatedJson = JsonSerializer.Serialize(rootDict, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(pathFile, updatedJson);

                
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
            var targetPath= Path.Combine(rootDir, "data", "config_files");
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
