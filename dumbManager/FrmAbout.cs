using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;

namespace dumbManager
{
    public partial class FrmAbout : Form
    {
        public FrmSettings parent { get; set; }

        string baseTxt = "";

        public FrmAbout()
        {
            this.ActiveControl = BtnClose;
            InitializeComponent();
            ColorReload();
            TxtAbout.Multiline = true;
            
            baseTxt = "dumbManager" + Environment.NewLine + "https://github.com/jalupaja/dumbManager/" + Environment.NewLine + "Copyright © jalupa 2021" + Environment.NewLine + "Version: " + System.Windows.Forms.Application.ProductVersion;
            TxtAbout.Text = baseTxt;
        }

        public void ColorReload()
        {
            BtnClose.BackColor = Properties.Settings.Default.AccentColor;
            BtnCheckUpdate.BackColor = Properties.Settings.Default.AccentColor;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            parent.CloseAbout();
        }

        private void BtnCheckUpdate_Click(object sender, EventArgs e)
        {
            int offlineVersion = Int16.Parse(System.Windows.Forms.Application.ProductVersion.Replace(".", "").Replace("v",""));
            int onlineVersion = Int16.Parse(new WebClient().DownloadString("https://raw.githubusercontent.com/jalupaja/dumbManager/main/dumbManager/VersionNumber.txt"));

            if (offlineVersion < onlineVersion)
            {
                TxtAbout.Text = baseTxt + Environment.NewLine + Environment.NewLine + Environment.NewLine + "There is a new update available!";
                try
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start https://github.com/jalupaja/dumbManager/releases/latest/download/dumbManager.zip") { CreateNoWindow = false });
                }
                catch(Exception){}
            }
            else if (Int16.Parse(System.Windows.Forms.Application.ProductVersion.Replace(".", "")) == onlineVersion)
            {
                TxtAbout.Text = baseTxt + Environment.NewLine + Environment.NewLine + Environment.NewLine + "You are up to date!";
            }
            else
            {
                TxtAbout.Text = baseTxt + Environment.NewLine + Environment.NewLine + Environment.NewLine + "You have a newer Version then I!";
            }
        }
    }
}
