
namespace dumbManager
{
    partial class ListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pic = new System.Windows.Forms.PictureBox();
            this.LblName = new System.Windows.Forms.Label();
            this.LblUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // Pic
            // 
            this.Pic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Pic.BackColor = System.Drawing.Color.Transparent;
            this.Pic.InitialImage = null;
            this.Pic.Location = new System.Drawing.Point(7, 7);
            this.Pic.Name = "Pic";
            this.Pic.Size = new System.Drawing.Size(51, 51);
            this.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic.TabIndex = 0;
            this.Pic.TabStop = false;
            this.Pic.Click += new System.EventHandler(this.ListItem_Click);
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblName.Location = new System.Drawing.Point(74, 7);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(53, 19);
            this.LblName.TabIndex = 1;
            this.LblName.Text = "Name";
            this.LblName.Click += new System.EventHandler(this.ListItem_Click);
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUsername.Location = new System.Drawing.Point(94, 30);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(80, 18);
            this.LblUsername.TabIndex = 2;
            this.LblUsername.Text = "Username";
            this.LblUsername.Click += new System.EventHandler(this.ListItem_Click);
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.Pic);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(270, 65);
            this.Click += new System.EventHandler(this.ListItem_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pic;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblUsername;
    }
}
