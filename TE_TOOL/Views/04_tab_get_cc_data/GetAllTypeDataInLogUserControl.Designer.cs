namespace TE_TOOL.Views._04_tab_get_cc_data
{
    partial class GetAllTypeDataInLogUserControl
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
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            textBox4 = new TextBox();
            fbdPathLog = new FolderBrowserDialog();
            button3 = new Button();
            fbdSaveLocation = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 51);
            label1.Name = "label1";
            label1.Size = new Size(455, 20);
            label1.TabIndex = 0;
            label1.Text = "Nếu mà bạn có thể dùng thành thạo tool này thì bạn ...Bấm vào đây";
            label1.Click += label1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(73, 69);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(163, 20);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Link hướng dẫn nhanh !";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(73, 155);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Muốn biết ở đây viết gì thì đọc SOP";
            textBox1.Size = new Size(438, 33);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 131);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 3;
            label3.Text = "Regex tiền tố";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(555, 131);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 5;
            label4.Text = "Regex giá trị";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(555, 155);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Thường là       (\\d+)";
            textBox2.Size = new Size(448, 33);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(73, 228);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Bạn có thể kéo thả folder hoặc paste path vào đây";
            textBox3.Size = new Size(759, 33);
            textBox3.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 205);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 7;
            label2.Text = "Path chứa file log";
            // 
            // button1
            // 
            button1.Location = new Point(856, 228);
            button1.Name = "button1";
            button1.Size = new Size(147, 33);
            button1.TabIndex = 8;
            button1.Text = "Open";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(856, 301);
            button2.Name = "button2";
            button2.Size = new Size(147, 33);
            button2.TabIndex = 11;
            button2.Text = "Open";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(73, 279);
            label5.Name = "label5";
            label5.Size = new Size(142, 20);
            label5.TabIndex = 10;
            label5.Text = "Chọn nơi lưu file csv";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(73, 301);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Xuất ra đây";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(759, 33);
            textBox4.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(73, 383);
            button3.Name = "button3";
            button3.Size = new Size(291, 55);
            button3.TabIndex = 12;
            button3.Text = "GET DATA";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // GetAllTypeDataInLogUserControl
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Name = "GetAllTypeDataInLogUserControl";
            Size = new Size(1109, 643);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel linkLabel1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private Label label5;
        private TextBox textBox4;
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog fbdPathLog;
        private Button button3;
        private FolderBrowserDialog fbdSaveLocation;
    }
}
