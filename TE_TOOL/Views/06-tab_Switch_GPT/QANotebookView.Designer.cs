namespace TE_TOOL.Views._06_tab_Switch_GPT
{
    partial class QANotebookView
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
            txtSearch = new TextBox();
            lstResults = new ListBox();
            txtAnswer = new RichTextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            lblStatus = new Label();
            button1 = new Button();
            sessionTimer = new System.Windows.Forms.Timer(components);
            lblCountdown = new Label();
            btnUpdateDB = new Button();
            process1 = new System.Diagnostics.Process();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(51, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(945, 27);
            txtSearch.TabIndex = 0;
            // 
            // lstResults
            // 
            lstResults.DrawMode = DrawMode.OwnerDrawFixed;
            lstResults.FormattingEnabled = true;
            lstResults.Location = new Point(51, 70);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(985, 144);
            lstResults.TabIndex = 2;
            // 
            // txtAnswer
            // 
            txtAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAnswer.Location = new Point(51, 238);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ReadOnly = true;
            txtAnswer.Size = new Size(985, 287);
            txtAnswer.TabIndex = 3;
            txtAnswer.Text = "";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(51, 556);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1053, 272);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(65, 38);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Visible = false;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(1053, 237);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(65, 29);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Visible = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(399, 560);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(845, 551);
            button1.Name = "button1";
            button1.Size = new Size(151, 29);
            button1.TabIndex = 8;
            button1.Text = "Import from csv";
            button1.UseVisualStyleBackColor = true;
            // 
            // lblCountdown
            // 
            lblCountdown.AutoSize = true;
            lblCountdown.Location = new Point(1014, 25);
            lblCountdown.Name = "lblCountdown";
            lblCountdown.Size = new Size(50, 20);
            lblCountdown.TabIndex = 9;
            lblCountdown.Text = "label1";
            // 
            // btnUpdateDB
            // 
            btnUpdateDB.Location = new Point(151, 556);
            btnUpdateDB.Name = "btnUpdateDB";
            btnUpdateDB.Size = new Size(94, 29);
            btnUpdateDB.TabIndex = 10;
            btnUpdateDB.Text = "Update";
            btnUpdateDB.UseVisualStyleBackColor = true;
            // 
            // process1
            // 
            process1.StartInfo.Domain = "";
            process1.StartInfo.LoadUserProfile = false;
            process1.StartInfo.Password = null;
            process1.StartInfo.StandardErrorEncoding = null;
            process1.StartInfo.StandardInputEncoding = null;
            process1.StartInfo.StandardOutputEncoding = null;
            process1.StartInfo.UseCredentialsForNetworkingOnly = false;
            process1.StartInfo.UserName = "";
            process1.SynchronizingObject = this;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(261, 556);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(117, 29);
            progressBar1.TabIndex = 11;
            // 
            // QANotebookView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 606);
            Controls.Add(progressBar1);
            Controls.Add(btnUpdateDB);
            Controls.Add(lblCountdown);
            Controls.Add(button1);
            Controls.Add(lblStatus);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtAnswer);
            Controls.Add(lstResults);
            Controls.Add(txtSearch);
            Name = "QANotebookView";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private ListBox lstResults;
        private RichTextBox txtAnswer;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Label lblStatus;
        private Button button1;
        private System.Windows.Forms.Timer sessionTimer;
        private Label lblCountdown;
        private Button btnUpdateDB;
        private System.Diagnostics.Process process1;
        private ProgressBar progressBar1;
    }
}
