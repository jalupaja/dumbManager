
namespace dumbManager
{
    partial class FrmPwdGen
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
            this.checkLowercase = new System.Windows.Forms.CheckBox();
            this.checkUppercase = new System.Windows.Forms.CheckBox();
            this.checkNumbers = new System.Windows.Forms.CheckBox();
            this.checkSpecialChar = new System.Windows.Forms.CheckBox();
            this.TxtPwdOut = new System.Windows.Forms.TextBox();
            this.BtnPwdCopy = new System.Windows.Forms.Button();
            this.TxtPwdLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnPwdCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkLowercase
            // 
            this.checkLowercase.AutoSize = true;
            this.checkLowercase.Checked = true;
            this.checkLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLowercase.ForeColor = System.Drawing.Color.LightGray;
            this.checkLowercase.Location = new System.Drawing.Point(56, 102);
            this.checkLowercase.Name = "checkLowercase";
            this.checkLowercase.Size = new System.Drawing.Size(99, 19);
            this.checkLowercase.TabIndex = 1;
            this.checkLowercase.Text = "use lowercase";
            this.checkLowercase.UseVisualStyleBackColor = true;
            this.checkLowercase.CheckStateChanged += new System.EventHandler(this.checkLowercase_CheckStateChanged);
            // 
            // checkUppercase
            // 
            this.checkUppercase.AutoSize = true;
            this.checkUppercase.Checked = true;
            this.checkUppercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUppercase.ForeColor = System.Drawing.Color.LightGray;
            this.checkUppercase.Location = new System.Drawing.Point(56, 127);
            this.checkUppercase.Name = "checkUppercase";
            this.checkUppercase.Size = new System.Drawing.Size(101, 19);
            this.checkUppercase.TabIndex = 2;
            this.checkUppercase.Text = "use uppercase";
            this.checkUppercase.UseVisualStyleBackColor = true;
            this.checkUppercase.CheckStateChanged += new System.EventHandler(this.checkUppercase_CheckStateChanged);
            // 
            // checkNumbers
            // 
            this.checkNumbers.AutoSize = true;
            this.checkNumbers.Checked = true;
            this.checkNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNumbers.ForeColor = System.Drawing.Color.LightGray;
            this.checkNumbers.Location = new System.Drawing.Point(56, 152);
            this.checkNumbers.Name = "checkNumbers";
            this.checkNumbers.Size = new System.Drawing.Size(94, 19);
            this.checkNumbers.TabIndex = 3;
            this.checkNumbers.Text = "use numbers";
            this.checkNumbers.UseVisualStyleBackColor = true;
            this.checkNumbers.CheckStateChanged += new System.EventHandler(this.checkNumbers_CheckStateChanged);
            // 
            // checkSpecialChar
            // 
            this.checkSpecialChar.AutoSize = true;
            this.checkSpecialChar.Checked = true;
            this.checkSpecialChar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSpecialChar.ForeColor = System.Drawing.Color.LightGray;
            this.checkSpecialChar.Location = new System.Drawing.Point(56, 177);
            this.checkSpecialChar.Name = "checkSpecialChar";
            this.checkSpecialChar.Size = new System.Drawing.Size(140, 19);
            this.checkSpecialChar.TabIndex = 4;
            this.checkSpecialChar.Text = "use special characters";
            this.checkSpecialChar.UseVisualStyleBackColor = true;
            this.checkSpecialChar.CheckStateChanged += new System.EventHandler(this.checkSpecialChar_CheckStateChanged);
            // 
            // TxtPwdOut
            // 
            this.TxtPwdOut.BackColor = System.Drawing.Color.DimGray;
            this.TxtPwdOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPwdOut.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPwdOut.Location = new System.Drawing.Point(56, 235);
            this.TxtPwdOut.Name = "TxtPwdOut";
            this.TxtPwdOut.ReadOnly = true;
            this.TxtPwdOut.Size = new System.Drawing.Size(509, 25);
            this.TxtPwdOut.TabIndex = 4;
            this.TxtPwdOut.TabStop = false;
            // 
            // BtnPwdCopy
            // 
            this.BtnPwdCopy.AutoSize = true;
            this.BtnPwdCopy.BackColor = System.Drawing.Color.Gray;
            this.BtnPwdCopy.FlatAppearance.BorderSize = 0;
            this.BtnPwdCopy.ForeColor = System.Drawing.Color.White;
            this.BtnPwdCopy.Location = new System.Drawing.Point(490, 235);
            this.BtnPwdCopy.Name = "BtnPwdCopy";
            this.BtnPwdCopy.Size = new System.Drawing.Size(75, 25);
            this.BtnPwdCopy.TabIndex = 5;
            this.BtnPwdCopy.Text = "copy";
            this.BtnPwdCopy.UseVisualStyleBackColor = false;
            this.BtnPwdCopy.Click += new System.EventHandler(this.BtnPwdCopy_Click);
            // 
            // TxtPwdLength
            // 
            this.TxtPwdLength.BackColor = System.Drawing.Color.DimGray;
            this.TxtPwdLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPwdLength.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPwdLength.Location = new System.Drawing.Point(56, 64);
            this.TxtPwdLength.Name = "TxtPwdLength";
            this.TxtPwdLength.Size = new System.Drawing.Size(46, 22);
            this.TxtPwdLength.TabIndex = 0;
            this.TxtPwdLength.Text = "20";
            this.TxtPwdLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtPwdLength.TextChanged += new System.EventHandler(this.TxtPwdLength_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(118, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "password length";
            // 
            // BtnPwdCreate
            // 
            this.BtnPwdCreate.BackColor = System.Drawing.Color.DimGray;
            this.BtnPwdCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPwdCreate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnPwdCreate.Location = new System.Drawing.Point(56, 12);
            this.BtnPwdCreate.Name = "BtnPwdCreate";
            this.BtnPwdCreate.Size = new System.Drawing.Size(140, 35);
            this.BtnPwdCreate.TabIndex = 7;
            this.BtnPwdCreate.Text = "new Password";
            this.BtnPwdCreate.UseVisualStyleBackColor = false;
            this.BtnPwdCreate.Click += new System.EventHandler(this.BtnPwdCreate_Click);
            // 
            // FrmPwdGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 400);
            this.Controls.Add(this.BtnPwdCreate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPwdLength);
            this.Controls.Add(this.BtnPwdCopy);
            this.Controls.Add(this.TxtPwdOut);
            this.Controls.Add(this.checkSpecialChar);
            this.Controls.Add(this.checkNumbers);
            this.Controls.Add(this.checkUppercase);
            this.Controls.Add(this.checkLowercase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPwdGen";
            this.Text = "FrmPwdGen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkLowercase;
        private System.Windows.Forms.CheckBox checkUppercase;
        private System.Windows.Forms.CheckBox checkNumbers;
        private System.Windows.Forms.CheckBox checkSpecialChar;
        private System.Windows.Forms.TextBox TxtPwdOut;
        private System.Windows.Forms.Button BtnPwdCopy;
        private System.Windows.Forms.TextBox TxtPwdLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnPwdCreate;
    }
}