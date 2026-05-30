namespace TE_TOOL.Views._06_tab_Switch_GPT
{
    partial class AddEditForm
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
            txtQuestion = new TextBox();
            txtAnswer = new TextBox();
            txtTags = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(39, 40);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.ScrollBars = ScrollBars.Vertical;
            txtQuestion.Size = new Size(997, 77);
            txtQuestion.TabIndex = 0;
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(39, 166);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ScrollBars = ScrollBars.Both;
            txtAnswer.Size = new Size(997, 270);
            txtAnswer.TabIndex = 1;
            // 
            // txtTags
            // 
            txtTags.Location = new Point(261, 453);
            txtTags.Multiline = true;
            txtTags.Name = "txtTags";
            txtTags.ScrollBars = ScrollBars.Vertical;
            txtTags.Size = new Size(775, 37);
            txtTags.TabIndex = 2;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(39, 503);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(142, 42);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(894, 503);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(142, 42);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 17);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 5;
            label1.Text = "Câu hỏi";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 143);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 6;
            label2.Text = "Câu trả lời";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 461);
            label3.Name = "label3";
            label3.Size = new Size(216, 20);
            label3.TabIndex = 7;
            label3.Text = "Hastag : Unas2, pi4, nustream ...";
            // 
            // AddEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 566);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtTags);
            Controls.Add(txtAnswer);
            Controls.Add(txtQuestion);
            Name = "AddEditForm";
            Text = "AddEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQuestion;
        private TextBox txtAnswer;
        private TextBox txtTags;
        private Button btnOK;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}