using System;
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

        private bool isOnTop = false;

        public Form1 parent { get; set; }

        FrmAbout FrmAbout_Vrb = new FrmAbout() {TopLevel = true, TopMost = true};

        public FrmSettings()
        {
            InitializeComponent();
            ColorReload();
            FrmAbout_Vrb.parent = this;
        }

        public void ColorReload()
        {
            BtnColor.BackColor = Properties.Settings.Default.AccentColor;
            BtnAbout.BackColor = Properties.Settings.Default.AccentColor;
            BtnAlways.BackColor = Properties.Settings.Default.AccentColor;

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
            //!!!
            FrmAbout_Vrb.Show();
            parent.Lock();
        }

        public void CloseAbout()
        {
            FrmAbout_Vrb.Hide();
            parent.Lock();
        }

        private void BtnAlways_Click(object sender, EventArgs e)
        {
            if (isOnTop)
            {
                try
                {

                    isOnTop = false;
                    BtnAlways.Text = "Always On Top: off";
                }
                catch (Exception)
                {
                    isOnTop = true;
                    BtnAlways.Text = "Always On Top: on";
                }
            }
            else
            {
                try
                {

                    isOnTop = true;
                    BtnAlways.Text = "Always On Top: on";
                }
                catch (Exception)
                {
                    isOnTop = false;
                    BtnAlways.Text = "Always On Top: off";
                }
            }
            
        }
    }
}
