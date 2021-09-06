using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Design;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.IO;
using IWshRuntimeLibrary;

namespace dumbManager
{
    public partial class FrmSettings : Form
    {

        public int minToLogout = -1;

        public Form1 parent { get; set; }

        FrmAbout FrmAbout_Vrb = new FrmAbout() {TopLevel = true, TopMost = true};

        public FrmSettings()
        {
            InitializeComponent();
            ColorReload();
            FrmAbout_Vrb.parent = this;

            #region Close to tray
            if (Properties.Settings.Default.CloseToTray)
            {
                BtnCloseToTray.Text = "Close To Tray: on";
            }
            else
            {
                BtnCloseToTray.Text = "Close To Tray: off";
            }
            #endregion Close to tray

            #region Logout after inactivity
            if (Properties.Settings.Default.LogoutAfter == 0)
            {
                BtnLogoutAfter.Text = "Logout automatically after: never";
            }
            else if (Properties.Settings.Default.LogoutAfter == 60000)
            {
                BtnLogoutAfter.Text = "Logout automatically after: 1min";
            }
            else if (Properties.Settings.Default.LogoutAfter == 300000)
            {
                BtnLogoutAfter.Text = "Logout automatically after: 5min";
            }
            else if (Properties.Settings.Default.LogoutAfter == 600000)
            {
                BtnLogoutAfter.Text = "Logout automatically after: 10min";
            }
            else if (Properties.Settings.Default.LogoutAfter == 900000)
            {
                BtnLogoutAfter.Text = "Logout automatically after: 15min";
            }
            else if (Properties.Settings.Default.LogoutAfter == 1800000)
            {
                BtnLogoutAfter.Text = "Logout automatically after: 30min";
            }
            else if (Properties.Settings.Default.LogoutAfter == 6000000)
            {
                BtnLogoutAfter.Text = "Logout automatically after: 1h";
            }
            #endregion Logout after inactivity

            #region Start Menu
            //https://stackoverflow.com/questions/25024785/how-to-create-start-menu-shortcut
            string appStartMenuPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu), "Programs", "dumbManager");
            string shortcutLocation = Path.Combine(appStartMenuPath, "dumbManager" + ".lnk");

            if (Properties.Settings.Default.StartMenu)
            {
                if (System.IO.File.Exists(shortcutLocation) == false)
                {
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                    try
                    {
                        if (!Directory.Exists(appStartMenuPath))
                            Directory.CreateDirectory(appStartMenuPath);
                        shortcut.Description = "A dumb Password Manager";
                        shortcut.IconLocation = System.Windows.Forms.Application.ExecutablePath;
                        shortcut.TargetPath = System.Windows.Forms.Application.ExecutablePath;
                        shortcut.Save();
                        BtnStartMenu.Text = "Delete Start Menu";
                    }
                    catch (Exception)
                    {
                        Properties.Settings.Default.StartMenu = false;
                        BtnStartMenu.Text = "Create Start Menu";
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                BtnStartMenu.Text = "Create Start Menu";
            }
            #endregion Start Menu

            #region Startup
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Properties.Settings.Default.Startup == "off")
            {
                try
                {
                    rk.DeleteValue("dumbManager", false);
                }
                catch (Exception)
                {
                    Properties.Settings.Default.Startup = "off";
                    MessageBox.Show("Insufficient Permissions!"); 
                }
            }
            else if (Properties.Settings.Default.Startup == "tray")
            {
                try
                {
                    rk.SetValue("dumbManager", Application.ExecutablePath + "silent");
                }
                catch (Exception)
                {
                    Properties.Settings.Default.Startup = "off";
                    MessageBox.Show("Insufficient Permissions!");
                }
            }
            else if (Properties.Settings.Default.Startup == "on")
            {
                try
                {
                    rk.SetValue("dumbManager", Application.ExecutablePath);
                }
                catch (Exception)
                {
                    Properties.Settings.Default.Startup = "off";
                    MessageBox.Show("Insufficient Permissions!");
                }
            }
            Properties.Settings.Default.Save();
            BtnStartup.Text = "Startup: " + Properties.Settings.Default.Startup;
            #endregion Startup
        }

        public void ColorReload()
        {
            BtnColor.BackColor = Properties.Settings.Default.AccentColor;
            BtnAbout.BackColor = Properties.Settings.Default.AccentColor;
            BtnAlways.BackColor = Properties.Settings.Default.AccentColor;
            BtnCloseToTray.BackColor = Properties.Settings.Default.AccentColor;
            BtnStartMenu.BackColor = Properties.Settings.Default.AccentColor;
            BtnStartup.BackColor = Properties.Settings.Default.AccentColor;

            BtnLogoutAfter.BackColor = Properties.Settings.Default.AccentColor;
            BtnImport.BackColor = Properties.Settings.Default.AccentColor;
            BtnExport.BackColor = Properties.Settings.Default.AccentColor;

            FrmAbout_Vrb.ColorReload();
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            //Color Picker
            ColorDialog cd = new ColorDialog();
            cd.AnyColor = true;
            cd.Color = Properties.Settings.Default.AccentColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.AccentColor = cd.Color;
                Properties.Settings.Default.Save();
            }
            parent.ColorReload();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout_Vrb.ShowDialog();
            parent.Lock();
        }

        public void CloseAbout()
        {
            FrmAbout_Vrb.Hide();
            parent.Lock();
        }

        private void BtnAlways_Click(object sender, EventArgs e)
        {
            if (parent.TopMost)
            {
                try
                {
                    parent.TopMost = false;
                    BtnAlways.Text = "Always On Top: off";
                }
                catch (Exception)
                {
                    parent.TopMost = true;
                    BtnAlways.Text = "Always On Top: on";
                }
            }
            else
            {
                try
                {
                    parent.TopMost = true;
                    BtnAlways.Text = "Always On Top: on";
                }
                catch (Exception)
                {
                    parent.TopMost = false;
                    BtnAlways.Text = "Always On Top: off";
                }
            }
            
        }

        private void BtnLogoutAfter_Click(object sender, EventArgs e)
        {
            if (BtnLogoutAfter.Text == "Logout automatically after: never")
            {
                Properties.Settings.Default.LogoutAfter = 60000;
                BtnLogoutAfter.Text = "Logout automatically after: 1min";
            }
            else if (BtnLogoutAfter.Text == "Logout automatically after: 1min")
            {
                Properties.Settings.Default.LogoutAfter = 300000;
                BtnLogoutAfter.Text = "Logout automatically after: 5min";
            }
            else if (BtnLogoutAfter.Text == "Logout automatically after: 5min")
            {
                Properties.Settings.Default.LogoutAfter = 600000;
                BtnLogoutAfter.Text = "Logout automatically after: 10min";
            }
            else if (BtnLogoutAfter.Text == "Logout automatically after: 10min")
            {
                Properties.Settings.Default.LogoutAfter = 900000;
                BtnLogoutAfter.Text = "Logout automatically after: 15min";
            }
            else if (BtnLogoutAfter.Text == "Logout automatically after: 15min")
            {
                Properties.Settings.Default.LogoutAfter = 1800000;
                BtnLogoutAfter.Text = "Logout automatically after: 30min";
            }
            else if (BtnLogoutAfter.Text == "Logout automatically after: 30min")
            {
                Properties.Settings.Default.LogoutAfter = 6000000;
                BtnLogoutAfter.Text = "Logout automatically after: 1h";
            }
            else
            {
                Properties.Settings.Default.LogoutAfter = 0;
                BtnLogoutAfter.Text = "Logout automatically after: never";
            }
            Properties.Settings.Default.Save();
        }

        private void BtnCloseToTray_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CloseToTray)
            {
                BtnCloseToTray.Text = "Close To Tray: off";
                Properties.Settings.Default.CloseToTray = false;
            }
            else
            {
                BtnCloseToTray.Text = "Close To Tray: on";
                Properties.Settings.Default.CloseToTray = true;
            }
            Properties.Settings.Default.Save();
        }

        private void BtnStartMenu_Click(object sender, EventArgs e)
        {
            string appStartMenuPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu), "Programs", "dumbManager");
            string shortcutLocation = Path.Combine(appStartMenuPath, "dumbManager" + ".lnk");

            if (Properties.Settings.Default.StartMenu)
            {
                try
                {
                    System.IO.File.Delete(shortcutLocation);
                }
                catch (Exception)
                { }
                BtnStartMenu.Text = "Create Start Menu";
                Properties.Settings.Default.StartMenu = false;
            }
            else
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                try
                {
                    if (!Directory.Exists(appStartMenuPath))
                        Directory.CreateDirectory(appStartMenuPath);
                    shortcut.Description = "A dumb Password Manager";
                    shortcut.IconLocation = System.Windows.Forms.Application.ExecutablePath;
                    shortcut.TargetPath = System.Windows.Forms.Application.ExecutablePath;
                    shortcut.Save();
                    BtnStartMenu.Text = "Delete Start Menu";
                    Properties.Settings.Default.StartMenu = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Insufficient Permissions!", "Insufficient Permissions!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnStartMenu.Text = "Create Start Menu";
                    Properties.Settings.Default.StartMenu = false;
                }
            }
            Properties.Settings.Default.Save();
        }

        private void BtnStartup_Click(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Properties.Settings.Default.Startup == "off")
            {
                try
                {
                    Properties.Settings.Default.Startup = "tray";
                    rk.SetValue("dumbManager", Application.ExecutablePath + " silent");
                }
                catch (Exception)
                {
                    Properties.Settings.Default.Startup = "off";
                    MessageBox.Show("Insufficient Permissions!");
                }
            }
            else if (Properties.Settings.Default.Startup == "tray")
            {
                try
                {
                    Properties.Settings.Default.Startup = "on";
                    rk.SetValue("dumbManager", Application.ExecutablePath);
                }
                catch (Exception)
                {
                    Properties.Settings.Default.Startup = "off";
                    MessageBox.Show("Insufficient Permissions!");
                }
            }
            else
            {
                Properties.Settings.Default.Startup = "off";
                try
                {
                    rk.DeleteValue("dumbManager", false);
                }
                catch (Exception)
                {
                    MessageBox.Show("Insufficient Permissions!");
                }
            }
            Properties.Settings.Default.Save();
            BtnStartup.Text = "Startup: " + Properties.Settings.Default.Startup;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Title = "Select a file to import";
            browseFile.Filter = "(*.db)|*.db";
            browseFile.Multiselect = true;
            if (browseFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string thisFile in browseFile.FileNames)
                    System.IO.File.Copy(thisFile, Path.Combine(Properties.Settings.Default.path, Path.GetFileName(thisFile)));
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            new FrmExport(parent).ShowDialog();
        }
    }
}