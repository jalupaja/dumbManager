
namespace dumbManager
{
    partial class FrmManager
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
            this.ListManager = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.PnlViewEditLoader = new System.Windows.Forms.Panel();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.BtnEditItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListManager
            // 
            this.ListManager.BackColor = System.Drawing.Color.DimGray;
            this.ListManager.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ListManager.ForeColor = System.Drawing.Color.Black;
            this.ListManager.GridLines = true;
            this.ListManager.HideSelection = false;
            this.ListManager.Location = new System.Drawing.Point(21, 57);
            this.ListManager.Name = "ListManager";
            this.ListManager.Size = new System.Drawing.Size(283, 331);
            this.ListManager.TabIndex = 0;
            this.ListManager.TabStop = false;
            this.ListManager.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "abc";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "def";
            // 
            // PnlViewEditLoader
            // 
            this.PnlViewEditLoader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PnlViewEditLoader.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlViewEditLoader.Location = new System.Drawing.Point(310, 0);
            this.PnlViewEditLoader.Name = "PnlViewEditLoader";
            this.PnlViewEditLoader.Size = new System.Drawing.Size(314, 400);
            this.PnlViewEditLoader.TabIndex = 3;
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.Color.DimGray;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtSearch.Location = new System.Drawing.Point(21, 12);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(153, 20);
            this.TxtSearch.TabIndex = 0;
            this.TxtSearch.Text = " search items";
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.TxtSearch.Enter += new System.EventHandler(this.TxtSearch_Enter);
            this.TxtSearch.Leave += new System.EventHandler(this.TxtSearch_Leave);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(166, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "🔎︎";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAddItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnAddItem.BackColor = System.Drawing.Color.DimGray;
            this.BtnAddItem.FlatAppearance.BorderSize = 0;
            this.BtnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAddItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAddItem.Location = new System.Drawing.Point(193, 8);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(40, 43);
            this.BtnAddItem.TabIndex = 1;
            this.BtnAddItem.Text = "+";
            this.BtnAddItem.UseVisualStyleBackColor = false;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // BtnEditItem
            // 
            this.BtnEditItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnEditItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnEditItem.BackColor = System.Drawing.Color.DimGray;
            this.BtnEditItem.FlatAppearance.BorderSize = 0;
            this.BtnEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnEditItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnEditItem.Location = new System.Drawing.Point(264, 8);
            this.BtnEditItem.Name = "BtnEditItem";
            this.BtnEditItem.Size = new System.Drawing.Size(40, 43);
            this.BtnEditItem.TabIndex = 2;
            this.BtnEditItem.Text = "Edit";
            this.BtnEditItem.UseVisualStyleBackColor = false;
            this.BtnEditItem.Click += new System.EventHandler(this.BtnEditItem_Click);
            // 
            // FrmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 400);
            this.Controls.Add(this.BtnEditItem);
            this.Controls.Add(this.BtnAddItem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.PnlViewEditLoader);
            this.Controls.Add(this.ListManager);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmManager";
            this.Text = "FrmManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListManager;
        private System.Windows.Forms.Panel PnlViewEditLoader;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnAddItem;
        private System.Windows.Forms.Button BtnEditItem;
    }
}