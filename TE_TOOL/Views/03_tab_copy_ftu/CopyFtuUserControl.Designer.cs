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
            button1 = new Button();
            txtFTUexe = new TextBox();
            ofdFTUexe = new OpenFileDialog();
            btnOpenFTU = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGetItemFromLog
            // 
            btnGetItemFromLog.Location = new Point(43, 52);
            btnGetItemFromLog.Name = "btnGetItemFromLog";
            btnGetItemFromLog.Size = new Size(146, 33);
            btnGetItemFromLog.TabIndex = 9;
            btnGetItemFromLog.Text = "LẤY ITEM TỪ LOG";
            btnGetItemFromLog.UseVisualStyleBackColor = true;
            // 
            // btnSelectedItem
            // 
            btnSelectedItem.Location = new Point(43, 164);
            btnSelectedItem.Name = "btnSelectedItem";
            btnSelectedItem.Size = new Size(146, 33);
            btnSelectedItem.TabIndex = 8;
            btnSelectedItem.Text = "SELECTED_ITEM.INI";
            btnSelectedItem.UseVisualStyleBackColor = true;
            btnSelectedItem.Click += btnSelectedItem_Click;
            // 
            // btnReorder
            // 
            btnReorder.Location = new Point(43, 108);
            btnReorder.Name = "btnReorder";
            btnReorder.Size = new Size(146, 33);
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
            txtGetItemFormLog.Location = new Point(215, 55);
            txtGetItemFormLog.Margin = new Padding(3, 4, 3, 4);
            txtGetItemFormLog.Name = "txtGetItemFormLog";
            txtGetItemFormLog.PlaceholderText = "Copy nội dung file log";
            txtGetItemFormLog.Size = new Size(323, 27);
            txtGetItemFormLog.TabIndex = 12;
            txtGetItemFormLog.Leave += txtGetItemFormLog_Leave;
            // 
            // txtSelectedItem
            // 
            txtSelectedItem.Location = new Point(215, 167);
            txtSelectedItem.Margin = new Padding(3, 4, 3, 4);
            txtSelectedItem.Name = "txtSelectedItem";
            txtSelectedItem.PlaceholderText = "Tìm file selected_items.ini trong FTU/data";
            txtSelectedItem.ReadOnly = true;
            txtSelectedItem.Size = new Size(323, 27);
            txtSelectedItem.TabIndex = 13;
            // 
            // txtReorderJson
            // 
            txtReorderJson.Location = new Point(215, 111);
            txtReorderJson.Margin = new Padding(3, 4, 3, 4);
            txtReorderJson.Name = "txtReorderJson";
            txtReorderJson.PlaceholderText = "Tìm file _reorder.sjon trong FTU/products/";
            txtReorderJson.Size = new Size(323, 27);
            txtReorderJson.TabIndex = 14;
            txtReorderJson.TextChanged += txtReorderJson_TextChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(clb_item_from_json);
            panel1.Location = new Point(565, 55);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 660);
            panel1.TabIndex = 15;
            // 
            // clb_item_from_json
            // 
            clb_item_from_json.FormattingEnabled = true;
            clb_item_from_json.Location = new Point(15, 28);
            clb_item_from_json.Margin = new Padding(3, 4, 3, 4);
            clb_item_from_json.Name = "clb_item_from_json";
            clb_item_from_json.Size = new Size(483, 598);
            clb_item_from_json.TabIndex = 0;
            clb_item_from_json.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(43, 215);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(495, 33);
            btnLoad.TabIndex = 16;
            btnLoad.Text = "LOAD";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // lbTotalItems
            // 
            lbTotalItems.AutoSize = true;
            lbTotalItems.Location = new Point(565, 25);
            lbTotalItems.Name = "lbTotalItems";
            lbTotalItems.Size = new Size(89, 20);
            lbTotalItems.TabIndex = 17;
            lbTotalItems.Text = "Total items :";
            // 
            // btnReoder
            // 
            btnReoder.Location = new Point(43, 265);
            btnReoder.Name = "btnReoder";
            btnReoder.Size = new Size(495, 33);
            btnReoder.TabIndex = 18;
            btnReoder.Text = "Sắp xếp funtion test từ log lên trên cùng";
            btnReoder.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(43, 604);
            button1.Name = "button1";
            button1.Size = new Size(146, 33);
            button1.TabIndex = 19;
            button1.Text = "FTU.exe";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtFTUexe
            // 
            txtFTUexe.Location = new Point(215, 608);
            txtFTUexe.Name = "txtFTUexe";
            txtFTUexe.Size = new Size(323, 27);
            txtFTUexe.TabIndex = 20;
            // 
            // ofdFTUexe
            // 
            ofdFTUexe.FileName = "openFileDialog1";
            // 
            // btnOpenFTU
            // 
            btnOpenFTU.Location = new Point(43, 657);
            btnOpenFTU.Name = "btnOpenFTU";
            btnOpenFTU.Size = new Size(495, 33);
            btnOpenFTU.TabIndex = 21;
            btnOpenFTU.Text = "Mở FTU";
            btnOpenFTU.UseVisualStyleBackColor = true;
            // 
            // CopyFtuUserControl
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnOpenFTU);
            Controls.Add(txtFTUexe);
            Controls.Add(button1);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "CopyFtuUserControl";
            Size = new Size(1109, 756);
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
        private Button button1;
        private TextBox txtFTUexe;
        private OpenFileDialog ofdFTUexe;
        private Button btnOpenFTU;
    }
}
