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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocLogView));
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
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(170, 123);
            label3.Name = "label3";
            label3.Size = new Size(768, 89);
            label3.TabIndex = 10;
            label3.Text = "Kéo thả file zip vào đây";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.BackColor = SystemColors.ButtonHighlight;
            labelStatus.Font = new Font("Segoe UI", 12F);
            labelStatus.Location = new Point(192, 307);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(0, 28);
            labelStatus.TabIndex = 9;
            // 
            // buttonRunPS
            // 
            buttonRunPS.BackColor = SystemColors.ButtonHighlight;
            buttonRunPS.Cursor = Cursors.Hand;
            buttonRunPS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonRunPS.Location = new Point(614, 378);
            buttonRunPS.Name = "buttonRunPS";
            buttonRunPS.Size = new Size(286, 52);
            buttonRunPS.TabIndex = 8;
            buttonRunPS.Text = "🚀 Chạy Script Lọc Log";
            buttonRunPS.UseVisualStyleBackColor = false;
            // 
            // txtFolderLog
            // 
            txtFolderLog.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFolderLog.Location = new Point(192, 255);
            txtFolderLog.Name = "txtFolderLog";
            txtFolderLog.PlaceholderText = "Nhập đường dẫn file/folder hoặc kéo thả vào đây...";
            txtFolderLog.Size = new Size(708, 27);
            txtFolderLog.TabIndex = 7;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(784, 315);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(116, 30);
            btnOpenFile.TabIndex = 11;
            btnOpenFile.Text = "Open file";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // txtMacPath
            // 
            txtMacPath.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMacPath.Location = new Point(192, 316);
            txtMacPath.Multiline = true;
            txtMacPath.Name = "txtMacPath";
            txtMacPath.PlaceholderText = "Nhập đường dẫn file MAC để kiểm tra xem có thiếu file không ...";
            txtMacPath.Size = new Size(564, 28);
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
            cbbTypeLog.ItemHeight = 20;
            cbbTypeLog.Items.AddRange(new object[] { "New format", "Old format" });
            cbbTypeLog.Location = new Point(192, 378);
            cbbTypeLog.Name = "cbbTypeLog";
            cbbTypeLog.Size = new Size(368, 28);
            cbbTypeLog.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(45, 486);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(208, 486);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(128, 128);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            pictureBox2.MouseEnter += pictureBox2_MouseLeave;
            pictureBox2.MouseLeave += pictureBox2_MouseEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(364, 574);
            label1.Name = "label1";
            label1.Size = new Size(276, 40);
            label1.TabIndex = 16;
            label1.Text = "Chào các bạn mình là Hoàng Anh coder \r\ntác giả của tool này";
            // 
            // LocLogView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(cbbTypeLog);
            Controls.Add(txtMacPath);
            Controls.Add(btnOpenFile);
            Controls.Add(label3);
            Controls.Add(labelStatus);
            Controls.Add(buttonRunPS);
            Controls.Add(txtFolderLog);
            Name = "LocLogView";
            Size = new Size(1108, 642);
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
        private Label label1;
    }
}
