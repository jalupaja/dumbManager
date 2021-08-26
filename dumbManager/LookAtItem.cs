using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dumbManager
{
    public partial class LookAtItem : Form
    {
        public FrmManager parent = null;

        public LookAtItem()
        {
            InitializeComponent();
            this.ActiveControl = LblName;
            ColorReload();
        }

        public void ColorReload()
        {
            TxtName.BackColor = Properties.Settings.Default.AccentColor;
            TxtUsername.BackColor = Properties.Settings.Default.AccentColor;
            TxtPassword.BackColor = Properties.Settings.Default.AccentColor;
            TxtUrl.BackColor = Properties.Settings.Default.AccentColor;
            TxtNotes.BackColor = Properties.Settings.Default.AccentColor;
        }

        public void Clear(string name, string username, string password, string url, string notes)
        {
            //Write all items to textbox
            TxtName.Text = name;
            TxtUsername.Text = username;
            TxtPassword.Text = password;
            TxtUrl.Text = url;
            TxtNotes.Text = notes;

            //set TxtHeader
            if (name == "")
            {
                TxtHeader.Text = "EDIT " + name;
            }
            else
            {
                TxtHeader.Text = "EDIT ITEM";
            }
            TxtHeader.ForeColor = Color.White;
        }
        private void TxtUrl_OPEN(object sender, EventArgs e)
        {
            Process.Start(TxtUrl.Text);
        }

        private void BtnCopyName_Click(object sender, EventArgs e)
        {
            try{Clipboard.SetText(TxtName.Text); } catch (Exception) { }
        }
        private void BtnCopyUsername_Click(object sender, EventArgs e)
        {
            try{Clipboard.SetText(TxtUsername.Text); } catch (Exception) { }
        }
        private void BtnCopyPass_Click(object sender, EventArgs e)
        {
            try{Clipboard.SetText(TxtPassword.Text); } catch (Exception) { }
        }
        private void BtnSeePass_Click(object sender, EventArgs e)
        {
            if (TxtPassword.UseSystemPasswordChar)
            {
                TxtPassword.UseSystemPasswordChar = false;
                BtnSeePass.Text = "hide";
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = true;
                BtnSeePass.Text = "see";
            }
        }
        private void BtnCopyUrl_Click(object sender, EventArgs e)
        {
            try{Clipboard.SetText(TxtUrl.Text); } catch (Exception) { }
        }
        private void BtnCopyNotes_Click(object sender, EventArgs e)
        {
            try { Clipboard.SetText(TxtNotes.Text); } catch (Exception) { }
        }
    }
}
