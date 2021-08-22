
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
            this.LblName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.LblUsername = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblPass = new System.Windows.Forms.Label();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.LblUrl = new System.Windows.Forms.Label();
            this.TxtNotes = new System.Windows.Forms.TextBox();
            this.LblNotes = new System.Windows.Forms.Label();
            this.BtnSeePass = new System.Windows.Forms.Button();
            this.BtnOpenUrl = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
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
            this.TxtHeader.Location = new System.Drawing.Point(12, -5);
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
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.Transparent;
            this.LblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblName.ForeColor = System.Drawing.Color.White;
            this.LblName.Location = new System.Drawing.Point(30, 16);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(41, 15);
            this.LblName.TabIndex = 6;
            this.LblName.Text = "Name";
            // 
            // TxtName
            // 
            this.TxtName.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtName.ForeColor = System.Drawing.Color.Black;
            this.TxtName.Location = new System.Drawing.Point(42, 38);
            this.TxtName.Name = "TxtName";
            this.TxtName.PlaceholderText = " enter a Name";
            this.TxtName.Size = new System.Drawing.Size(250, 20);
            this.TxtName.TabIndex = 1;
            // 
            // TxtUsername
            // 
            this.TxtUsername.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtUsername.ForeColor = System.Drawing.Color.Black;
            this.TxtUsername.Location = new System.Drawing.Point(42, 95);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.PlaceholderText = " enter a Username";
            this.TxtUsername.Size = new System.Drawing.Size(250, 20);
            this.TxtUsername.TabIndex = 7;
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.BackColor = System.Drawing.Color.Transparent;
            this.LblUsername.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUsername.ForeColor = System.Drawing.Color.White;
            this.LblUsername.Location = new System.Drawing.Point(30, 73);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(66, 15);
            this.LblUsername.TabIndex = 8;
            this.LblUsername.Text = "Username";
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPassword.ForeColor = System.Drawing.Color.Black;
            this.TxtPassword.Location = new System.Drawing.Point(42, 153);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PlaceholderText = " enter a Password";
            this.TxtPassword.Size = new System.Drawing.Size(250, 20);
            this.TxtPassword.TabIndex = 9;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // LblPass
            // 
            this.LblPass.AutoSize = true;
            this.LblPass.BackColor = System.Drawing.Color.Transparent;
            this.LblPass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblPass.ForeColor = System.Drawing.Color.White;
            this.LblPass.Location = new System.Drawing.Point(30, 131);
            this.LblPass.Name = "LblPass";
            this.LblPass.Size = new System.Drawing.Size(63, 15);
            this.LblPass.TabIndex = 10;
            this.LblPass.Text = "Password";
            // 
            // TxtUrl
            // 
            this.TxtUrl.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUrl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtUrl.ForeColor = System.Drawing.Color.Black;
            this.TxtUrl.Location = new System.Drawing.Point(42, 212);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.PlaceholderText = " enter a Url";
            this.TxtUrl.Size = new System.Drawing.Size(250, 20);
            this.TxtUrl.TabIndex = 11;
            // 
            // LblUrl
            // 
            this.LblUrl.AutoSize = true;
            this.LblUrl.BackColor = System.Drawing.Color.Transparent;
            this.LblUrl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUrl.ForeColor = System.Drawing.Color.White;
            this.LblUrl.Location = new System.Drawing.Point(30, 190);
            this.LblUrl.Name = "LblUrl";
            this.LblUrl.Size = new System.Drawing.Size(23, 15);
            this.LblUrl.TabIndex = 12;
            this.LblUrl.Text = "Url";
            // 
            // TxtNotes
            // 
            this.TxtNotes.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNotes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtNotes.ForeColor = System.Drawing.Color.Black;
            this.TxtNotes.Location = new System.Drawing.Point(41, 267);
            this.TxtNotes.Multiline = true;
            this.TxtNotes.Name = "TxtNotes";
            this.TxtNotes.Size = new System.Drawing.Size(250, 55);
            this.TxtNotes.TabIndex = 13;
            // 
            // LblNotes
            // 
            this.LblNotes.AutoSize = true;
            this.LblNotes.BackColor = System.Drawing.Color.Transparent;
            this.LblNotes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNotes.ForeColor = System.Drawing.Color.White;
            this.LblNotes.Location = new System.Drawing.Point(29, 245);
            this.LblNotes.Name = "LblNotes";
            this.LblNotes.Size = new System.Drawing.Size(40, 15);
            this.LblNotes.TabIndex = 14;
            this.LblNotes.Text = "Notes";
            // 
            // BtnSeePass
            // 
            this.BtnSeePass.BackColor = System.Drawing.Color.Transparent;
            this.BtnSeePass.FlatAppearance.BorderSize = 0;
            this.BtnSeePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSeePass.ForeColor = System.Drawing.Color.White;
            this.BtnSeePass.Location = new System.Drawing.Point(248, 151);
            this.BtnSeePass.Name = "BtnSeePass";
            this.BtnSeePass.Size = new System.Drawing.Size(44, 24);
            this.BtnSeePass.TabIndex = 37;
            this.BtnSeePass.Text = "see";
            this.BtnSeePass.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSeePass.UseVisualStyleBackColor = false;
            this.BtnSeePass.Click += new System.EventHandler(this.BtnSeePass_Click);
            // 
            // BtnOpenUrl
            // 
            this.BtnOpenUrl.BackColor = System.Drawing.Color.Transparent;
            this.BtnOpenUrl.FlatAppearance.BorderSize = 0;
            this.BtnOpenUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpenUrl.ForeColor = System.Drawing.Color.White;
            this.BtnOpenUrl.Location = new System.Drawing.Point(248, 210);
            this.BtnOpenUrl.Name = "BtnOpenUrl";
            this.BtnOpenUrl.Size = new System.Drawing.Size(44, 24);
            this.BtnOpenUrl.TabIndex = 39;
            this.BtnOpenUrl.Text = "Open";
            this.BtnOpenUrl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnOpenUrl.UseVisualStyleBackColor = false;
            this.BtnOpenUrl.Click += new System.EventHandler(this.BtnOpenUrl_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnDel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnDel.BackColor = System.Drawing.Color.Maroon;
            this.BtnDel.FlatAppearance.BorderSize = 0;
            this.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnDel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnDel.Location = new System.Drawing.Point(284, 2);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(39, 29);
            this.BtnDel.TabIndex = 40;
            this.BtnDel.Text = "Del";
            this.BtnDel.UseVisualStyleBackColor = false;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(335, 400);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnOpenUrl);
            this.Controls.Add(this.BtnSeePass);
            this.Controls.Add(this.TxtNotes);
            this.Controls.Add(this.LblNotes);
            this.Controls.Add(this.TxtUrl);
            this.Controls.Add(this.LblUrl);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.LblPass);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LblName);
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
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblPass;
        private System.Windows.Forms.TextBox TxtUrl;
        private System.Windows.Forms.Label LblUrl;
        private System.Windows.Forms.TextBox TxtNotes;
        private System.Windows.Forms.Label LblNotes;
        private System.Windows.Forms.Button BtnSeePass;
        private System.Windows.Forms.Button BtnOpenUrl;
        private System.Windows.Forms.Button BtnDel;
    }
}