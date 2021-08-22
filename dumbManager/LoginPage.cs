using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SQLite;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dumbManager
{
    public partial class LoginPage : Form
    {

        public Form1 parent = null;

        SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;
        protected SQLiteConnection con = null;

        public LoginPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.path == "exepath")
            {
                TxtFilePath.Text = Path.Combine(Application.StartupPath, "dumbManager");
            }
            else if (Properties.Settings.Default.path == "appdataLocal")
            {
                TxtFilePath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dumbManager");
            }
            else
            {
                TxtFilePath.Text = Properties.Settings.Default.path;
            }
            TxtFilePath.ForeColor = Color.Gray;
            TxtResponse.Text = "Please create a secure password \nThe password can not be recovered!";
            TxtResponse.ForeColor = Color.White;
            BtnLogin.BackColor = Properties.Settings.Default.AccentColor;
            TxtFileIn.BackColor = Properties.Settings.Default.AccentColor;
            TxtPwd.BackColor = Properties.Settings.Default.AccentColor;
        }

        public void Logout()
        {
            TxtFileIn_TextChanged(null, null);
            TxtPwd.Text = "";
        }

        private string HashIt(String input)
        {
            if (input == null)
                return ".";
            SHA512 sha = new SHA512Managed();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = sha.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            
            if (!Directory.Exists(Properties.Settings.Default.path))
            {
                Directory.CreateDirectory(Properties.Settings.Default.path);
            }
            string filepath = Path.Combine(Properties.Settings.Default.path, HashIt(TxtFileIn.Text) + ".db");

            if (File.Exists(filepath))
            {
                //Login
                try
                {
                    parent.loggedin = true;
                    _ = new SQLiteConnection(new SQLiteConnectionString(filepath, Flags, true, key: new Rfc2898DeriveBytes(TxtPwd.Text, Encoding.ASCII.GetBytes(HashIt(TxtFileIn.Text)), 100000, HashAlgorithmName.SHA512).ToString()));

                    TxtResponse.Text = "Login successful!";
                    TxtResponse.ForeColor = Color.White;
                }
                catch (Exception)
                {
                    parent.loggedin = false;

                    BtnLogin.Text = $"login to {TxtFileIn.Text}";
                    TxtPwd.Text = "";

                    TxtResponse.Text = "Incorrect password.";
                    TxtResponse.ForeColor = Color.Red;
                }
                if (parent.loggedin)
                {
                    parent.oldManager(new SQLiteConnection(new SQLiteConnectionString(filepath, Flags, true, key: new Rfc2898DeriveBytes(TxtPwd.Text, Encoding.ASCII.GetBytes(HashIt(TxtFileIn.Text)), 100000, HashAlgorithmName.SHA512).ToString())));
                    parent.BtnManager_Click(null, null);
                }
            }
            else
            {
                //create new encrypted database
                parent.loggedin = true;
                parent.newManager(new SQLiteConnection(new SQLiteConnectionString(filepath, Flags, true, key: new Rfc2898DeriveBytes(TxtPwd.Text, Encoding.ASCII.GetBytes(HashIt(TxtFileIn.Text)), 100000, HashAlgorithmName.SHA512).ToString())));
                parent.BtnManager_Click(null, null);

                TxtPwd.Text = "";
                TxtResponse.Text = "Login successful!";
                TxtResponse.ForeColor = Color.White;
            }
        }
        private void TxtFileIn_TextChanged(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Properties.Settings.Default.path, HashIt(TxtFileIn.Text) + ".db");

            if (File.Exists(filepath))
            {
                BtnLogin.Text = $"login to {TxtFileIn.Text}";
                TxtResponse.Text = "Please input the password to your account!";
                TxtResponse.ForeColor = Color.White;
            }
            else
            {
                BtnLogin.Text = "create new user";
                TxtResponse.Text = "Please create a secure password \nThe password can not be recovered!";
                TxtResponse.ForeColor = Color.White;
            }
        }

        private void TxtFilePath_Click(object sender, EventArgs e)
        {
            //!!! open folder dialogue
            FolderBrowserDialog browseFolder = new FolderBrowserDialog();
            browseFolder.SelectedPath = Properties.Settings.Default.path;

            if (browseFolder.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.path = browseFolder.SelectedPath.ToString();
                TxtFilePath.Text = Properties.Settings.Default.path;
            }
            else{}
            TxtFileIn_TextChanged(null, null);
        }
    }
}

