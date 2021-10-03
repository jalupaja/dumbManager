using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;
using System.IO;

namespace dumbManager
{
    public partial class FrmManager : Form
    {
        EditItem EditItem_Vrb = new EditItem() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        LookAtItem ViewItem_Vrb = new LookAtItem() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        private ContextMenuStrip sMenu;
        private string sBy = "Name";
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
            public string TwoFA { get; set; }
            public string Note { get; set; }
        }

        public FrmManager()
        {
            InitializeComponent();
            this.ActiveControl = TxtSearch;
            ColorReload();

            EditItem_Vrb.parent = this;
            ViewItem_Vrb.parent = this;
            selectedId = -1;

            #region Search Menu
            sMenu = new ContextMenuStrip();
            sMenu.SuspendLayout();
            sMenu.ShowImageMargin = false;
            sMenu.BackColor = Color.Black;
            sMenu.ForeColor = Color.White;
            sMenu.Text = "search by";
            ToolStripMenuItem sByName = new ToolStripMenuItem();
            sByName.Text = "Name";
            sByName.Font = new Font(sByName.Font, FontStyle.Bold);
            sByName.Click += SByName_Click;
            ToolStripMenuItem sByUsername = new ToolStripMenuItem();
            sByUsername.Text = "Username";
            sByUsername.Click += SByUsername_Click;
            ToolStripMenuItem sByPassword = new ToolStripMenuItem();
            sByPassword.Text = "Password";
            sByPassword.Click += SByPassword_Click;
            ToolStripMenuItem sByUrl = new ToolStripMenuItem();
            sByUrl.Text = "Url";
            sByUrl.Click += SByUrl_Click;
            sMenu.Items.AddRange(new ToolStripItem[]
            {
                sByName, sByUsername, sByPassword, sByUrl
            });
            sMenu.ResumeLayout(false);
            #endregion
        }

        private void SByUrl_Click(object sender, EventArgs e)
        {
            sBy = "Url";
            TxtSearch_TextChanged(null, null);
            SByChanged();
        }
        private void SByPassword_Click(object sender, EventArgs e)
        {
            sBy = "Password";
            TxtSearch_TextChanged(null, null);
            SByChanged();
        }
        private void SByUsername_Click(object sender, EventArgs e)
        {
            sBy = "Username";
            TxtSearch_TextChanged(null, null);
            SByChanged();
        }
        private void SByName_Click(object sender, EventArgs e)
        {
            sBy = "Name";
            TxtSearch_TextChanged(null, null);
            SByChanged();
        }
        private void SByChanged()
        {
            for (int i = 0; i < sMenu.Items.Count; i++)
            {
                if (sMenu.Items[i].Text == sBy)
                    sMenu.Items[i].Font = new Font(sMenu.Items[i].Font, FontStyle.Bold);
                else
                    sMenu.Items[i].Font = new Font(sMenu.Items[i].Font, FontStyle.Regular);
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            sMenu.Show(Cursor.Position);
        }

        public void ColorReload()
        {
            EditItem_Vrb.ColorReload();
            ViewItem_Vrb.ColorReload();
            TxtSearch.BackColor = Properties.Settings.Default.AccentColor;
            BtnAddItem.BackColor = Properties.Settings.Default.AccentColor;
            BtnEditItem.BackColor = Properties.Settings.Default.AccentColor;

            for(int i = 0; i < PnlList.Controls.Count; i++)
                PnlList.Controls[i].BackColor = Properties.Settings.Default.AccentColor;
        }

        public int selectedId { get; set; }
        public int maxId { get; set; }

        public void newConnection(SQLiteConnection c)
        {
            con = c;
            con.CreateTable<dumbManager>();
        }
        public void loadMax()
        {
            PnlList.Controls.Clear();
            var result = con.Table<dumbManager>().ToList();
            var sortedResult = result.OrderBy(x => x.Name).ToList();
            foreach (var item in sortedResult)
            {
                maxId = item.Id;
                PnlList.Controls.Add(new ListItem(item.Name, item.Username, item.Url, item.Id, this));
            }
            if (PnlList.Controls.Count == 0)
                BtnAddItem_Click(null, null);
        }
        public void TxtSearch_TextChanged(object sender, EventArgs e)//List stuff
        {
            if (selectedId == -1)
            {
                BtnAddItem_Click(null, null);
            }
            if (TxtSearch.Text == "")
            {
                //!!! sort output
                var result = con.Table<dumbManager>().ToList();
                foreach (var item in result)
                {
                    PnlList.Controls.Find(item.Id.ToString(), false).First().Show();
                } 
            }
            else
            {
                for (int i = 0; i < PnlList.Controls.Count; i++)
                    PnlList.Controls[i].Hide();

                List<dumbManager> result = null;
                switch (sBy)
                {
                    case "Name":
                        result = con.Table<dumbManager>().Where(x => x.Name.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
                        break;
                    case "Username":
                        result = con.Table<dumbManager>().Where(x => x.Username.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
                        break;
                    case "Password":
                        result = con.Table<dumbManager>().Where(x => x.Password.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
                        break;
                    case "Url":
                        result = con.Table<dumbManager>().Where(x => x.Url.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
                        break;
                }
                //!!! sort result
                foreach (var item in result)
                {
                    PnlList.Controls.Find(item.Id.ToString(), false).First().Show();
                }
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            this.PnlViewEditLoader.Controls.Clear();
            EditItem_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlViewEditLoader.Controls.Add(EditItem_Vrb);
            EditItem_Vrb.Clear("", "", "", "", "", "");
            EditItem_Vrb.Show();
        }
        
        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            this.PnlViewEditLoader.Controls.Clear();
            if (selectedId == -1)
            {
                ViewItem_Vrb.Clear("", "", "", "","" , "");
                EditItem_Vrb.Clear("", "", "","" , "", "");
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
                        EditItem_Vrb.Clear(item.Name, item.Username, item.Password, item.Url, item.TwoFA, item.Note);
                    }
                }
                EditItem_Vrb.Show();
            }           
        }
        public void BtnLogout_Click(object sender, EventArgs e)
        {
            selectedId = -1;
            Clear();
            con.Close();
            parent.Logout();
        }

        public string getDropStuff()
        {
            string ret = string.Empty;
            var result = con.Table<dumbManager>().Where(x => x.Name.ToLower().Equals("Dropbox(Sync)".ToLower())).ToList();
            foreach (var item in result)
            {
                ret = item.Note;
            }
            return ret;
        }
        public void Add(string name, string username, string password, string url, string twoFA, string note)
        {
            
            var n = new dumbManager
            {
                Name = name,
                Username = username,
                Password = password,
                Url = url,
                TwoFA = twoFA,
                Note = note
            };
            con.Insert(n);
            if (name != "Dropbox(Sync)")
            {
                parent.AddToFile($"INSERT,,,{name},,,{username},,,{password},,,{url},,,{twoFA},,,{note}");
            }
            int nId = 0;
            var result = con.Table<dumbManager>().ToList();
            foreach (var item in result)
            {
                nId = item.Id;
            }
            PnlList.Controls.Add(new ListItem(name, username, url, nId, this));
            n.Name = "";
            n.Username = "";
            n.Password = "";
            n.Url = "";
            n.TwoFA = "";
            n.Note = "";
            Clear();
            TxtSearch_TextChanged(null, null);
        }
        public void Change(int id, string name, string username, string password, string url, string twoFA, string note)
        {
            var n = new dumbManager
            {
                Id = id,
                Name = name,
                Username = username,
                Password = password,
                Url = url,
                TwoFA = twoFA,
                Note = note             
            };
            con.Update(n);
            parent.AddToFile($"UPDATE,,,{id},,,{name},,,{username},,,{password},,,{url},,,{twoFA},,,{note}");
            ((ListItem)PnlList.Controls.Find(id.ToString(), false).First()).Init(name, username, url);
            n.Id = -1;
            n.Name = "";
            n.Username = "";
            n.Password = "";
            n.Url = "";
            n.TwoFA = "";
            n.Note = "";
            Clear();
            TxtSearch_TextChanged(null, null);
        }
        public void Del(int id, string name, string username, string url)
        {
            var n = new dumbManager();
            n.Id = id;
            con.Delete(n);
            parent.AddToFile($"DELETE,,,{id},,,{name},,,{username},,,{url}");
            n.Id = -1;
            selectedId--;
            Clear();
            PnlList.Controls.Remove(PnlList.Controls.Find(id.ToString(), false).First());
            TxtSearch_TextChanged(null, null);
        }
        public void Clear()
        {
            this.PnlViewEditLoader.Controls.Clear();
            if (selectedId == -1)
            {
                ViewItem_Vrb.Clear("", "", "", "", "", "");
                EditItem_Vrb.Clear("", "", "", "", "", "");
            }
            else
            {
                ViewItem_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlViewEditLoader.Controls.Add(ViewItem_Vrb);
                var result = con.Table<dumbManager>().ToList();
                foreach (var item in result)
                {
                    if (item.Id == selectedId)
                    {
                        ViewItem_Vrb.Clear(item.Name, item.Username, item.Password, item.Url, item.TwoFA, item.Note);
                    }
                }
                ViewItem_Vrb.Show();
            }
        }
    }
}
