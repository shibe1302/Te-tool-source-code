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
            buttonRunPS.Location = new Point(354, 409);
            buttonRunPS.Name = "buttonRunPS";
            buttonRunPS.Size = new Size(333, 50);
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
            btnOpenFile.Location = new Point(784, 313);
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
            txtMacPath.Location = new Point(192, 313);
            txtMacPath.Multiline = true;
            txtMacPath.Name = "txtMacPath";
            txtMacPath.PlaceholderText = "Nhập đường dẫn file MAC để kiểm tra xem có thiếu file không ...";
            txtMacPath.Size = new Size(564, 30);
            txtMacPath.TabIndex = 12;
            // 
            // odfMacPath
            // 
            odfMacPath.FileName = "openFileDialog1";
            // 
            // LocLogView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtMacPath);
            Controls.Add(btnOpenFile);
            Controls.Add(label3);
            Controls.Add(labelStatus);
            Controls.Add(buttonRunPS);
            Controls.Add(txtFolderLog);
            Name = "LocLogView";
            Size = new Size(1108, 642);
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
    }
}
