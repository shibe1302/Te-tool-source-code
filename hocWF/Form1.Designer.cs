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
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            label1 = new Label();
            btnFTUcu = new Button();
            textBox2 = new TextBox();
            groupBoxTestContent = new GroupBox();
            btnMigrateFromOldFtu = new Button();
            checkedListBoxTests = new CheckedListBox();
            btnSaveIni = new Button();
            btnSelectAll = new Button();
            btnDisSelectAll = new Button();
            btnOpenFolder = new Button();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            tabPage1 = new TabPage();
            checkBox2 = new CheckBox();
            button5 = new Button();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            button4 = new Button();
            buttonToggleScroll = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            richTextBox2 = new RichTextBox();
            richTextBox1 = new RichTextBox();
            tabPage3 = new TabPage();
            label2 = new Label();
            labelPath = new Label();
            buttonRunPS = new Button();
            textBoxPath = new TextBox();
            openFileDialog3 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog2 = new FolderBrowserDialog();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBoxTestContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage1.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1116, 675);
            tabControl1.TabIndex = 11;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(btnFTUcu);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(groupBoxTestContent);
            tabPage2.Controls.Add(btnOpenFolder);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1108, 642);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "copy test funtion";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(834, 560);
            label1.Name = "label1";
            label1.Size = new Size(243, 20);
            label1.TabIndex = 9;
            label1.Text = "Ít thì 5 quả trứng nhiều thì 1 tên lửa";
            // 
            // btnFTUcu
            // 
            btnFTUcu.Location = new Point(66, 81);
            btnFTUcu.Name = "btnFTUcu";
            btnFTUcu.Size = new Size(277, 29);
            btnFTUcu.TabIndex = 6;
            btnFTUcu.Text = "LOAD FTU CŨ";
            btnFTUcu.UseVisualStyleBackColor = true;
            btnFTUcu.Click += btnFTUcu_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(365, 83);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(448, 27);
            textBox2.TabIndex = 5;
            // 
            // groupBoxTestContent
            // 
            groupBoxTestContent.Controls.Add(btnMigrateFromOldFtu);
            groupBoxTestContent.Controls.Add(checkedListBoxTests);
            groupBoxTestContent.Controls.Add(btnSaveIni);
            groupBoxTestContent.Controls.Add(btnSelectAll);
            groupBoxTestContent.Controls.Add(btnDisSelectAll);
            groupBoxTestContent.Location = new Point(66, 142);
            groupBoxTestContent.Name = "groupBoxTestContent";
            groupBoxTestContent.Size = new Size(747, 452);
            groupBoxTestContent.TabIndex = 4;
            groupBoxTestContent.TabStop = false;
            groupBoxTestContent.Text = "Trà cũ vị sưa";
            groupBoxTestContent.Enter += groupBox1_Enter;
            // 
            // btnMigrateFromOldFtu
            // 
            btnMigrateFromOldFtu.Location = new Point(43, 50);
            btnMigrateFromOldFtu.Name = "btnMigrateFromOldFtu";
            btnMigrateFromOldFtu.Size = new Size(182, 29);
            btnMigrateFromOldFtu.TabIndex = 5;
            btnMigrateFromOldFtu.Text = "copy item từ FTU cũ";
            btnMigrateFromOldFtu.UseVisualStyleBackColor = true;
            btnMigrateFromOldFtu.Click += btnMigrateFromOldFtu_Click;
            // 
            // checkedListBoxTests
            // 
            checkedListBoxTests.AllowDrop = true;
            checkedListBoxTests.FormattingEnabled = true;
            checkedListBoxTests.Location = new Point(43, 106);
            checkedListBoxTests.Name = "checkedListBoxTests";
            checkedListBoxTests.Size = new Size(666, 312);
            checkedListBoxTests.TabIndex = 4;
            checkedListBoxTests.ItemCheck += CheckedListBoxTests_ItemCheck;
            checkedListBoxTests.SelectedIndexChanged += checkedListBoxTests_SelectedIndexChanged;
            checkedListBoxTests.DragDrop += CheckedListBoxTests_DragDrop;
            checkedListBoxTests.DragOver += CheckedListBoxTests_DragOver;
            checkedListBoxTests.MouseDown += CheckedListBoxTests_MouseDown;
            checkedListBoxTests.MouseUp += CheckedListBoxTests_MouseUp;
            // 
            // btnSaveIni
            // 
            btnSaveIni.Location = new Point(614, 50);
            btnSaveIni.Name = "btnSaveIni";
            btnSaveIni.Size = new Size(94, 29);
            btnSaveIni.TabIndex = 3;
            btnSaveIni.Text = "Save";
            btnSaveIni.UseVisualStyleBackColor = true;
            btnSaveIni.Click += button7_Click;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(453, 50);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(94, 29);
            btnSelectAll.TabIndex = 2;
            btnSelectAll.Text = "Select all";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // btnDisSelectAll
            // 
            btnDisSelectAll.Location = new Point(292, 50);
            btnDisSelectAll.Name = "btnDisSelectAll";
            btnDisSelectAll.Size = new Size(94, 29);
            btnDisSelectAll.TabIndex = 1;
            btnDisSelectAll.Text = "Dis-select all";
            btnDisSelectAll.UseVisualStyleBackColor = true;
            btnDisSelectAll.Click += btnDisSelectAll_Click;
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Location = new Point(66, 31);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(277, 29);
            btnOpenFolder.TabIndex = 2;
            btnOpenFolder.Text = "FTU MỚI";
            btnOpenFolder.UseVisualStyleBackColor = true;
            btnOpenFolder.Click += button6_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(365, 33);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(448, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(100, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(checkBox2);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(checkBox1);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(buttonToggleScroll);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(richTextBox2);
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1108, 642);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tool compare";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(627, 33);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(149, 24);
            checkBox2.TabIndex = 21;
            checkBox2.Text = "Enable edit mode";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // button5
            // 
            button5.Location = new Point(244, 550);
            button5.Name = "button5";
            button5.Size = new Size(216, 30);
            button5.TabIndex = 20;
            button5.Text = "Save";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(23, 33);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(309, 24);
            checkBox1.TabIndex = 19;
            checkBox1.Text = "So sánh file config.ini >< config lấy từ log";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Get config from LOG", "File text" });
            comboBox1.Location = new Point(863, 551);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(216, 28);
            comboBox1.TabIndex = 18;
            // 
            // button4
            // 
            button4.Location = new Point(483, 244);
            button4.Name = "button4";
            button4.Size = new Size(117, 29);
            button4.TabIndex = 17;
            button4.Text = "undo";
            button4.UseVisualStyleBackColor = true;
            // 
            // buttonToggleScroll
            // 
            buttonToggleScroll.Location = new Point(483, 184);
            buttonToggleScroll.Name = "buttonToggleScroll";
            buttonToggleScroll.Size = new Size(117, 29);
            buttonToggleScroll.TabIndex = 16;
            buttonToggleScroll.Text = "đồng bộ roll";
            buttonToggleScroll.UseVisualStyleBackColor = true;
            buttonToggleScroll.Click += buttonToggleScroll_Click;
            // 
            // button3
            // 
            button3.Location = new Point(483, 134);
            button3.Name = "button3";
            button3.Size = new Size(117, 29);
            button3.TabIndex = 15;
            button3.Text = "so sánh";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(627, 550);
            button2.Name = "button2";
            button2.Size = new Size(216, 30);
            button2.TabIndex = 14;
            button2.Text = "File cũ / log của trạm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(23, 550);
            button1.Name = "button1";
            button1.Size = new Size(216, 30);
            button1.TabIndex = 13;
            button1.Text = "File mới";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(627, 75);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(452, 444);
            richTextBox2.TabIndex = 12;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(23, 75);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(437, 444);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // tabPage3
            // 
            tabPage3.AllowDrop = true;
            tabPage3.Controls.Add(label2);
            tabPage3.Controls.Add(labelPath);
            tabPage3.Controls.Add(buttonRunPS);
            tabPage3.Controls.Add(textBoxPath);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1108, 642);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Lọc Log";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.DragDrop += TabPage3_DragDrop;
            tabPage3.DragEnter += TabPage3_DragEnter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 40F);
            label2.ForeColor = Color.DeepPink;
            label2.Location = new Point(135, 98);
            label2.Name = "label2";
            label2.Size = new Size(842, 89);
            label2.TabIndex = 5;
            label2.Text = "KÉO THẢ FILE ZIP VÀO ĐÂY";
            // 
            // labelPath
            // 
            labelPath.AutoSize = true;
            labelPath.BackColor = SystemColors.ButtonHighlight;
            labelPath.Font = new Font("Segoe UI", 12F);
            labelPath.Location = new Point(162, 230);
            labelPath.Name = "labelPath";
            labelPath.Size = new Size(50, 28);
            labelPath.TabIndex = 4;
            labelPath.Text = "Path";
            // 
            // buttonRunPS
            // 
            buttonRunPS.BackColor = SystemColors.ButtonHighlight;
            buttonRunPS.Location = new Point(434, 294);
            buttonRunPS.Name = "buttonRunPS";
            buttonRunPS.Size = new Size(134, 42);
            buttonRunPS.TabIndex = 3;
            buttonRunPS.Text = "nhấp em đi";
            buttonRunPS.UseVisualStyleBackColor = false;
            buttonRunPS.Click += buttonRunPS_Click;
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(231, 230);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(687, 27);
            textBoxPath.TabIndex = 0;
            // 
            // openFileDialog3
            // 
            openFileDialog3.FileName = "openFileDialog3";
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.HelpRequest += folderBrowserDialog1_HelpRequest;
            // 
            // folderBrowserDialog2
            // 
            folderBrowserDialog2.HelpRequest += folderBrowserDialog2_HelpRequest;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 699);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Tool hỗ trợ ve di phai";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBoxTestContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);



        }

        private void TabPage3_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                string filePath = files[0]; // lấy file đầu tiên
                textBoxPath.Text = filePath;
            }
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
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CheckBox checkBox2;
        private Button button5;
        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private Button button4;
        private Button buttonToggleScroll;
        private Button button3;
        private Button button2;
        private Button button1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private Button btnOpenFolder;
        private OpenFileDialog openFileDialog3;
        private Button btnSaveIni;
        private GroupBox groupBoxTestContent;
        private Button btnSelectAll;
        private Button btnDisSelectAll;
        private CheckedListBox checkedListBoxTests;
        private Button btnFTUcu;
        private TextBox textBox2;
        private FolderBrowserDialog folderBrowserDialog1;
        private FolderBrowserDialog folderBrowserDialog2;
        private Button btnMigrateFromOldFtu;
        private PictureBox pictureBox1;
        private Label label1;
        private TabPage tabPage3;
        private TextBox textBoxPath;
        private Button buttonRunPS;
        private Label labelPath;
        private Label label2;
    }
}
