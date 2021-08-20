using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dumbManager
{
    public partial class FrmManager : Form
    {
        EditItem EditItem_Vrb = new EditItem() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        LookAtItem ViewItem_Vrb = new LookAtItem() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        protected SQLiteConnection con = null;
        protected List<dumbManager> actualList = new List<dumbManager>();

        public Form1 parent = null;

        public class dumbManager
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Url { get; set; }
            public string Note { get; set; }
        }

        public FrmManager()
        {
            InitializeComponent();
            ListManager.BackColor = Properties.Settings.Default.AccentColor;
            TxtSearch.BackColor = Properties.Settings.Default.AccentColor;
            BtnAddItem.BackColor = Properties.Settings.Default.AccentColor;
            BtnEditItem.BackColor = Properties.Settings.Default.AccentColor;

            EditItem_Vrb.parent = this;
            ViewItem_Vrb.parent = this;
        }

        public void CloseCon()
        {
            if (con != null)
            {
                con.Close();
            }
        }
        public void newConnection(SQLiteConnection c)
        {
            con = c;
        }
        public void newFile()
        {
            con.CreateTable<dumbManager>();
        }
        public void TxtSearch_TextChanged(object sender, EventArgs e)//List stuff
        {
            if (TxtSearch.Text == " search items" || TxtSearch.Text == "")
            {
                ListManager.Clear();
                ListManager.BeginUpdate();
                actualList = new List<dumbManager>();
                //!!!
                var result = con.Table<dumbManager>().ToList();
                foreach (var item in result)
                {
                    actualList.Add(item);
                    ListManager.Items.Add(new ListViewItem(item.Name + " --- " + item.Username));
                }

                ListManager.EndUpdate();
            }
            else
            {
                ListManager.Clear();
                ListManager.BeginUpdate();
                actualList = new List<dumbManager>();
                //!!!
                var result = con.Table<dumbManager>().Where(x => x.Name == TxtSearch.Text).ToList();
                foreach (var item in result)
                {
                    actualList.Add(item);
                    ListManager.Items.Add(new ListViewItem(item.Name + " --- " + item.Username));
                }

                ListManager.EndUpdate();
            }           
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            this.PnlViewEditLoader.Controls.Clear();
            EditItem_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlViewEditLoader.Controls.Add(EditItem_Vrb);
            EditItem_Vrb.Clear("", "", "", "", "");
            EditItem_Vrb.Show();
        }
        public void Add(string name, string username, string password, string url, string note)
        {
            var n = new dumbManager
            {
                Name = name,
                Username = username,
                Password = password,
                Url = url,
                Note = note
            };
            con.Insert(n);
            n.Name = "";
            n.Username = "";
            n.Password = "";
            n.Url = "";
            n.Note = "";
            Clear();
        }
        public void Clear()
        {
            /*
            if () //!!! if not clicked on any item
            {
                this.PnlViewEditLoader.Controls.Clear();
            }
            else
            {
                this.PnlViewEditLoader.Controls.Clear();
                ViewItem_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlViewEditLoader.Controls.Add(ViewItem_Vrb);
                ViewItem_Vrb.Clear("", "", "", "", "");//!!! Insert selected Items
                ViewItem_Vrb.Show();
            }
            */
            this.PnlViewEditLoader.Controls.Clear(); //!!! del this
        }
        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            /* 
            if () //!!! if not clicked on any item
            {
                BtnAddItem_Click(null, null);
                return;
            }
            */
            this.PnlViewEditLoader.Controls.Clear();
            EditItem_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlViewEditLoader.Controls.Add(EditItem_Vrb);
            EditItem_Vrb.Clear("", "", "", "", "");//!!! Insert from viewed Item
            EditItem_Vrb.Show();
            
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (TxtSearch.Text == " search items")
            {
                TxtSearch.Text = "";
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (TxtSearch.Text == "")
            {
                TxtSearch.Text = " search items";
            }
        }
    }
}
