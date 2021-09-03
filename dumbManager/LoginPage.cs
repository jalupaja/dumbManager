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
using System.Net;
using CG.Web.MegaApiClient;

namespace dumbManager
{
    public partial class LoginPage : Form
    {

        public Form1 parent = null;

        SQLite.SQLiteOpenFlags Flags = SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite;
        protected SQLiteConnection con = null;

        protected string pw = "";
        protected string fpath = "";

        public LoginPage()
        {
            InitializeComponent();
            this.ActiveControl = TxtFileIn;
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
            ColorReload();
        }

        public void ColorReload()
        {
            BtnLogin.BackColor = Properties.Settings.Default.AccentColor;
            TxtFileIn.BackColor = Properties.Settings.Default.AccentColor;
            TxtPwd.BackColor = Properties.Settings.Default.AccentColor;
        }

        public void Logout()
        {
            TxtFileIn_TextChanged(null, null);
            pw = "";
            fpath = "";
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
                    

                    TxtResponse.Text = "Incorrect password.";
                    TxtResponse.ForeColor = Color.Red;
                }
                if (parent.loggedin)
                {
                    parent.newManager(new SQLiteConnection(new SQLiteConnectionString(filepath, Flags, true, key: new Rfc2898DeriveBytes(TxtPwd.Text, Encoding.ASCII.GetBytes(HashIt(TxtFileIn.Text)), 100000, HashAlgorithmName.SHA512).ToString())));
                    parent.BtnManager_Click(null, null);
                }
            }
            else
            {
                //create new encrypted database
                parent.loggedin = true;
                parent.newManager(new SQLiteConnection(new SQLiteConnectionString(filepath, Flags, true, key: new Rfc2898DeriveBytes(TxtPwd.Text, Encoding.ASCII.GetBytes(HashIt(TxtFileIn.Text)), 100000, HashAlgorithmName.SHA512).ToString())));
                parent.BtnManager_Click(null, null);

                TxtResponse.Text = "Login successful!";
                TxtResponse.ForeColor = Color.White;
            }
            if (parent.loggedin)
            {
                pw = new Rfc2898DeriveBytes(TxtPwd.Text, Encoding.ASCII.GetBytes(HashIt(TxtFileIn.Text)), 100000, HashAlgorithmName.SHA512).ToString();
                fpath = Path.Combine(Properties.Settings.Default.path, HashIt(TxtFileIn.Text));
            }
            TxtPwd.Text = "";
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
                Properties.Settings.Default.Save();
                TxtFilePath.Text = Properties.Settings.Default.path;
            }
            else{}
            TxtFileIn_TextChanged(null, null);
        }

        private void LoginPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ActiveControl == TxtFileIn)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                {
                    this.ActiveControl = TxtPwd;
                }
            }
            else if (this.ActiveControl == TxtPwd)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnLogin_Click(null, null);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    this.ActiveControl = BtnLogin;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    this.ActiveControl = TxtFileIn;
                }
            }
        }

        public void Sync()
        {
            if (parent.loggedin)
            {
                if (parent.GetMegaStuff("username") != "")
                {
                    //check internet Connection
                    parent.addSyncResponse("Checking Internet Connection");
                    try 
                    {
                        using (var client = new System.Net.WebClient())
                        using (var stream = client.OpenRead("http://www.google.com")) { }
                    }
                    catch
                    {
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "You are not connected to the Internet");
                        return;
                    }

                    //login to the Mega.nz account
                    parent.addSyncResponse("Logging into Mega.nz");
                    var mega = new MegaApiClient();
                    try
                    {
                        if (parent.GetMegaStuff("2FACodes") == "")
                            mega.Login(parent.GetMegaStuff("username"), parent.GetMegaStuff("password"));
                        else
                        {
                            try
                            {
                                mega.Login(parent.GetMegaStuff("username"), parent.GetMegaStuff("password"), parent.GetMegaStuff("2FA"));
                            }
                            catch (Exception)
                            {
                                mega.Login(parent.GetMegaStuff("username"), parent.GetMegaStuff("password"));
                            }
                        }
                    }
                    catch (Exception)
                    {
                        mega.Logout();
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem logging into your mega account!" + Environment.NewLine + "Please review your password of 'Mega(Sync)'.");
                        return;
                    }

                    IEnumerable<INode> nodes = mega.GetNodes();
                    //Test if this is the first Sync of this account
                    INode syncFolder = null;
                    INode syncFile = null;
                    parent.addSyncResponse("Checking if folder exists");
                    try //Create "dumbManager" folder if it doesn't exist
                    {
                        syncFolder = nodes.Single(x => x.Name == "dumbManager");
                    }
                    catch (Exception)
                    {
                        INode root = nodes.Single(x => x.Type == NodeType.Root);
                        try
                        {
                            syncFolder = mega.CreateFolder("dumbManager", root);
                            INode newFile = mega.UploadFile(fpath + ".db", syncFolder);
                        }
                        catch (Exception)
                        {
                            mega.Logout();
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem uploading your file!");
                            return;
                        }
                        mega.Logout();
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "Uploaded local file.");
                        return;
                    }
                    parent.addSyncResponse("Checking if file exists");
                    try //Create 
                    {
                        syncFile = nodes.Single(x => x.Name == Path.GetFileName(fpath));
                    }
                    catch (Exception)
                    {
                        try
                        {

                            parent.addSyncResponse("");
                            INode newFile = mega.UploadFile(fpath + ".db", syncFolder);
                        }
                        catch (Exception)
                        {
                            mega.Logout();
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem uploading your file!");
                            return;
                        }
                        mega.Logout();
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "Uploaded local file.");
                        return;
                    }

                    //Download files into temp Folder
                    nodes = mega.GetNodes(syncFolder);
                    string tmpFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                    try
                    {
                        while (Directory.Exists(tmpFolder))
                            tmpFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                        Directory.CreateDirectory(tmpFolder);

                        foreach (INode node in nodes.Where(x => x.Type == NodeType.File))
                        {
                            parent.addSyncResponse($"Downloading {node.Name}");
                            mega.DownloadFile(node, Path.Combine(tmpFolder, node.Name));
                        }
                    }
                    catch (Exception)
                    {
                        mega.Logout();
                        Cleanup(tmpFolder);
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been problem downloading the files!");
                        return;
                    }
                    mega.Logout();

                    //Read local update file and update the downloaded File
                    if (File.Exists(fpath))
                    {
                        parent.addSyncResponse("Updating Password Manager");
                        try
                        {
                            using (FileStream fileStream = File.OpenRead(fpath))
                            {
                                var bytes = new byte[fileStream.Length];
                                fileStream.Read(bytes, 0, bytes.Length);
                                SymmetricAlgorithm crypt = Aes.Create();
                                HashAlgorithm hash = SHA256.Create();
                                crypt.Key = hash.ComputeHash(Encoding.ASCII.GetBytes(pw));
                                crypt.IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

                                using (MemoryStream memoryStream = new MemoryStream(bytes))
                                {
                                    using (CryptoStream cryptoStream =
                                        new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                                    {
                                        byte[] decryptedBytes = new byte[bytes.Length];
                                        cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                                        string[] updates = Encoding.ASCII.GetString(decryptedBytes).Split(Environment.NewLine);
                                        foreach (string update in updates)
                                        {
                                            //!!! make changes to dowloaded file
                                        }
                                    }
                                }
                            }

                        }
                        catch (Exception)
                        {
                            Cleanup(tmpFolder);
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been an unknown error while updating local file!");
                            return;
                        }
                    }

                    //Move all files and overwrite only Password Manager
                    string[] files = Directory.GetFiles(tmpFolder);
                    string localFolder = Path.GetDirectoryName(fpath);
                    foreach (string file in files)
                    {
                        if (Path.Combine(localFolder, Path.GetFileName(file)) == fpath + ".db")
                        {
                            parent.addSyncResponse($"Moving {Path.GetFileName(file)} to local Folder");
                            File.Move(file, Path.Combine(localFolder, Path.GetFileName(file)), true);
                        }
                        else
                            File.Move(file, Path.Combine(localFolder, Path.GetFileName(file)), false);
                    }

                    Cleanup(tmpFolder);
                    parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem logging into your mega account!" + Environment.NewLine + "Please review your password of 'Mega(Sync)'.");
                    return;
                }
                else
                {
                    parent.CreateMega();
                    parent.setSyncResponse("ERROR:" + Environment.NewLine + "You have to create an Account on mega.nz and update the usename and password in the Password Manager: 'Mega(Sync)'!");
                    return;
                }
            }
            else
            {
                parent.BtnManager_Click(null, null);
                parent.setSyncResponse("ERROR:" + Environment.NewLine + "Please login first!");
                return;
            }
        }
        private void Cleanup(string folderpath)
        {
            string[] files = Directory.GetFiles(folderpath);
            parent.addSyncResponse("Cleaning temporary files:");
            foreach (string file in files)
            {
                try
                {
                    parent.addSyncResponse($"Deleting {Path.GetFileName(file)}");
                    File.Delete(file);
                }
                catch (Exception)
                {
                    parent.addSyncResponse("ERROR: " + Environment.NewLine + $"Failed to delete {Path.GetFileName(file)}");
                }
            }
            try
            {
                parent.addSyncResponse("Deleting temporary folder");
                Directory.Delete(folderpath, true);
            }
            catch (Exception)
            {
                parent.addSyncResponse("ERROR: " + Environment.NewLine + "Failed to delete temporary folder");
            }
        }
    }
}

