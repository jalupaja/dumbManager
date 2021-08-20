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

        public EditItem()
        {
            InitializeComponent();
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
            parent.Add(TxtName.Text, TxtUsername.Text, TxtPassword.Text, TxtUrl.Text, TxtNotes.Text);
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            parent.Clear();
        }
        private void TxtUrl_OPEN(object sender, EventArgs e)
        {
            Process.Start(TxtUrl.Text);
        }
    }
}
