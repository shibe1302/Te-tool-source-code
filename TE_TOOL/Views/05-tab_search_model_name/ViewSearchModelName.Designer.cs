namespace TE_TOOL.Views._05_tab_search_model_name
{
    partial class ViewSearchModelName
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            ProductName1 = new DataGridViewTextBoxColumn();
            ModelName1 = new DataGridViewTextBoxColumn();
            PathServer = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            ofdAdd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(52, 40);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(390, 23);
            textBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProductName1, ModelName1, PathServer });
            dataGridView1.Location = new Point(52, 83);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(883, 441);
            dataGridView1.TabIndex = 2;
            // 
            // ProductName1
            // 
            ProductName1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProductName1.FillWeight = 80F;
            ProductName1.HeaderText = "Tên sản phẩm";
            ProductName1.MinimumWidth = 6;
            ProductName1.Name = "ProductName1";
            ProductName1.ReadOnly = true;
            // 
            // ModelName1
            // 
            ModelName1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ModelName1.FillWeight = 90F;
            ModelName1.HeaderText = "Mã sản phẩm";
            ModelName1.MinimumWidth = 6;
            ModelName1.Name = "ModelName1";
            ModelName1.ReadOnly = true;
            // 
            // PathServer
            // 
            PathServer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PathServer.FillWeight = 180F;
            PathServer.HeaderText = "Path to log";
            PathServer.MinimumWidth = 6;
            PathServer.Name = "PathServer";
            PathServer.ReadOnly = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(860, 40);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add data";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // ofdAdd
            // 
            ofdAdd.FileName = "openFileDialog1";
            // 
            // ViewSearchModelName
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ViewSearchModelName";
            Size = new Size(970, 567);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ProductName1;
        private DataGridViewTextBoxColumn ModelName1;
        private DataGridViewTextBoxColumn PathServer;
        private Button btnAdd;
        private OpenFileDialog ofdAdd;
    }
}
