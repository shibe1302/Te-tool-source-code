using System.Windows.Forms;

namespace hocWF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            openFileDialog2 = new OpenFileDialog();
            tabGetdatafromLog = new TabControl();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage2 = new TabPage();
            tabPage1 = new TabPage();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            openFileDialog3 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog2 = new FolderBrowserDialog();
            FBD_localDesDownLoad = new FolderBrowserDialog();
            FBD_winscpDLL = new FolderBrowserDialog();
            OFD_winscpDLL_File = new OpenFileDialog();
            OFD_macFilePath = new OpenFileDialog();
            contextMenuStrip1 = new ContextMenuStrip(components);
            openFileDialog1 = new OpenFileDialog();
            label2 = new Label();
            tabGetdatafromLog.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // tabGetdatafromLog
            // 
            tabGetdatafromLog.AllowDrop = true;
            tabGetdatafromLog.Controls.Add(tabPage3);
            tabGetdatafromLog.Controls.Add(tabPage4);
            tabGetdatafromLog.Controls.Add(tabPage5);
            tabGetdatafromLog.Controls.Add(tabPage2);
            tabGetdatafromLog.Controls.Add(tabPage1);
            tabGetdatafromLog.Location = new Point(12, 12);
            tabGetdatafromLog.Name = "tabGetdatafromLog";
            tabGetdatafromLog.SelectedIndex = 0;
            tabGetdatafromLog.Size = new Size(1115, 675);
            tabGetdatafromLog.TabIndex = 11;
            // 
            // tabPage3
            // 
            tabPage3.AllowDrop = true;
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1107, 642);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Lọc Log";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.DragEnter += TabPage3_DragEnter;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1107, 642);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Thu thập log trên sever";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1107, 642);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Tool cc gì cũng get được từ Log";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1107, 642);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "copy test funtion";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1107, 642);
            tabPage1.TabIndex = 5;
            tabPage1.Text = "Donate";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 121);
            label1.Name = "label1";
            label1.Size = new Size(579, 20);
            label1.TabIndex = 1;
            label1.Text = "Nếu các bạn thấy tool này giải trí hãy donate để mình có thêm động lực nghỉ hưu sớm";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = TE_TOOL.Properties.Resources.QR;
            pictureBox1.Location = new Point(395, 167);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(335, 308);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // openFileDialog3
            // 
            openFileDialog3.FileName = "openFileDialog3";
            // 
            // OFD_winscpDLL_File
            // 
            OFD_winscpDLL_File.FileName = "openFileDialog4";
            // 
            // OFD_macFilePath
            // 
            OFD_macFilePath.FileName = "OFD_macFilePath";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(291, 487);
            label2.Name = "label2";
            label2.Size = new Size(586, 28);
            label2.TabIndex = 2;
            label2.Text = "如果你们觉得这个工具好玩，欢迎打赏一下，助我早日躺平退休";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 699);
            Controls.Add(tabGetdatafromLog);
            Name = "Form1";
            Text = "TE-TOOL-V4";
            tabGetdatafromLog.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);


        }



        private void TabPage3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion
        private OpenFileDialog openFileDialog2;
        private TabControl tabGetdatafromLog;
        private TabPage tabPage2;
        private OpenFileDialog openFileDialog3;
        private FolderBrowserDialog folderBrowserDialog1;
        private FolderBrowserDialog folderBrowserDialog2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private FolderBrowserDialog FBD_localDesDownLoad;
        private FolderBrowserDialog FBD_winscpDLL;
        private OpenFileDialog OFD_winscpDLL_File;
        private OpenFileDialog OFD_macFilePath;
        private ContextMenuStrip contextMenuStrip1;
        private OpenFileDialog openFileDialog1;
        private TabPage tabPage5;
        private TabPage tabPage1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
    }
}
