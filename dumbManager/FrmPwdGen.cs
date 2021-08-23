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
    public partial class FrmPwdGen : Form
    {

        public FrmPwdGen()
        {
            InitializeComponent();
            this.ActiveControl = BtnPwdCreate;
            ColorReload();

            try
            {
                Convert.ToInt32(TxtPwdLength.Text);
            }
            catch (Exception)
            {
                TxtPwdLength.Text = "20";
            }
            TxtPwdOut.Text = pwdCreate(TxtPwdLength.Text, checkLowercase.Checked, checkUppercase.Checked, checkNumbers.Checked, checkSpecialChar.Checked);
        }

        public void ColorReload()
        {
            BtnPwdCopy.BackColor = Properties.Settings.Default.AccentColor;
            TxtPwdOut.BackColor = Properties.Settings.Default.AccentColor;
            TxtPwdLength.BackColor = Properties.Settings.Default.AccentColor;
            BtnPwdCreate.BackColor = Properties.Settings.Default.AccentColor;
        }

        private void BtnPwdCopy_Click(object sender, EventArgs e)
        {
            if (TxtPwdOut.Text != "")
            {
                Clipboard.SetText(TxtPwdOut.Text);
            }
        }

        private void BtnPwdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(TxtPwdLength.Text);
            }
            catch (Exception) 
            {
                TxtPwdLength.Text = "20";
            }
            TxtPwdOut.Text = pwdCreate(TxtPwdLength.Text, checkLowercase.Checked, checkUppercase.Checked, checkNumbers.Checked, checkSpecialChar.Checked);
        }

        public string pwdCreate(string length, bool lower, bool upper, bool numbers, bool spec)
        {
            int pwdLength = 20;
            try
            {
                pwdLength = Convert.ToInt32(length);
            }
            catch(Exception){}

            if (pwdLength < 0)
            {
                pwdLength = 20;
            }

            string valid = "";
            if (lower)
            {
                valid += "abcdefghijklmnopqrstuvwxyz";
            }
            if (upper)
            {
                valid += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            if (numbers)
            {
                valid += "1234567890";
            }
            if (spec)
            {
                valid += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            }

            if (valid == "")
            {
                return "";
            }

            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < pwdLength--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private void TxtPwdLength_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(TxtPwdLength.Text);
            }
            catch (Exception)
            {
                TxtPwdLength.Text = "20";
            }
            TxtPwdOut.Text = pwdCreate(TxtPwdLength.Text, checkLowercase.Checked, checkUppercase.Checked, checkNumbers.Checked, checkSpecialChar.Checked);
        }

        private void checkLowercase_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(TxtPwdLength.Text);
            }
            catch (Exception)
            {
                TxtPwdLength.Text = "20";
            }
            TxtPwdOut.Text = pwdCreate(TxtPwdLength.Text, checkLowercase.Checked, checkUppercase.Checked, checkNumbers.Checked, checkSpecialChar.Checked);
        }

        private void checkUppercase_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(TxtPwdLength.Text);
            }
            catch (Exception)
            {
                TxtPwdLength.Text = "20";
            }
            TxtPwdOut.Text = pwdCreate(TxtPwdLength.Text, checkLowercase.Checked, checkUppercase.Checked, checkNumbers.Checked, checkSpecialChar.Checked);
        }

        private void checkNumbers_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(TxtPwdLength.Text);
            }
            catch (Exception)
            {
                TxtPwdLength.Text = "20";
            }
            TxtPwdOut.Text = pwdCreate(TxtPwdLength.Text, checkLowercase.Checked, checkUppercase.Checked, checkNumbers.Checked, checkSpecialChar.Checked);
        }

        private void checkSpecialChar_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(TxtPwdLength.Text);
            }
            catch (Exception)
            {
                TxtPwdLength.Text = "20";
            }
            TxtPwdOut.Text = pwdCreate(TxtPwdLength.Text, checkLowercase.Checked, checkUppercase.Checked, checkNumbers.Checked, checkSpecialChar.Checked);
        }
    }
}
