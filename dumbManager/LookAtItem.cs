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
            Txt2FA.BackColor = Properties.Settings.Default.AccentColor;
            TxtNotes.BackColor = Properties.Settings.Default.AccentColor;
        }

        public void Clear(string name, string username, string password, string url, string twoFA, string notes)
        {
            TxtPassword.UseSystemPasswordChar = true;
            Txt2FA.UseSystemPasswordChar = true;
            //Write all items to textbox
            TxtName.Text = name;
            TxtUsername.Text = username;
            TxtPassword.Text = password;
            TxtUrl.Text = url;

            if (twoFA != "")
            {
                try
                {   //credits: https://github.com/selway/totp/tree/master/src/TOTP/TOTP.Core //!!! Not Working
                    Txt2FA.Text = "" + TOTP.GenerateTOTP(Encoding.ASCII.GetBytes(twoFA)) + " : " + TOTP.GenerateTOTP(DateTime.UtcNow, Encoding.ASCII.GetBytes(twoFA)) + " : " + TOTP.GenerateTOTP(DateTime.Now, Encoding.ASCII.GetBytes(twoFA));
                }
                catch (Exception)
                {
                    Txt2FA.Text = "";
                }
            }
            else
                Txt2FA.Text = "";

            TxtNotes.Text = notes;

            //set TxtHeader
            if (name == "")
            {
                TxtHeader.Text = "VIEW " + name;
            }
            else
            {
                TxtHeader.Text = "VIEW ITEM";
            }
            TxtHeader.ForeColor = Color.White;
        }
        private void TxtUrl_OPEN(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {TxtUrl.Text}") { CreateNoWindow = false });
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

        private void BtnCopy2FA_Click(object sender, EventArgs e)
        {
            try { Clipboard.SetText(Txt2FA.Text); } catch (Exception) { }
        }

        private void BtnSee2FA_Click(object sender, EventArgs e)
        {
            if (Txt2FA.UseSystemPasswordChar)
            {
                Txt2FA.UseSystemPasswordChar = false;
                BtnSee2FA.Text = "hide";
            }
            else
            {
                Txt2FA.UseSystemPasswordChar = true;
                BtnSee2FA.Text = "see";
            }
        }
    }
}
