namespace TE_TOOL.Views._03_tab_copy_ftu
{
    partial class CopyFtuUserControl
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
            LB_ftu_load_status = new Label();
            btnFTUcu = new Button();
            btnOpenFolder = new Button();
            SuspendLayout();
            // 
            // LB_ftu_load_status
            // 
            LB_ftu_load_status.AutoSize = true;
            LB_ftu_load_status.Location = new Point(309, 73);
            LB_ftu_load_status.Name = "LB_ftu_load_status";
            LB_ftu_load_status.Size = new Size(0, 15);
            LB_ftu_load_status.TabIndex = 10;
            // 
            // btnFTUcu
            // 
            btnFTUcu.Location = new Point(46, 70);
            btnFTUcu.Margin = new Padding(3, 2, 3, 2);
            btnFTUcu.Name = "btnFTUcu";
            btnFTUcu.Size = new Size(242, 22);
            btnFTUcu.TabIndex = 9;
            btnFTUcu.Text = "LOAD FTU CŨ";
            btnFTUcu.UseVisualStyleBackColor = true;

            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Location = new Point(46, 32);
            btnOpenFolder.Margin = new Padding(3, 2, 3, 2);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(242, 22);
            btnOpenFolder.TabIndex = 8;
            btnOpenFolder.Text = "FTU MỚI";
            btnOpenFolder.UseVisualStyleBackColor = true;
            // 
            // CopyFtuUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(LB_ftu_load_status);
            Controls.Add(btnFTUcu);
            Controls.Add(btnOpenFolder);
            Name = "CopyFtuUserControl";
            Size = new Size(970, 482);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LB_ftu_load_status;
        private Button btnFTUcu;
        private Button btnOpenFolder;
    }
}
