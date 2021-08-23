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

        public FrmAbout()
        {
            this.ActiveControl = BtnClose;
            InitializeComponent();
            ColorReload();
            this.
            TxtAbout.Multiline = true;
            TxtAbout.Text = "dumbManager" + Environment.NewLine + "Copyright © jalupa 2021" + Environment.NewLine + "Version: " + System.Windows.Forms.Application.ProductVersion;
        }

        public void ColorReload()
        {
            BtnClose.BackColor = Properties.Settings.Default.AccentColor;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            parent.CloseAbout();
        }

        private void BtnCheckUpdate_Click(object sender, EventArgs e)
        {
            return; //!!! change this shit
            int offlineVersion = Int16.Parse(System.Windows.Forms.Application.ProductVersion.Replace(".", "").Replace("v",""));

            var tmp = System.Windows.Forms.Application.ProductVersion.ToString().Split(".");


            int one = Int16.Parse(tmp[0]);
            int two = Int16.Parse(tmp[1]);
            int three = Int16.Parse(tmp[2]);
            for (int i = one; i <= 9; i++)
            {
                for (int j = two; j <= 9; j++)
                {
                    for (int k = three; k <= 9; k++)
                    {
                        try
                        {
                            //Creating the HttpWebRequest
                            HttpWebRequest request = WebRequest.Create("https://github.com/jalupaja/dumbManager/releases/tag/" + one + "." + two + "." + three) as HttpWebRequest;
                            //Setting the Request method HEAD, you can also use GET too.
                            request.Method = "HEAD";
                            //Getting the Web Response.
                            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                            //Returns TRUE if the Status code == 200
                            response.Close();
                            if (response.StatusCode != HttpStatusCode.OK)
                            {
                                return;
                            }
                        }
                        catch (Exception) { }
                    }
                }
            }

            int onlineVersion = Int16.Parse(one.ToString() + two.ToString() + three.ToString());//!!!

            if (offlineVersion < onlineVersion)
            {
                TxtAbout.Text = "dumbManager" + Environment.NewLine + "Copyright © jalupa 2021" + Environment.NewLine + "Version: " + System.Windows.Forms.Application.ProductVersion + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "There is a new update available!";
                try
                {
                    Process.Start("https://github.com/jalupaja/dumbManager/releases/latest/download/dumbManager.zip");
                }
                catch(Exception){}
            }
            else if (Int16.Parse(System.Windows.Forms.Application.ProductVersion.Replace(".", "")) == onlineVersion)
            {
                TxtAbout.Text = "dumbManager" + Environment.NewLine + "Copyright © jalupa 2021" + Environment.NewLine + "Version: " + System.Windows.Forms.Application.ProductVersion + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "You are up to date!";
            }
            else
            {
                TxtAbout.Text = "dumbManager" + Environment.NewLine + "Copyright © jalupa 2021" + Environment.NewLine + "Version: " + System.Windows.Forms.Application.ProductVersion + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "You have a newer Version I!";
            }

        }
    }
}
