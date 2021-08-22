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
        public Form1 parent { get; set; }

        public FrmSettings()
        {
            InitializeComponent();
            ColorReload();
        }

        public void ColorReload()
        {
            BtnColor.BackColor = Properties.Settings.Default.AccentColor;
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            //Color Picker
            ColorDialog cd = new ColorDialog();
            cd.AnyColor = true;
            cd.Color = Properties.Settings.Default.AccentColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.AccentColor = cd.Color;//!!!
                Properties.Settings.Default.Save();
            }
            parent.ColorReload();
        }
    }
}
