using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TE_TOOL.Services
{
    public class CopyFtuServices : ICopyFtuServices
    {
        string txtListFunctionTest = "";
        List<string> listItemTest=new List<string>();

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

    }
}
