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
            btnGetItemFromLog = new Button();
            btnSelectedItem = new Button();
            btnReorder = new Button();
            ofdSelectedItemInit = new OpenFileDialog();
            ofdReorderJson = new OpenFileDialog();
            txtGetItemFormLog = new TextBox();
            txtSelectedItem = new TextBox();
            txtReorderJson = new TextBox();
            panel1 = new Panel();
            clb_item_from_json = new CheckedListBox();
            btnLoad = new Button();
            lbTotalItems = new Label();
            btnReoder = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGetItemFromLog
            // 
            btnGetItemFromLog.Location = new Point(41, 39);
            btnGetItemFromLog.Margin = new Padding(3, 2, 3, 2);
            btnGetItemFromLog.Name = "btnGetItemFromLog";
            btnGetItemFromLog.Size = new Size(178, 25);
            btnGetItemFromLog.TabIndex = 9;
            btnGetItemFromLog.Text = "LẤY ITEM TỪ LOG";
            btnGetItemFromLog.UseVisualStyleBackColor = true;
            // 
            // btnSelectedItem
            // 
            btnSelectedItem.Location = new Point(41, 123);
            btnSelectedItem.Margin = new Padding(3, 2, 3, 2);
            btnSelectedItem.Name = "btnSelectedItem";
            btnSelectedItem.Size = new Size(178, 25);
            btnSelectedItem.TabIndex = 8;
            btnSelectedItem.Text = "SELECTED_ITEM.INI";
            btnSelectedItem.UseVisualStyleBackColor = true;
            btnSelectedItem.Click += btnSelectedItem_Click;
            // 
            // btnReorder
            // 
            btnReorder.Location = new Point(41, 81);
            btnReorder.Margin = new Padding(3, 2, 3, 2);
            btnReorder.Name = "btnReorder";
            btnReorder.Size = new Size(178, 25);
            btnReorder.TabIndex = 11;
            btnReorder.Text = "REORDER.JSON";
            btnReorder.UseVisualStyleBackColor = true;
            btnReorder.Click += btnReorder_Click;
            // 
            // ofdSelectedItemInit
            // 
            ofdSelectedItemInit.FileName = "openFileDialog1";
            // 
            // ofdReorderJson
            // 
            ofdReorderJson.FileName = "ofdReorderJson";
            // 
            // txtGetItemFormLog
            // 
            txtGetItemFormLog.Location = new Point(235, 41);
            txtGetItemFormLog.Name = "txtGetItemFormLog";
            txtGetItemFormLog.PlaceholderText = "Copy nội dung file log";
            txtGetItemFormLog.Size = new Size(236, 23);
            txtGetItemFormLog.TabIndex = 12;
            // 
            // txtSelectedItem
            // 
            txtSelectedItem.Location = new Point(235, 125);
            txtSelectedItem.Name = "txtSelectedItem";
            txtSelectedItem.PlaceholderText = "Tìm file selected_items.ini trong FTU/data";
            txtSelectedItem.ReadOnly = true;
            txtSelectedItem.Size = new Size(236, 23);
            txtSelectedItem.TabIndex = 13;
            // 
            // txtReorderJson
            // 
            txtReorderJson.Location = new Point(235, 83);
            txtReorderJson.Name = "txtReorderJson";
            txtReorderJson.PlaceholderText = "Tìm file _reorder.sjon trong FTU/products/";
            txtReorderJson.Size = new Size(236, 23);
            txtReorderJson.TabIndex = 14;
            txtReorderJson.TextChanged += txtReorderJson_TextChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(clb_item_from_json);
            panel1.Location = new Point(494, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(454, 401);
            panel1.TabIndex = 15;
            // 
            // clb_item_from_json
            // 
            clb_item_from_json.FormattingEnabled = true;
            clb_item_from_json.Location = new Point(13, 21);
            clb_item_from_json.Name = "clb_item_from_json";
            clb_item_from_json.Size = new Size(417, 346);
            clb_item_from_json.TabIndex = 0;
            clb_item_from_json.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(41, 186);
            btnLoad.Margin = new Padding(3, 2, 3, 2);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(430, 25);
            btnLoad.TabIndex = 16;
            btnLoad.Text = "LOAD";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // lbTotalItems
            // 
            lbTotalItems.AutoSize = true;
            lbTotalItems.Location = new Point(494, 19);
            lbTotalItems.Name = "lbTotalItems";
            lbTotalItems.Size = new Size(70, 15);
            lbTotalItems.TabIndex = 17;
            lbTotalItems.Text = "Total items :";
            // 
            // btnReoder
            // 
            btnReoder.Location = new Point(41, 233);
            btnReoder.Margin = new Padding(3, 2, 3, 2);
            btnReoder.Name = "btnReoder";
            btnReoder.Size = new Size(430, 25);
            btnReoder.TabIndex = 18;
            btnReoder.Text = "Sắp xếp funtion test từ log lên trên cùng";
            btnReoder.UseVisualStyleBackColor = true;
            // 
            // CopyFtuUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnReoder);
            Controls.Add(lbTotalItems);
            Controls.Add(btnLoad);
            Controls.Add(panel1);
            Controls.Add(txtReorderJson);
            Controls.Add(txtSelectedItem);
            Controls.Add(txtGetItemFormLog);
            Controls.Add(btnReorder);
            Controls.Add(btnGetItemFromLog);
            Controls.Add(btnSelectedItem);
            Name = "CopyFtuUserControl";
            Size = new Size(970, 482);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnGetItemFromLog;
        private Button btnSelectedItem;
        private Button btnReorder;
        private OpenFileDialog ofdSelectedItemInit;
        private OpenFileDialog ofdReorderJson;
        private TextBox txtGetItemFormLog;
        private TextBox txtSelectedItem;
        private TextBox txtReorderJson;
        private Panel panel1;
        private CheckedListBox clb_item_from_json;
        private Button btnLoad;
        private Label lbTotalItems;
        private Button btnReoder;
    }
}
