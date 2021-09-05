
namespace dumbManager
{
    partial class FrmLittleBox
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
            this.TxtIn = new System.Windows.Forms.TextBox();
            this.TxtOut = new System.Windows.Forms.TextBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TxtTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtIn
            // 
            this.TxtIn.BackColor = System.Drawing.Color.DimGray;
            this.TxtIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtIn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtIn.ForeColor = System.Drawing.Color.White;
            this.TxtIn.Location = new System.Drawing.Point(0, 26);
            this.TxtIn.Multiline = true;
            this.TxtIn.Name = "TxtIn";
            this.TxtIn.ReadOnly = true;
            this.TxtIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtIn.Size = new System.Drawing.Size(549, 126);
            this.TxtIn.TabIndex = 0;
            // 
            // TxtOut
            // 
            this.TxtOut.BackColor = System.Drawing.Color.DimGray;
            this.TxtOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtOut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtOut.ForeColor = System.Drawing.Color.White;
            this.TxtOut.Location = new System.Drawing.Point(49, 158);
            this.TxtOut.Name = "TxtOut";
            this.TxtOut.Size = new System.Drawing.Size(453, 20);
            this.TxtOut.TabIndex = 1;
            this.TxtOut.Visible = false;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.DimGray;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.ForeColor = System.Drawing.Color.White;
            this.BtnOk.Location = new System.Drawing.Point(105, 189);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(78, 23);
            this.BtnOk.TabIndex = 3;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.DimGray;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(367, 189);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TxtTitle
            // 
            this.TxtTitle.BackColor = System.Drawing.Color.Black;
            this.TxtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TxtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtTitle.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtTitle.ForeColor = System.Drawing.Color.White;
            this.TxtTitle.Location = new System.Drawing.Point(0, 0);
            this.TxtTitle.Name = "TxtTitle";
            this.TxtTitle.ReadOnly = true;
            this.TxtTitle.Size = new System.Drawing.Size(549, 22);
            this.TxtTitle.TabIndex = 5;
            this.TxtTitle.TabStop = false;
            this.TxtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmLittleBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(549, 224);
            this.Controls.Add(this.TxtTitle);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TxtOut);
            this.Controls.Add(this.TxtIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLittleBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmLittleBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtIn;
        private System.Windows.Forms.TextBox TxtOut;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TxtTitle;
    }
}