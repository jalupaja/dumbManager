﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

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

            if (Properties.Settings.Default.CloseToTray)
            {
                BtnCloseToTray.Text = "Close To Tray: on";
            }
            else
            {
                BtnCloseToTray.Text = "Close To Tray: off";
            }

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
        }

        public void ColorReload()
        {
            BtnColor.BackColor = Properties.Settings.Default.AccentColor;
            BtnAbout.BackColor = Properties.Settings.Default.AccentColor;
            BtnAlways.BackColor = Properties.Settings.Default.AccentColor;
            BtnLogoutAfter.BackColor = Properties.Settings.Default.AccentColor;
            BtnCloseToTray.BackColor = Properties.Settings.Default.AccentColor;

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
    }
}