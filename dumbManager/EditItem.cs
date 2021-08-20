using System;
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

        string name, username, password, url, note; //!!! del this

        public EditItem()
        {
            InitializeComponent();
        }

        public void Clear(string name, string username, string password, string url, string note)
        {
            //Write all items to textbox
            

            //set TxtHeader
            if (name == "" && username == "" && password == "" && url == "" && note == "")
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
            parent.Add(name, username, password, url, note);
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            parent.Clear();
        }
    }
}
