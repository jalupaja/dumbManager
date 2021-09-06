
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
            this.BtnStartMenu = new System.Windows.Forms.Button();
            this.BtnStartup = new System.Windows.Forms.Button();
            this.BtnImport = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
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
            // BtnStartMenu
            // 
            this.BtnStartMenu.Location = new System.Drawing.Point(35, 170);
            this.BtnStartMenu.Name = "BtnStartMenu";
            this.BtnStartMenu.Size = new System.Drawing.Size(126, 23);
            this.BtnStartMenu.TabIndex = 7;
            this.BtnStartMenu.Text = "Delete Start Menu";
            this.BtnStartMenu.UseVisualStyleBackColor = true;
            this.BtnStartMenu.Click += new System.EventHandler(this.BtnStartMenu_Click);
            // 
            // BtnStartup
            // 
            this.BtnStartup.Location = new System.Drawing.Point(35, 214);
            this.BtnStartup.Name = "BtnStartup";
            this.BtnStartup.Size = new System.Drawing.Size(126, 23);
            this.BtnStartup.TabIndex = 8;
            this.BtnStartup.Text = "Startup: Tray";
            this.BtnStartup.UseVisualStyleBackColor = true;
            this.BtnStartup.Click += new System.EventHandler(this.BtnStartup_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.ForeColor = System.Drawing.Color.Black;
            this.BtnImport.Location = new System.Drawing.Point(364, 84);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(94, 25);
            this.BtnImport.TabIndex = 9;
            this.BtnImport.Text = "Import";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.ForeColor = System.Drawing.Color.Black;
            this.BtnExport.Location = new System.Drawing.Point(483, 84);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(94, 25);
            this.BtnExport.TabIndex = 10;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(622, 400);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.BtnStartup);
            this.Controls.Add(this.BtnStartMenu);
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
        private System.Windows.Forms.Button BtnStartMenu;
        private System.Windows.Forms.Button BtnStartup;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.Button BtnExport;
    }
}