namespace TE_TOOL.Views._06_tab_Switch_GPT
{
    partial class ViewSwitchGPT
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
            btnStartDST = new Button();
            imgURLDST = new LinkLabel();
            SuspendLayout();
            // 
            // btnStartDST
            // 
            btnStartDST.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStartDST.Location = new Point(194, 316);
            btnStartDST.Name = "btnStartDST";
            btnStartDST.Size = new Size(694, 86);
            btnStartDST.TabIndex = 0;
            btnStartDST.Text = "Bắt đầu chat với dược sĩ tiến";
            btnStartDST.UseVisualStyleBackColor = true;
            btnStartDST.Click += btnStartDST_Click;
            // 
            // imgURLDST
            // 
            imgURLDST.AutoSize = true;
            imgURLDST.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            imgURLDST.Location = new Point(341, 462);
            imgURLDST.Name = "imgURLDST";
            imgURLDST.Size = new Size(358, 31);
            imgURLDST.TabIndex = 1;
            imgURLDST.TabStop = true;
            imgURLDST.Text = "Chat dược sĩ tiến 403 tỷ tham số";
            imgURLDST.LinkClicked += imgURLDST_LinkClicked;
            // 
            // ViewSwitchGPT
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(imgURLDST);
            Controls.Add(btnStartDST);
            Name = "ViewSwitchGPT";
            Size = new Size(1109, 756);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartDST;
        private LinkLabel imgURLDST;
    }
}
