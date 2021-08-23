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
        private bool newAcc = false;
        public EditItem()
        {
            InitializeComponent();
            this.ActiveControl = TxtName;
            ColorReload();
        }

        public void ColorReload()
        {
            TxtName.BackColor = Properties.Settings.Default.AccentColor;
            TxtUsername.BackColor = Properties.Settings.Default.AccentColor;
            TxtPassword.BackColor = Properties.Settings.Default.AccentColor;
            TxtUrl.BackColor = Properties.Settings.Default.AccentColor;
            TxtNotes.BackColor = Properties.Settings.Default.AccentColor;
            BtnCancel.BackColor = Properties.Settings.Default.AccentColor;
            BtnSafe.BackColor = Properties.Settings.Default.AccentColor;
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
            if (name == "" && username == "" && password == "" && url == "" && notes == "")
            {
                newAcc = true;
                TxtHeader.Text = "CREATE NEW ITEM";
                TxtHeader.ForeColor = Color.White;
            }
            else
            {
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
                parent.Add(TxtName.Text, TxtUsername.Text, TxtPassword.Text, TxtUrl.Text, TxtNotes.Text);
            }
            else
            {
                parent.Change(parent.selectedId, TxtName.Text, TxtUsername.Text, TxtPassword.Text, TxtUrl.Text, TxtNotes.Text);
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
            Process.Start(TxtUrl.Text);
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            //!!! Ask if really want to delete
            parent.Del(parent.selectedId);
        }
    }
}
