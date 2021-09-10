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
    public partial class FrmExport : Form
    {
        Form1 parent;
        public FrmExport(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
            ShowInTaskbar = false;
            TxtFile.BackColor = Properties.Settings.Default.AccentColor;
            BtnCANCEL.BackColor = Properties.Settings.Default.AccentColor;
            BtnOK.BackColor = Properties.Settings.Default.AccentColor;
            TxtFile_TextChanged(null, null);
        }

        private void TxtFile_TextChanged(object sender, EventArgs e)
        {
            BtnOK.Enabled = System.IO.File.Exists(Path.Combine(Properties.Settings.Default.path, parent.HashIt(TxtFile.Text)));            
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browseFolder = new FolderBrowserDialog();
            browseFolder.Description = "Your have to remember the filename in order to access it later!";
            if (browseFolder.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(Path.Combine(Properties.Settings.Default.path, parent.HashIt(TxtFile.Text)), Path.Combine(browseFolder.SelectedPath, parent.HashIt(TxtFile.Text)));
            }
            this.Close();
        }

        private void BtnCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
