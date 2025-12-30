using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TE_TOOL.Models;

namespace TE_TOOL.Views._05_tab_search_model_name
{
    public partial class ViewSearchModelName : UserControl, IViewSearchModelName
    {
        public ViewSearchModelName()
        {
            InitializeComponent();
            EventRegister();
        }

        void EventRegister()
        {
            textBox1.TextChanged += (s, e) =>
            {
                SearchTextChanged?.Invoke(s, e);
            };

        }
        public string GetSearchText() => textBox1.Text;
        public void DisplayProducts(List<ProductNameModel> products)
        {

            dataGridView1.Rows.Clear();
            if (dataGridView1.Columns.Count == 0 || dataGridView1.Columns[0].HeaderText != "STT")
            {
                dataGridView1.Columns.Insert(0, new DataGridViewTextBoxColumn() { HeaderText = "STT", Name = "STT" ,Width=30,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter 
                    }
                });
            }


            int index = 1; 
            foreach (var p in products)
            {
                dataGridView1.Rows.Add(index++, p.Model, p.ProductName, "");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ofdAdd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdAdd.FileName;
                if (File.Exists(filePath))
                {
                    AddProductRequested?.Invoke(filePath);
                }
                
            }
        }

        public event EventHandler SearchModelKeyPressed;
        public event EventHandler btnAddClicked;
        public event Action<string> AddProductRequested;
        public event EventHandler SearchTextChanged;
    }
}
