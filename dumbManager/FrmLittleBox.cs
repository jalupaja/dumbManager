using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dumbManager
{
    public partial class FrmLittleBox : Form
    {
        public string ret;
        public FrmLittleBox(string title, string content, string respMark = "")
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.Name = title;

            TxtTitle.ForeColor = Properties.Settings.Default.AccentColor;
            TxtIn.BackColor = Properties.Settings.Default.AccentColor;
            TxtOut.BackColor = Properties.Settings.Default.AccentColor;
            BtnOk.BackColor = Properties.Settings.Default.AccentColor;
            BtnCancel.BackColor = Properties.Settings.Default.AccentColor;

            TxtTitle.Text = title;
            TxtIn.Text = content;
            if (respMark != "")
            {
                TxtOut.Visible = true;
                TxtOut.PlaceholderText = respMark;
            }

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (TxtOut.Visible)
                ret = TxtOut.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
