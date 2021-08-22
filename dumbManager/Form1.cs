using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dumbManager
{
    public partial class Form1 : Form
    {
        FrmPwdGen FrmPwdGen_Vrb = new FrmPwdGen() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        LoginPage FrmLoginPage_Vrb = new LoginPage() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        FrmSettings FrmSettings_Vrb = new FrmSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        FrmManager FrmManager_Vrb = new FrmManager() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        public bool loggedin = false;

        public Form1()
        {
            InitializeComponent();
            BtnManager_Click(null, null);
            FrmLoginPage_Vrb.parent = this;
            FrmManager_Vrb.parent = this;

            if (Properties.Settings.Default.path == "exepath")
            {
                Properties.Settings.Default.path = Path.Combine(Application.StartupPath, "dumbManager");
            }
            else if (Properties.Settings.Default.path == "appdataLocal")
            {
                Properties.Settings.Default.path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dumbManager");
            }

            LblMain.ForeColor = Properties.Settings.Default.AccentColor;
            BtnManager.BackColor = Properties.Settings.Default.AccentColor;
            BtnPwdGen.BackColor = Properties.Settings.Default.AccentColor;
            BtnSettings.BackColor = Properties.Settings.Default.AccentColor;

            if (loggedin)
            {
                LblMain.Text = "Password Manager";
                this.PnlFormLoader.Controls.Clear();
                FrmManager_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlFormLoader.Controls.Add(FrmManager_Vrb);
                FrmManager_Vrb.Show();
            }
            else
            {
                LblMain.Text = "Password Manager";
                this.PnlFormLoader.Controls.Clear();
                FrmLoginPage_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlFormLoader.Controls.Add(FrmLoginPage_Vrb);
                FrmLoginPage_Vrb.Show();
            }
        }

        public void Logout()
        {
            FrmLoginPage_Vrb.Logout();
            loggedin = false;
            BtnManager_Click(null, null);
        }
        public void newManager(SQLite.SQLiteConnection c)
        {
            FrmManager_Vrb.newConnection(c);
            FrmManager_Vrb.newFile();
        }

        public void oldManager(SQLite.SQLiteConnection c)
        {
            FrmManager_Vrb.newConnection(c);
        }

        public void BtnManager_Click(object sender, EventArgs e)
        {
            if (loggedin)
            {
                LblMain.Text = "Password Manager";
                this.PnlFormLoader.Controls.Clear();
                FrmManager_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlFormLoader.Controls.Add(FrmManager_Vrb);
                FrmManager_Vrb.Show();
                FrmManager_Vrb.TxtSearch_TextChanged(null,null);
            }
            else
            {
                LblMain.Text = "Password Manager";
                this.PnlFormLoader.Controls.Clear();
                FrmLoginPage_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlFormLoader.Controls.Add(FrmLoginPage_Vrb);
                FrmLoginPage_Vrb.Show();
            }
        }

        private void BtnPwdGen_Click(object sender, EventArgs e)
        {
            LblMain.Text = "Password Generator";
            this.PnlFormLoader.Controls.Clear();
            FrmPwdGen_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmPwdGen_Vrb);
            FrmPwdGen_Vrb.Show();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            LblMain.Text = "Settings";
            this.PnlFormLoader.Controls.Clear();
            FrmSettings_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmSettings_Vrb);
            FrmSettings_Vrb.Show();
        }
    }
}
