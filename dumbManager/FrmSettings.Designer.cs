
namespace dumbManager
{
    partial class FrmSettings
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
            this.BtnColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnAlways = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnLogoutAfter = new System.Windows.Forms.Button();
            this.BtnCloseToTray = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnColor
            // 
            this.BtnColor.ForeColor = System.Drawing.Color.Black;
            this.BtnColor.Location = new System.Drawing.Point(35, 42);
            this.BtnColor.Name = "BtnColor";
            this.BtnColor.Size = new System.Drawing.Size(126, 25);
            this.BtnColor.TabIndex = 0;
            this.BtnColor.Text = "Change Color Theme";
            this.BtnColor.UseVisualStyleBackColor = true;
            this.BtnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "General Settings";
            // 
            // BtnAbout
            // 
            this.BtnAbout.AutoSize = true;
            this.BtnAbout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnAbout.Location = new System.Drawing.Point(282, 363);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(50, 25);
            this.BtnAbout.TabIndex = 2;
            this.BtnAbout.Text = "About";
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnAlways
            // 
            this.BtnAlways.ForeColor = System.Drawing.Color.Black;
            this.BtnAlways.Location = new System.Drawing.Point(35, 84);
            this.BtnAlways.Name = "BtnAlways";
            this.BtnAlways.Size = new System.Drawing.Size(126, 25);
            this.BtnAlways.TabIndex = 3;
            this.BtnAlways.Text = "Always On Top: off";
            this.BtnAlways.UseVisualStyleBackColor = true;
            this.BtnAlways.Click += new System.EventHandler(this.BtnAlways_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(336, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password Manager Settings";
            // 
            // BtnLogoutAfter
            // 
            this.BtnLogoutAfter.ForeColor = System.Drawing.Color.Black;
            this.BtnLogoutAfter.Location = new System.Drawing.Point(364, 42);
            this.BtnLogoutAfter.Name = "BtnLogoutAfter";
            this.BtnLogoutAfter.Size = new System.Drawing.Size(213, 25);
            this.BtnLogoutAfter.TabIndex = 5;
            this.BtnLogoutAfter.Text = "Logout automatically after:";
            this.BtnLogoutAfter.UseVisualStyleBackColor = true;
            this.BtnLogoutAfter.Click += new System.EventHandler(this.BtnLogoutAfter_Click);
            // 
            // BtnCloseToTray
            // 
            this.BtnCloseToTray.Location = new System.Drawing.Point(35, 128);
            this.BtnCloseToTray.Name = "BtnCloseToTray";
            this.BtnCloseToTray.Size = new System.Drawing.Size(126, 23);
            this.BtnCloseToTray.TabIndex = 6;
            this.BtnCloseToTray.Text = "Close To Tray: on";
            this.BtnCloseToTray.UseVisualStyleBackColor = true;
            this.BtnCloseToTray.Click += new System.EventHandler(this.BtnCloseToTray_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(622, 400);
            this.Controls.Add(this.BtnCloseToTray);
            this.Controls.Add(this.BtnLogoutAfter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnAlways);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSettings";
            this.Text = "FrmSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.Button BtnAlways;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnLogoutAfter;
        private System.Windows.Forms.Button BtnCloseToTray;
    }
}