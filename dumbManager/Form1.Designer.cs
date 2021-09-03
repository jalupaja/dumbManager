
namespace dumbManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PnlSide = new System.Windows.Forms.Panel();
            this.TxtSyncResponse = new System.Windows.Forms.TextBox();
            this.BtnSync = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.BtnPwdGen = new System.Windows.Forms.Button();
            this.BtnManager = new System.Windows.Forms.Button();
            this.PnlTopLeft = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.LblMain = new System.Windows.Forms.Label();
            this.PnlFormLoader = new System.Windows.Forms.Panel();
            this.PnlSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlSide
            // 
            this.PnlSide.AutoScroll = true;
            this.PnlSide.AutoSize = true;
            this.PnlSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PnlSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlSide.Controls.Add(this.TxtSyncResponse);
            this.PnlSide.Controls.Add(this.BtnSync);
            this.PnlSide.Controls.Add(this.BtnSettings);
            this.PnlSide.Controls.Add(this.BtnPwdGen);
            this.PnlSide.Controls.Add(this.BtnManager);
            this.PnlSide.Controls.Add(this.PnlTopLeft);
            this.PnlSide.Controls.Add(this.button1);
            this.PnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlSide.Location = new System.Drawing.Point(0, 0);
            this.PnlSide.Name = "PnlSide";
            this.PnlSide.Size = new System.Drawing.Size(178, 450);
            this.PnlSide.TabIndex = 0;
            // 
            // TxtSyncResponse
            // 
            this.TxtSyncResponse.BackColor = System.Drawing.Color.Black;
            this.TxtSyncResponse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSyncResponse.Enabled = false;
            this.TxtSyncResponse.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtSyncResponse.ForeColor = System.Drawing.Color.White;
            this.TxtSyncResponse.Location = new System.Drawing.Point(7, 342);
            this.TxtSyncResponse.Multiline = true;
            this.TxtSyncResponse.Name = "TxtSyncResponse";
            this.TxtSyncResponse.Size = new System.Drawing.Size(164, 65);
            this.TxtSyncResponse.TabIndex = 5;
            this.TxtSyncResponse.TabStop = false;
            this.TxtSyncResponse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnSync
            // 
            this.BtnSync.BackColor = System.Drawing.Color.DimGray;
            this.BtnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSync.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSync.Location = new System.Drawing.Point(22, 308);
            this.BtnSync.Name = "BtnSync";
            this.BtnSync.Size = new System.Drawing.Size(134, 28);
            this.BtnSync.TabIndex = 4;
            this.BtnSync.Text = "Sync";
            this.BtnSync.UseVisualStyleBackColor = false;
            this.BtnSync.Click += new System.EventHandler(this.BtnSync_Click);
            // 
            // BtnSettings
            // 
            this.BtnSettings.BackColor = System.Drawing.Color.DimGray;
            this.BtnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSettings.Location = new System.Drawing.Point(0, 413);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(176, 35);
            this.BtnSettings.TabIndex = 3;
            this.BtnSettings.Text = "Settings";
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // BtnPwdGen
            // 
            this.BtnPwdGen.BackColor = System.Drawing.Color.DimGray;
            this.BtnPwdGen.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnPwdGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPwdGen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnPwdGen.Location = new System.Drawing.Point(0, 85);
            this.BtnPwdGen.Name = "BtnPwdGen";
            this.BtnPwdGen.Size = new System.Drawing.Size(176, 35);
            this.BtnPwdGen.TabIndex = 2;
            this.BtnPwdGen.Text = "Password Generator";
            this.BtnPwdGen.UseVisualStyleBackColor = false;
            this.BtnPwdGen.Click += new System.EventHandler(this.BtnPwdGen_Click);
            // 
            // BtnManager
            // 
            this.BtnManager.BackColor = System.Drawing.Color.DimGray;
            this.BtnManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnManager.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnManager.Location = new System.Drawing.Point(0, 50);
            this.BtnManager.Name = "BtnManager";
            this.BtnManager.Size = new System.Drawing.Size(176, 35);
            this.BtnManager.TabIndex = 1;
            this.BtnManager.Text = "Password Manager";
            this.BtnManager.UseVisualStyleBackColor = true;
            this.BtnManager.Click += new System.EventHandler(this.BtnManager_Click);
            // 
            // PnlTopLeft
            // 
            this.PnlTopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlTopLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTopLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlTopLeft.Name = "PnlTopLeft";
            this.PnlTopLeft.Size = new System.Drawing.Size(176, 50);
            this.PnlTopLeft.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.Font = new System.Drawing.Font("Mongolian Baiti", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblMain.ForeColor = System.Drawing.Color.DarkGray;
            this.LblMain.Location = new System.Drawing.Point(347, 9);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(286, 35);
            this.LblMain.TabIndex = 1;
            this.LblMain.Text = "Password Manager";
            // 
            // PnlFormLoader
            // 
            this.PnlFormLoader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlFormLoader.Location = new System.Drawing.Point(178, 50);
            this.PnlFormLoader.Name = "PnlFormLoader";
            this.PnlFormLoader.Size = new System.Drawing.Size(622, 400);
            this.PnlFormLoader.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PnlFormLoader);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.PnlSide);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "dumbManager";
            this.PnlSide.ResumeLayout(false);
            this.PnlSide.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlSide;
        private System.Windows.Forms.Button BtnPwdGen;
        private System.Windows.Forms.Button BtnManager;
        private System.Windows.Forms.Panel PnlTopLeft;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label LblMain;
        private System.Windows.Forms.Panel PnlFormLoader;
        private System.Windows.Forms.TextBox TxtSyncResponse;
        private System.Windows.Forms.Button BtnSync;
    }
}

