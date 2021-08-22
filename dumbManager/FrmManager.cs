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
            ColorReload();

            EditItem_Vrb.parent = this;
            ViewItem_Vrb.parent = this;
            selectedId = -1;
        }

        public void ColorReload()
        {
            TxtSearch.BackColor = Properties.Settings.Default.AccentColor;
            BtnAddItem.BackColor = Properties.Settings.Default.AccentColor;
            BtnEditItem.BackColor = Properties.Settings.Default.AccentColor;
        }

        public int selectedId { get; set; }
        public int maxId { get; set; }

        public void newConnection(SQLiteConnection c)
        {
            con = c;
        }
        public void newFile()
        {
            con.CreateTable<dumbManager>();
        }
        public void loadMax()
        {
            var result = con.Table<dumbManager>().ToList();
            foreach (var item in result)
            {
                maxId = item.Id;
            }
        }
        public void TxtSearch_TextChanged(object sender, EventArgs e)//List stuff
        {
            if (TxtSearch.Text == "")
            {
                PnlList.Controls.Clear();
                var result = con.Table<dumbManager>().ToList();
                foreach (var item in result)
                {
                    PnlList.Controls.Add(new ListItem(item.Name, item.Username, item.Url, item.Id, this));
                }
            }
            else
            {
                PnlList.Controls.Clear();
                var result = con.Table<dumbManager>().Where(x => x.Name.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
                foreach (var item in result)
                {
                    PnlList.Controls.Add(new ListItem(item.Name, item.Username, item.Url, item.Id, this));
                }
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
        {//!!! update SQL file
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
            TxtSearch_TextChanged(null, null);
        }
        public void Change(int id, string name, string username, string password, string url, string note)
        {//!!! update SQL file
            var n = new dumbManager();
            n.Id = id;
            n.Name = name;
            n.Username = username;
            n.Password = password;
            n.Url = url;
            n.Note = note;
            con.Update(n);
            Clear();
            TxtSearch_TextChanged(null, null);
        }
        public void Del(int id)
        {//!!! update SQL file
            var n = new dumbManager();
            n.Id = id;
            con.Delete(n);
            Clear();
            TxtSearch_TextChanged(null, null);

        }
        public void Clear()
        {
            this.PnlViewEditLoader.Controls.Clear();
            if (selectedId == -1)
            {
                ViewItem_Vrb.Clear("", "", "", "", "");
                EditItem_Vrb.Clear("", "", "", "", "");
            }
            else
            {
                ViewItem_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlViewEditLoader.Controls.Add(ViewItem_Vrb);
                var result = con.Table<dumbManager>().ToList();
                foreach (var item in result)
                { 
                    if(item.Id == selectedId)
                    {
                        ViewItem_Vrb.Clear(item.Name, item.Username, item.Password, item.Url, item.Note);//!!! Insert selected Items
                    }
                }
                ViewItem_Vrb.Show();
            }
        }
        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            this.PnlViewEditLoader.Controls.Clear();
            if (selectedId == -1)
            {
                ViewItem_Vrb.Clear("", "", "", "", "");
                EditItem_Vrb.Clear("", "", "", "", "");
            }
            else
            {
                EditItem_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlViewEditLoader.Controls.Add(EditItem_Vrb);
                var result = con.Table<dumbManager>().ToList();
                foreach (var item in result)
                {
                    if (item.Id == selectedId)
                    {
                        EditItem_Vrb.Clear(item.Name, item.Username, item.Password, item.Url, item.Note);
                    }
                }
                EditItem_Vrb.Show();
            }           
        }
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            selectedId = -1;
            Clear();
            con.Close();
            parent.Logout();
        }
    }
}
