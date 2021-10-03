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
        private int id;
        private FrmManager parent = null;
        private string oldUrl ="";
        public ListItem(string name, string username, string picUrl, int id, FrmManager parent)
        {
            InitializeComponent();
            this.Name = id.ToString();
            this.id = id;
            this.parent = parent;

            Init(name, username, picUrl);
            BackColor = Properties.Settings.Default.AccentColor;
        }

        public void Init(string name, string username, string picUrl)
        {
            LblName.Text = name;
            LblUsername.Text = username;

            if (oldUrl != picUrl)
            {
                oldUrl = picUrl;
                try
                {
                    //Pic.ImageLocation = ("https://" + new Uri(picUrl).Host + "/favicon.ico"); //using Favicons
                    Pic.ImageLocation = ("https://icons.bitwarden.net/" + new Uri(picUrl).Host + "/icon.png"); //using Bitwarden API
                }
                catch (Exception)
                {
                    //Pic.ImageLocation = ""; //!!! Set to default web picture
                }
            }
        }
        private void ListItem_Click(object sender, EventArgs e)
        {
            parent.selectedId = id;
            parent.Clear();
        }
    }
}
