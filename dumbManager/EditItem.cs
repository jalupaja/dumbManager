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
    public partial class EditItem : Form
    {
        public FrmManager parent = null;

        FrmPwdGenBox FrmPwdGenBox_Vrb = new FrmPwdGenBox() { TopLevel = true, TopMost = true };

        private bool newAcc = false;

        public EditItem()
        {
            InitializeComponent();
            this.ActiveControl = TxtName;
            FrmPwdGenBox_Vrb.parent = this;
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
            BtnCancel.BackColor = Properties.Settings.Default.AccentColor;
            BtnSafe.BackColor = Properties.Settings.Default.AccentColor;
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
            Txt2FA.Text = twoFA;
            TxtNotes.Text = notes;

            //set TxtHeader
            if (name == "" && username == "" && password == "" && url == "" && notes == "")
            {
                newAcc = true;
                TxtHeader.Text = "CREATE NEW ITEM";
                TxtHeader.ForeColor = Color.White;
            }
            else
            {
                newAcc = false;
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
        }
        private void BtnSafe_Click(object sender, EventArgs e)
        {
            if (newAcc)
            {
                parent.maxId++;
                parent.selectedId = parent.maxId;
                parent.Add(TxtName.Text, TxtUsername.Text, TxtPassword.Text, TxtUrl.Text, Txt2FA.Text, TxtNotes.Text);
            }
            else
            {
                parent.Change(parent.selectedId, TxtName.Text, TxtUsername.Text, TxtPassword.Text, TxtUrl.Text, Txt2FA.Text, TxtNotes.Text);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            parent.Clear();
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
        private void BtnOpenUrl_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {TxtUrl.Text}") { CreateNoWindow = false });
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            //!!! Ask if really want to delete
            parent.Del(parent.selectedId, TxtName.Text, TxtUsername.Text, TxtUrl.Text);
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

        private void BtnNewPwd_Click(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "" || MessageBox.Show("Do you really want to overwrite the password?", "Overwrite Password", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                FrmPwdGenBox_Vrb.ShowDialog();
                parent.parent.Lock();
            }
        }
        public void ClosePwd()
        {
            FrmPwdGenBox_Vrb.Hide();
            parent.parent.Lock();
        }
        public void SavePwd(string inp)
        {
            if (inp != "")
                TxtPassword.Text = inp;
            ClosePwd();
        }
    }
}