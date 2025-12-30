namespace TE_TOOL.Views
{
    partial class LocLogView
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
            label3 = new Label();
            labelStatus = new Label();
            buttonRunPS = new Button();
            txtFolderLog = new TextBox();
            btnOpenFile = new Button();
            txtMacPath = new TextBox();
            odfMacPath = new OpenFileDialog();
            cbbTypeLog = new ComboBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(149, 92);
            label3.Name = "label3";
            label3.Size = new Size(620, 72);
            label3.TabIndex = 10;
            label3.Text = "Kéo thả file zip vào đây";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.BackColor = SystemColors.ButtonHighlight;
            labelStatus.Font = new Font("Segoe UI", 12F);
            labelStatus.Location = new Point(168, 230);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(0, 21);
            labelStatus.TabIndex = 9;
            // 
            // buttonRunPS
            // 
            buttonRunPS.BackColor = SystemColors.ButtonHighlight;
            buttonRunPS.Cursor = Cursors.Hand;
            buttonRunPS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonRunPS.Location = new Point(537, 284);
            buttonRunPS.Margin = new Padding(3, 2, 3, 2);
            buttonRunPS.Name = "buttonRunPS";
            buttonRunPS.Size = new Size(250, 39);
            buttonRunPS.TabIndex = 8;
            buttonRunPS.Text = "🚀 Chạy Script Lọc Log";
            buttonRunPS.UseVisualStyleBackColor = false;
            // 
            // txtFolderLog
            // 
            txtFolderLog.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFolderLog.Location = new Point(168, 191);
            txtFolderLog.Margin = new Padding(3, 2, 3, 2);
            txtFolderLog.Name = "txtFolderLog";
            txtFolderLog.PlaceholderText = "Nhập đường dẫn file/folder hoặc kéo thả vào đây...";
            txtFolderLog.Size = new Size(620, 23);
            txtFolderLog.TabIndex = 7;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(686, 236);
            btnOpenFile.Margin = new Padding(3, 2, 3, 2);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(102, 22);
            btnOpenFile.TabIndex = 11;
            btnOpenFile.Text = "Open file";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // txtMacPath
            // 
            txtMacPath.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMacPath.Location = new Point(168, 237);
            txtMacPath.Margin = new Padding(3, 2, 3, 2);
            txtMacPath.Multiline = true;
            txtMacPath.Name = "txtMacPath";
            txtMacPath.PlaceholderText = "Nhập đường dẫn file MAC để kiểm tra xem có thiếu file không ...";
            txtMacPath.Size = new Size(494, 22);
            txtMacPath.TabIndex = 12;
            // 
            // odfMacPath
            // 
            odfMacPath.FileName = "openFileDialog1";
            // 
            // cbbTypeLog
            // 
            cbbTypeLog.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTypeLog.FormattingEnabled = true;
            cbbTypeLog.ItemHeight = 15;
            cbbTypeLog.Items.AddRange(new object[] { "New format", "Old format" });
            cbbTypeLog.Location = new Point(168, 284);
            cbbTypeLog.Margin = new Padding(3, 2, 3, 2);
            cbbTypeLog.Name = "cbbTypeLog";
            cbbTypeLog.Size = new Size(322, 23);
            cbbTypeLog.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 364);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 203);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.du_sad;
            pictureBox2.Location = new Point(775, 327);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(195, 240);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            pictureBox2.MouseEnter += pictureBox2_MouseLeave;
            pictureBox2.MouseLeave += pictureBox2_MouseEnter;
            // 
            // LocLogView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(cbbTypeLog);
            Controls.Add(txtMacPath);
            Controls.Add(btnOpenFile);
            Controls.Add(label3);
            Controls.Add(labelStatus);
            Controls.Add(buttonRunPS);
            Controls.Add(txtFolderLog);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LocLogView";
            Size = new Size(970, 567);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label labelStatus;
        private Button buttonRunPS;
        private TextBox txtFolderLog;
        private Button btnOpenFile;
        private TextBox txtMacPath;
        private OpenFileDialog odfMacPath;
        private ComboBox cbbTypeLog;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
