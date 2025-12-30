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
            tabPageSearch = new TabPage();
            openFileDialog3 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog2 = new FolderBrowserDialog();
            FBD_localDesDownLoad = new FolderBrowserDialog();
            FBD_winscpDLL = new FolderBrowserDialog();
            OFD_winscpDLL_File = new OpenFileDialog();
            OFD_macFilePath = new OpenFileDialog();
            contextMenuStrip1 = new ContextMenuStrip(components);
            openFileDialog1 = new OpenFileDialog();
            tabGetdatafromLog.SuspendLayout();
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
            tabGetdatafromLog.Controls.Add(tabPageSearch);
            tabGetdatafromLog.Location = new Point(10, 9);
            tabGetdatafromLog.Margin = new Padding(3, 2, 3, 2);
            tabGetdatafromLog.Name = "tabGetdatafromLog";
            tabGetdatafromLog.SelectedIndex = 0;
            tabGetdatafromLog.Size = new Size(976, 595);
            tabGetdatafromLog.TabIndex = 11;
            // 
            // tabPage3
            // 
            tabPage3.AllowDrop = true;
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 2, 3, 2);
            tabPage3.Size = new Size(968, 567);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Lọc Log";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.DragEnter += TabPage3_DragEnter;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Margin = new Padding(3, 2, 3, 2);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3, 2, 3, 2);
            tabPage4.Size = new Size(968, 567);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Thu thập log trên sever";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Margin = new Padding(3, 2, 3, 2);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3, 2, 3, 2);
            tabPage5.Size = new Size(968, 567);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Tool cc gì cũng get được từ Log";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(968, 567);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "copy test funtion";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPageSearch
            // 
            tabPageSearch.Location = new Point(4, 24);
            tabPageSearch.Margin = new Padding(3, 2, 3, 2);
            tabPageSearch.Name = "tabPageSearch";
            tabPageSearch.Padding = new Padding(3, 2, 3, 2);
            tabPageSearch.Size = new Size(968, 567);
            tabPageSearch.TabIndex = 5;
            tabPageSearch.Text = "Tool tìm kiếm";
            tabPageSearch.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 615);
            Controls.Add(tabGetdatafromLog);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "TE-TOOL-V5";
            tabGetdatafromLog.ResumeLayout(false);
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
        private TabPage tabPageSearch;
    }
}
