
namespace dumbManager
{
    partial class LookAtItem
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
            this.TxtHeader.Location = new System.Drawing.Point(13, 13);
            this.TxtHeader.Name = "TxtHeader";
            this.TxtHeader.ReadOnly = true;
            this.TxtHeader.Size = new System.Drawing.Size(300, 20);
            this.TxtHeader.TabIndex = 0;
            this.TxtHeader.TabStop = false;
            this.TxtHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LookAtItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(335, 400);
            this.Controls.Add(this.TxtHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LookAtItem";
            this.Text = "LookAtItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtHeader;
    }
}