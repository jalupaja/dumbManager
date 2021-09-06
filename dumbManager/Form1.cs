using SQLite;
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
        public bool onlyTray = false;

        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated) CreateHandle();
            base.SetVisibleCore(!onlyTray);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                if (loggedin)
                {
                    FrmManager_Vrb.BtnLogout_Click(null, null);
                }
                return;
            }
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false; //use only if you dont need Hotkeys - user on Stackoverflow
            onlyTray = true;
            base.OnFormClosing(e);
            MenuItemShow.Text = "Show";
            if (Properties.Settings.Default.CloseToTray == false)
            {
                TrayExit(null, null);
            }
        }

        FrmPwdGen FrmPwdGen_Vrb = new FrmPwdGen() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        LoginPage FrmLoginPage_Vrb = new LoginPage() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        FrmSettings FrmSettings_Vrb = new FrmSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        FrmManager FrmManager_Vrb = new FrmManager() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        NotifyIcon TrayIcon = new NotifyIcon();
        ContextMenuStrip TrayIconContextMenu = new ContextMenuStrip();
        ToolStripMenuItem MenuItemExit = new ToolStripMenuItem();
        ToolStripMenuItem MenuItemLock = new ToolStripMenuItem();
        ToolStripMenuItem MenuItemShow = new ToolStripMenuItem();

        public bool loggedin = false;

        public Form1()
        {
            //Tray Icon Stuff: https://www.codeproject.com/tips/627796/doing-a-notifyicon-program-the-right-way
            TrayIcon.Text = "dumbManager";
            TrayIcon.Icon = Properties.Resources.dumbManager;
            TrayIcon.MouseDown += TrayIcon_Click;

            TrayIconContextMenu.SuspendLayout();
            TrayIconContextMenu.ShowImageMargin = false;

            TrayIconContextMenu.Name = "dumbManager";
            TrayIconContextMenu.Size = new Size(153, 70);
            TrayIconContextMenu.BackColor = Color.Black;
            TrayIconContextMenu.ForeColor = Color.White;

            MenuItemExit.Name = "Exit";
            MenuItemExit.Size = new Size(153, 22);
            MenuItemExit.Text = "Exit";
            MenuItemExit.ForeColor = Color.White;
            MenuItemExit.Click += new EventHandler(TrayExit);

            MenuItemLock.Name = "Lock";
            MenuItemLock.Size = new Size(153, 22);
            MenuItemLock.Text = "Logout";
            MenuItemLock.ForeColor = Color.White;
            MenuItemLock.Enabled = false;
            MenuItemLock.Click += new EventHandler(TrayLogout);

            MenuItemShow.Name = "Show";
            MenuItemShow.Size = new Size(153, 22);
            if (this.ShowInTaskbar)
            {
                MenuItemShow.Text = "Show";
            }
            else
            {
                MenuItemShow.Text = "Hide";
            }
            MenuItemShow.ForeColor = Color.White;
            MenuItemShow.Click += new EventHandler(TrayShow);


            TrayIconContextMenu.Items.AddRange(new ToolStripItem[]
            {
                MenuItemShow, MenuItemLock, MenuItemExit, 
            });

            TrayIconContextMenu.ResumeLayout(false);

            TrayIcon.ContextMenuStrip = TrayIconContextMenu;
            TrayIcon.Visible = true;

            InitializeComponent();
            BtnManager_Click(null, null);
            FrmLoginPage_Vrb.parent = this;
            FrmManager_Vrb.parent = this;
            FrmSettings_Vrb.parent = this;

            if (Properties.Settings.Default.path == "exepath")
            {
                Properties.Settings.Default.path = Path.Combine(Application.StartupPath, "dumbManager");
            }
            else if (Properties.Settings.Default.path == "appdataLocal")
            {
                Properties.Settings.Default.path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dumbManager");
            }
            Properties.Settings.Default.Save();
            LblMain.ForeColor = Properties.Settings.Default.AccentColor;
            BtnManager.BackColor = Properties.Settings.Default.AccentColor;
            BtnPwdGen.BackColor = Properties.Settings.Default.AccentColor;
            BtnSync.BackColor = Properties.Settings.Default.AccentColor;
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

        public void ColorReload()
        {
            LblMain.ForeColor = Properties.Settings.Default.AccentColor;
            BtnManager.BackColor = Properties.Settings.Default.AccentColor;
            BtnPwdGen.BackColor = Properties.Settings.Default.AccentColor;
            BtnSync.BackColor = Properties.Settings.Default.AccentColor;
            BtnSettings.BackColor = Properties.Settings.Default.AccentColor;

            FrmPwdGen_Vrb.ColorReload();
            FrmLoginPage_Vrb.ColorReload();
            FrmManager_Vrb.ColorReload();
            FrmSettings_Vrb.ColorReload();
        }

        private void TrayIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TrayShow(null, null);
            }
        }
        private void TrayShow(object sender, EventArgs e)
        {
            if (onlyTray)
            {
                onlyTray = false;
                base.SetVisibleCore(true);
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Activate();
                MenuItemShow.Text = "Hide";
            }
            else
            {
                OnFormClosing(new FormClosingEventArgs(CloseReason.None, true));
            }  
        }
        public void TrayLogout(object sender, EventArgs e)
        {
            if (loggedin)
            {
                FrmManager_Vrb.BtnLogout_Click(null, null);
            }
        }
        public void TrayExit(object sender, EventArgs e)
        {
            TrayLogout(null, null);
            TrayIconContextMenu.Visible = false;
            TrayIcon.Visible = false;
            Application.ExitThread();
            Application.Exit();
            
        }

        public void Logout()
        {
            MenuItemLock.Enabled = false;
            FrmLoginPage_Vrb.Logout();
            loggedin = false;
            BtnManager_Click(null, null);
        }
        public void newManager(SQLite.SQLiteConnection c)
        {
            MenuItemLock.Enabled = true;
            FrmManager_Vrb.newConnection(c);
            FrmManager_Vrb.loadMax();
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

        public void BtnPwdGen_Click(object sender, EventArgs e)
        {
            LblMain.Text = "Password Generator";
            this.PnlFormLoader.Controls.Clear();
            FrmPwdGen_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmPwdGen_Vrb);
            FrmPwdGen_Vrb.Show();
        }

        public void BtnSettings_Click(object sender, EventArgs e)
        {
            LblMain.Text = "Settings";
            this.PnlFormLoader.Controls.Clear();
            FrmSettings_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmSettings_Vrb);
            FrmSettings_Vrb.Show();
        }
        public void Lock()
        {
            if (this.Enabled)
            {
                this.Enabled = false;
            }
            else
            {
                this.Enabled = true;
                this.Activate();
            }
        }

        public string pwdCreate(string length, bool lower, bool upper, bool numbers, bool spec)
        {
            return FrmPwdGen_Vrb.pwdCreate(length, lower, upper, numbers, spec);
        }
        public string HashIt(string input)
        {
            return FrmLoginPage_Vrb.HashIt(input);
        }

        public void AddToFile(string line)
        {
            FrmLoginPage_Vrb.AddToFile(line);
        }
        private void BtnSync_Click(object sender, EventArgs e)
        {
            BtnSync.Text = "Syncing ...";
            FrmLoginPage_Vrb.Sync();
        }

        public string getSyncResponse()
        {
            return TxtSyncResponse.Text;
        }
        public void setSyncResponse(string response)
        {
            if (response == string.Empty)
                TxtSyncResponse.Clear();
            else
            {
                if (response.Contains("ERROR"))
                    TxtSyncResponse.ForeColor = Color.Red;
                else if (response.Contains("SUCCESS"))
                {
                    TxtSyncResponse.ForeColor = Color.Green;
                }
                else
                    TxtSyncResponse.ForeColor = Color.White;
                TxtSyncResponse.AppendText(Environment.NewLine + Environment.NewLine + Environment.NewLine + response + Environment.NewLine);
            }
        }
        public void addSyncResponse(string response)
        {
            if (response.Contains("ERROR"))
                TxtSyncResponse.ForeColor = Color.Red;
            else if (response.Contains("SUCCESS"))
                TxtSyncResponse.ForeColor = Color.Green;
            else
                TxtSyncResponse.ForeColor = Color.White;
            TxtSyncResponse.AppendText(response + Environment.NewLine);
        }
        public void TxtSyncResponse_DoubleClick(object sender, EventArgs e)
        {
            new FrmLittleBox("Sync response conent:", TxtSyncResponse.Text).Show();
        }
        public void finishedSyncing()
        {
            BtnSync.Text = "Sync";
        }
        public void SafeSyncFile(string path)
        {
            File.Delete(path);
            for (int i = 0; i < TxtSyncResponse.Lines.Length; i++)
            {
                File.AppendAllText(path, TxtSyncResponse.Lines[i] + Environment.NewLine);
            }
        }

        public string GetDropStuff()
        {
            return FrmManager_Vrb.getDropStuff();
        }
        public void CreateDropStuff(string dropToken)
        {
            FrmManager_Vrb.Add("Dropbox(Sync)", "", "", "https://www.dropbox.com", "", $"|{dropToken}|");
        }
    }
}
