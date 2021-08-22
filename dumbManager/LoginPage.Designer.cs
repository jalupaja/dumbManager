
namespace dumbManager
{
    partial class LoginPage
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
            this.BtnLogin = new System.Windows.Forms.Button();
            this.TxtFileIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPwd = new System.Windows.Forms.TextBox();
            this.TxtResponse = new System.Windows.Forms.TextBox();
            this.TxtFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.DimGray;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLogin.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnLogin.Location = new System.Drawing.Point(137, 246);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(350, 60);
            this.BtnLogin.TabIndex = 3;
            this.BtnLogin.Text = "create new user";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // TxtFileIn
            // 
            this.TxtFileIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtFileIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtFileIn.Location = new System.Drawing.Point(137, 143);
            this.TxtFileIn.Name = "TxtFileIn";
            this.TxtFileIn.PlaceholderText = " enter username";
            this.TxtFileIn.Size = new System.Drawing.Size(350, 20);
            this.TxtFileIn.TabIndex = 1;
            this.TxtFileIn.TextChanged += new System.EventHandler(this.TxtFileIn_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // TxtPwd
            // 
            this.TxtPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPwd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPwd.Location = new System.Drawing.Point(137, 184);
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.PlaceholderText = " enter password";
            this.TxtPwd.Size = new System.Drawing.Size(350, 20);
            this.TxtPwd.TabIndex = 2;
            this.TxtPwd.UseSystemPasswordChar = true;
            // 
            // TxtResponse
            // 
            this.TxtResponse.BackColor = System.Drawing.Color.Black;
            this.TxtResponse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtResponse.Enabled = false;
            this.TxtResponse.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtResponse.ForeColor = System.Drawing.Color.White;
            this.TxtResponse.HideSelection = false;
            this.TxtResponse.Location = new System.Drawing.Point(137, 46);
            this.TxtResponse.Multiline = true;
            this.TxtResponse.Name = "TxtResponse";
            this.TxtResponse.ReadOnly = true;
            this.TxtResponse.Size = new System.Drawing.Size(350, 59);
            this.TxtResponse.TabIndex = 5;
            this.TxtResponse.TabStop = false;
            this.TxtResponse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtFilePath
            // 
            this.TxtFilePath.BackColor = System.Drawing.Color.Black;
            this.TxtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtFilePath.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TxtFilePath.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtFilePath.Location = new System.Drawing.Point(137, 336);
            this.TxtFilePath.Multiline = true;
            this.TxtFilePath.Name = "TxtFilePath";
            this.TxtFilePath.ReadOnly = true;
            this.TxtFilePath.Size = new System.Drawing.Size(359, 47);
            this.TxtFilePath.TabIndex = 6;
            this.TxtFilePath.TabStop = false;
            this.TxtFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtFilePath.Click += new System.EventHandler(this.TxtFilePath_Click);
            this.TxtFilePath.DoubleClick += new System.EventHandler(this.TxtFilePath_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 400);
            this.Controls.Add(this.TxtFilePath);
            this.Controls.Add(this.TxtResponse);
            this.Controls.Add(this.TxtPwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFileIn);
            this.Controls.Add(this.BtnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginPage";
            this.Text = "LoginPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.TextBox TxtFileIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPwd;
        private System.Windows.Forms.TextBox TxtResponse;
        private System.Windows.Forms.TextBox TxtFilePath;
    }
}