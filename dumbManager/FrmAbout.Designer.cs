
namespace dumbManager
{
    partial class FrmAbout
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.TxtAbout = new System.Windows.Forms.TextBox();
            this.BtnCheckUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(144, 209);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // TxtAbout
            // 
            this.TxtAbout.BackColor = System.Drawing.Color.Black;
            this.TxtAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtAbout.Enabled = false;
            this.TxtAbout.ForeColor = System.Drawing.Color.White;
            this.TxtAbout.Location = new System.Drawing.Point(33, 50);
            this.TxtAbout.Multiline = true;
            this.TxtAbout.Name = "TxtAbout";
            this.TxtAbout.Size = new System.Drawing.Size(291, 135);
            this.TxtAbout.TabIndex = 1;
            this.TxtAbout.Text = "dumbManager\r\nhttps://github.com/jalupaja/dumbManager\r\nCopyright © jalupa 2021\r\nVe" +
    "rsion ...\r\n\r\n\r\nupdate?";
            this.TxtAbout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnCheckUpdate
            // 
            this.BtnCheckUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCheckUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCheckUpdate.Location = new System.Drawing.Point(74, 112);
            this.BtnCheckUpdate.Name = "BtnCheckUpdate";
            this.BtnCheckUpdate.Size = new System.Drawing.Size(211, 25);
            this.BtnCheckUpdate.TabIndex = 2;
            this.BtnCheckUpdate.Text = "check for updates";
            this.BtnCheckUpdate.UseVisualStyleBackColor = true;
            this.BtnCheckUpdate.Click += new System.EventHandler(this.BtnCheckUpdate_Click);
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(357, 244);
            this.Controls.Add(this.BtnCheckUpdate);
            this.Controls.Add(this.TxtAbout);
            this.Controls.Add(this.BtnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAbout";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.TextBox TxtAbout;
        private System.Windows.Forms.Button BtnCheckUpdate;
    }
}