namespace TE_TOOL
{
    partial class DialogOldFtuView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            rtbLogContainer = new RichTextBox();
            panel2 = new Panel();
            BTN_save = new Button();
            btnGetFuntionTest = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.Controls.Add(rtbLogContainer);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(676, 348);
            panel1.TabIndex = 3;
            // 
            // rtbLogContainer
            // 
            rtbLogContainer.Dock = DockStyle.Fill;
            rtbLogContainer.Location = new Point(10, 10);
            rtbLogContainer.Name = "rtbLogContainer";
            rtbLogContainer.Size = new Size(656, 328);
            rtbLogContainer.TabIndex = 0;
            rtbLogContainer.Text = "";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(BTN_save);
            panel2.Controls.Add(btnGetFuntionTest);
            panel2.Location = new Point(12, 366);
            panel2.Name = "panel2";
            panel2.Size = new Size(676, 48);
            panel2.TabIndex = 4;
            // 
            // BTN_save
            // 
            BTN_save.Anchor = AnchorStyles.Bottom;
            BTN_save.Location = new Point(280, 14);
            BTN_save.Margin = new Padding(3, 2, 3, 2);
            BTN_save.Name = "BTN_save";
            BTN_save.Size = new Size(82, 22);
            BTN_save.TabIndex = 3;
            BTN_save.Text = "Save";
            BTN_save.UseVisualStyleBackColor = true;
            // 
            // btnGetFuntionTest
            // 
            btnGetFuntionTest.Anchor = AnchorStyles.Bottom;
            btnGetFuntionTest.Location = new Point(17, 13);
            btnGetFuntionTest.Name = "btnGetFuntionTest";
            btnGetFuntionTest.Size = new Size(102, 23);
            btnGetFuntionTest.TabIndex = 4;
            btnGetFuntionTest.Text = "Lấy funtion test";
            btnGetFuntionTest.UseVisualStyleBackColor = true;
            // 
            // DialogOldFtuView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 426);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DialogOldFtuView";
            Text = "Form_FTU_LOG";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Button BTN_save;
        private Button btnGetFuntionTest;
        private RichTextBox rtbLogContainer;
    }
}