
namespace dumbManager
{
    partial class EditItem
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
            this.TxtHeader = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSafe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtHeader
            // 
            this.TxtHeader.BackColor = System.Drawing.Color.Black;
            this.TxtHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.TxtHeader.Enabled = false;
            this.TxtHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtHeader.ForeColor = System.Drawing.Color.White;
            this.TxtHeader.Location = new System.Drawing.Point(12, 12);
            this.TxtHeader.Name = "TxtHeader";
            this.TxtHeader.ReadOnly = true;
            this.TxtHeader.Size = new System.Drawing.Size(311, 20);
            this.TxtHeader.TabIndex = 1;
            this.TxtHeader.TabStop = false;
            this.TxtHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCancel.BackColor = System.Drawing.Color.DimGray;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCancel.Location = new System.Drawing.Point(12, 345);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(48, 43);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSafe
            // 
            this.BtnSafe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSafe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnSafe.BackColor = System.Drawing.Color.DimGray;
            this.BtnSafe.FlatAppearance.BorderSize = 0;
            this.BtnSafe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSafe.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSafe.Location = new System.Drawing.Point(275, 345);
            this.BtnSafe.Name = "BtnSafe";
            this.BtnSafe.Size = new System.Drawing.Size(48, 43);
            this.BtnSafe.TabIndex = 5;
            this.BtnSafe.Text = "Safe";
            this.BtnSafe.UseVisualStyleBackColor = false;
            this.BtnSafe.Click += new System.EventHandler(this.BtnSafe_Click);
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(335, 400);
            this.Controls.Add(this.BtnSafe);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TxtHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditItem";
            this.Text = "EditItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtHeader;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSafe;
    }
}