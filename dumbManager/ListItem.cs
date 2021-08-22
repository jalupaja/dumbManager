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
    public partial class ListItem : UserControl
    {
        public int id;
        private FrmManager parent = null;
        public ListItem(string name, string username, string picUrl, int id, FrmManager parent)
        {
            InitializeComponent();
            BackColor = Properties.Settings.Default.AccentColor;
            LblName.Text = name;
            LblUsername.Text = username;
            this.id = id;
            this.parent = parent;

            try
            {
                Pic.ImageLocation = ("https://" + new Uri(picUrl).Host + "/favicon.ico");
            }
            catch(Exception)
            {
                //Pic.ImageLocation = ""; //!!! Set to default web picture
            }
        }

        private void ListItem_Click(object sender, EventArgs e)
        {
            parent.selectedId = id;
            parent.Clear();
        }
    }
}
