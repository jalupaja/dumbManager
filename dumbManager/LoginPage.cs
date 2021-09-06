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
using Dropbox.Api;
using Dropbox.Api.Files;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace dumbManager
{
    public partial class LoginPage : Form
    {
        private static readonly string APIKEY = "tl57hqmxxg0qjxs"; //CHANGE DROPBOX APP KEY HERE!
        //Full Access  Team App: qy5zl04iap7sbhn
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
            TxtFileIn_TextChanged(null, null);
        }

        public void ColorReload()
        {
            BtnLogin.BackColor = Properties.Settings.Default.AccentColor;
            TxtFileIn.BackColor = Properties.Settings.Default.AccentColor;
            TxtPwd.BackColor = Properties.Settings.Default.AccentColor;
            TxtPwdConfirm.BackColor = Properties.Settings.Default.AccentColor;
        }

        public void Logout()
        {
            TxtFileIn_TextChanged(null, null);
            pw = "";
            fpath = "";
        }

        public string HashIt(String input)
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
                //Check for updated file
                if (File.Exists(filepath + ".tmp"))
                {
                    //Delete leftovers from last sync
                    Directory.Delete(Path.Combine(Path.GetTempPath(), "dumbManagerSync"), true);

                    bool cont = true;
                    try
                    {
                        File.Move(filepath, filepath + ".temp");
                    }
                    catch (Exception)
                    {
                        cont = false;
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "An updated file has been detected but there has been a problem replacing the old file!");
                    }
                    if (cont)
                    {
                        try
                        {
                            File.Move(filepath + ".tmp", filepath);
                        }
                        catch (Exception)
                        {
                            cont = false;
                            File.Move(filepath + ".temp", filepath);
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "An updated file has been detected but there has been a problem replacing the old file!");
                        }
                    }
                    if (cont)
                    {
                        try
                        {
                            File.Delete(filepath + ".temp");
                        }
                        catch (Exception)
                        {
                            cont = false;
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been an error updating your file!");
                        }
                    }
                    if (cont)
                    {
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "Your file has been successfully updated!");
                    }
                }

                //Login
                try
                {
                    parent.loggedin = true;
                    var trying = new SQLiteConnection(new SQLiteConnectionString(filepath, Flags, true, key: TxtPwd.Text));
                    trying.CreateTable<FrmManager.dumbManager>();
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
                    fpath = Path.Combine(Properties.Settings.Default.path, HashIt(TxtFileIn.Text));
                    parent.newManager(new SQLiteConnection(new SQLiteConnectionString(filepath, Flags, true, key: TxtPwd.Text)));
                    parent.BtnManager_Click(null, null);
                }
            }
            else
            {
                //create new encrypted database
                parent.loggedin = true;

                fpath = Path.Combine(Properties.Settings.Default.path, HashIt(TxtFileIn.Text));
                parent.newManager(new SQLiteConnection(new SQLiteConnectionString(filepath, Flags, true, key: TxtPwd.Text)));
                parent.BtnManager_Click(null, null);

                TxtResponse.Text = "Login successful!";
                TxtResponse.ForeColor = Color.White;
            }
            if (parent.loggedin)
            {
                pw = TxtPwd.Text;
            }
            TxtPwd.Text = "";
            TxtPwdConfirm.Text = "";
        }
        private void TxtFileIn_TextChanged(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Properties.Settings.Default.path, HashIt(TxtFileIn.Text) + ".db");

            if (File.Exists(filepath))
            {
                TxtPwdConfirm.Visible = false;
                TxtPwdConfirm.Enabled = false;
                BtnLogin.Text = $"login to {TxtFileIn.Text}";
                TxtResponse.Text = "Please input the password to your account!";
                TxtResponse.ForeColor = Color.White;
            }
            else
            {
                TxtPwdConfirm.Visible = true;
                TxtPwdConfirm.Enabled = true;
                BtnLogin.Text = "create new user";
                TxtResponse.Text = "Please create a secure password \nThe password can not be recovered!";
                TxtResponse.ForeColor = Color.White;
            }
        }
        private void TxtPwdConfirm_TextChanged(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Properties.Settings.Default.path, HashIt(TxtFileIn.Text) + ".db");
            if (TxtPwd.Text == TxtPwdConfirm.Text || File.Exists(filepath))
                BtnLogin.Enabled = true;
            else
                BtnLogin.Enabled = false;
        }

        private void TxtPwd_TextChanged(object sender, EventArgs e)
        {
            if (TxtPwd.Text == TxtPwdConfirm.Text)
                BtnLogin.Enabled = true;
            else
                BtnLogin.Enabled = false;
        }

        private void TxtFilePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browseFolder = new FolderBrowserDialog();
            browseFolder.SelectedPath = Properties.Settings.Default.path;

            if (browseFolder.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.path = browseFolder.SelectedPath.ToString();
                Properties.Settings.Default.Save();
                TxtFilePath.Text = Properties.Settings.Default.path;
            }
            else { }
            TxtFileIn_TextChanged(null, null);
        }

        private void LoginPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ActiveControl == TxtFileIn)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                {
                    this.ActiveControl = TxtPwd;
                    e.Handled = e.SuppressKeyPress = true;
                }
            }
            else if (this.ActiveControl == TxtPwd)
            {
                if (File.Exists(Path.Combine(Properties.Settings.Default.path, HashIt(TxtFileIn.Text) + ".db")))
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        BtnLogin_Click(null, null);
                        e.Handled = e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        this.ActiveControl = BtnLogin;
                        e.Handled = e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        this.ActiveControl = TxtFileIn;
                        e.Handled = e.SuppressKeyPress = true;
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        this.ActiveControl = TxtPwdConfirm;
                        e.Handled = e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        this.ActiveControl = TxtPwdConfirm;
                        e.Handled = e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        this.ActiveControl = TxtFileIn;
                        e.Handled = e.SuppressKeyPress = true;
                    }
                }
            }
            else if (this.ActiveControl == TxtPwdConfirm)
            {
                if (TxtPwd.Text == TxtPwdConfirm.Text)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        BtnLogin_Click(null, null);
                        e.Handled = e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        this.ActiveControl = BtnLogin;
                        e.Handled = e.SuppressKeyPress = true;
                    }
                }
                if (e.KeyCode == Keys.Up)
                {
                    this.ActiveControl = TxtPwd;
                    e.Handled = e.SuppressKeyPress = true;
                }
            }
        }

        public void AddToFile(string line)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(line);
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = SHA256.Create();
            crypt.BlockSize = 128;
            crypt.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(pw));
            crypt.IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }
                File.AppendAllText(fpath, Convert.ToBase64String(memoryStream.ToArray()) + Environment.NewLine);
            }
        }
        public void Sync()
        {
            int failCount = 0;
            parent.setSyncResponse(string.Empty);
            if (parent.loggedin)
            {
                #region firstTry
                /*
                if (parent.GetMegaStuff("username") != "" && parent.GetMegaStuff("username") != string.Empty)
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
                        parent.finishedSyncing();
                        return;
                    }

                    //login to the Mega.nz account
                    parent.addSyncResponse("Logging into Mega.nz");
                    var mega = new MegaApiClient();
                    mega.Login(parent.GetMegaStuff("username"), parent.GetMegaStuff("password"));
                    try
                    {
                        if (parent.GetMegaStuff("2FA") == "")
                            MessageBox.Show("k");
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
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem logging into your mega account!" + Environment.NewLine + "Please review your password of 'Mega(Sync)'.");
                        parent.finishedSyncing();
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
                            parent.finishedSyncing();
                            return;
                        }
                        mega.Logout();
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "Uploaded local file.");
                        parent.finishedSyncing();
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
                            parent.finishedSyncing();
                            return;
                        }
                        mega.Logout();
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "Uploaded local file.");
                        parent.finishedSyncing();
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
                        parent.finishedSyncing();
                        return;
                    }
                    mega.Logout();

                    //Read local update file and update the downloaded File
                    if (File.Exists(fpath))
                    {
                        parent.addSyncResponse("Updating Password Manager");

                        con = new SQLiteConnection(new SQLiteConnectionString(fpath, Flags, true, key: pw));
                        con.BeginTransaction();

                        int failCount = 0;
                        try
                        {
                            string line;
                            var n = parent.getTable();
                            SymmetricAlgorithm crypt = Aes.Create();
                            HashAlgorithm hash = SHA256.Create();
                            crypt.Key = hash.ComputeHash(Encoding.ASCII.GetBytes(pw));
                            crypt.IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                            using (StreamReader file = new StreamReader(fpath))
                            {
                                while ((line = file.ReadLine()) != null)
                                {
                                    byte[] bytes = Convert.FromBase64String(line);
                                    using (MemoryStream memoryStream = new MemoryStream(bytes))
                                    {
                                        using (CryptoStream cryptoStream =
                                           new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                                        {
                                            byte[] decryptedBytes = new byte[bytes.Length];
                                            cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                                            string decLine = Encoding.Unicode.GetString(decryptedBytes);
                                            //!!! apply lines to downloaded file
                                            string[] linePart = decLine.Split(',');
                                            switch (linePart[0])
                                            {
                                                case "INSERT":
                                                    n = parent.getTable();
                                                    n.Name = linePart[1];
                                                    n.Username = linePart[2];
                                                    n.Password = linePart[3];
                                                    n.Url = linePart[4];
                                                    n.TwoFA = linePart[5];
                                                    n.Note = linePart[6];
                                                    parent.addSyncResponse($"Adding {linePart[1]}");
                                                    try
                                                    {
                                                        con.Insert(n);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        parent.addSyncResponse("ERROR:" + Environment.NewLine + $"{linePart[1]} could not be added");
                                                        failCount++;
                                                    }
                                                    n = null;
                                                    break;
                                                case "UPDATE":
                                                    n = parent.getTable();
                                                    n.Id = Convert.ToInt32(linePart[1]);
                                                    n.Name = linePart[2];
                                                    n.Username = linePart[3];
                                                    n.Password = linePart[4];
                                                    n.Url = linePart[5];
                                                    n.TwoFA = linePart[6];
                                                    n.Note = linePart[7];
                                                    parent.addSyncResponse($"Updating {linePart[2]}");
                                                    try
                                                    {
                                                        con.Update(n);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        parent.addSyncResponse($"ERROR: {linePart[2]} could not be updated");
                                                        failCount++;
                                                    }
                                                    n = null;
                                                    break;
                                                case "DELETE":
                                                    n = parent.getTable();
                                                    n.Id = Convert.ToInt32(linePart[1]);
                                                    n.Name = linePart[2];
                                                    n.Username = linePart[3];
                                                    n.Url = linePart[4];
                                                    parent.addSyncResponse($"Deleting {linePart[2]}");
                                                    try
                                                    {
                                                        con.Delete(n);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        parent.addSyncResponse($"ERROR: {linePart[2]} could not be Deleted");
                                                        failCount++;
                                                    }
                                                    n = null;
                                                    break;
                                                default:
                                                    parent.addSyncResponse($"ERROR: Could not Resolve Command");
                                                    failCount++;
                                                    break;
                                            }
                                        }
                                    }
                                }
                                con.Commit();
                                con.Close();
                            }
                        }
                        catch (Exception)
                        {
                            con.Close();
                            Cleanup(tmpFolder);
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been an unknown error while updating local file!");
                            parent.finishedSyncing();
                            return;
                        }
                        parent.addSyncResponse("Error:" + Environment.NewLine + $"There have been {failCount} Errors while Syncing!");
                        if (MessageBox.Show($"There have been {failCount} Errors while Syncing!" + Environment.NewLine + "Are you sure that you want to continue?", $"Encountered {failCount} Errors", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        {
                            Cleanup(tmpFolder);
                            parent.SafeSyncFile(fpath + ".log");
                            parent.setSyncResponse("You can find the log file at" + Environment.NewLine + fpath + ".log");
                            parent.finishedSyncing();
                            return;
                        }
                    }

                    //delete online File
                    try
                    {
                        mega.Delete(syncFile, false);
                    }
                    catch (Exception)
                    {
                        parent.setSyncResponse("Error:" + Environment.NewLine + "There has been a problem deleting the online file!");
                        Cleanup(tmpFolder);
                        parent.finishedSyncing();
                        return;
                    }

                    //Move all files and overwrite only Password Manager
                    string[] files = Directory.GetFiles(tmpFolder);
                    string localFolder = Path.GetDirectoryName(fpath);

                    foreach (string file in files)
                    {
                        parent.addSyncResponse($"Moving {Path.GetFileName(file)} to local Folder");
                        if (Path.Combine(localFolder, Path.GetFileName(file)) == fpath + ".db")
                        {
                            try
                            {
                                INode uploadFile = mega.UploadFile(Path.Combine(localFolder, Path.GetFileName(file)), syncFolder);
                            }
                            catch (Exception)
                            {
                                parent.setSyncResponse("Error:" + Environment.NewLine + "There has been a problem uploading the new file!");
                                Cleanup(tmpFolder);
                                parent.finishedSyncing();
                                return;
                            }
                            try
                            {
                                File.Copy(file, Path.Combine(localFolder, Path.GetFileName(file) + ".tmp"), false);
                            }
                            catch (Exception)
                            {
                                parent.setSyncResponse("Error:" + Environment.NewLine + "There has been a problem copying the new updated file!");
                                Cleanup(tmpFolder);
                                parent.finishedSyncing();
                                return;
                            }
                        }
                        else
                            File.Move(file, Path.Combine(localFolder, Path.GetFileName(file)), false);
                    }

                    Cleanup(tmpFolder);
                    try
                    {
                        parent.addSyncResponse($"Deleting {Path.GetFileName(fpath)}");
                        File.Delete(fpath);
                    }
                    catch (Exception)
                    {
                        parent.addSyncResponse($"ERROR: Failed to delete " + Environment.NewLine + Path.GetFileName(fpath));
                    }

                    parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "" + Environment.NewLine + "The Program will now restart!");
                    ProcessStartInfo psi = new ProcessStartInfo();
                    Process.Start(new ProcessStartInfo("cmd", $" /c 'timeout /t 3 && start \"{System.Reflection.Assembly.GetEntryAssembly().Location}") { CreateNoWindow = false });
                    parent.TrayExit(null, null);
                    parent.finishedSyncing();
                    return;
                }
                else
                {
                    parent.CreateMega();
                    parent.setSyncResponse("You have to create an Account on mega.nz and update the usename and password in the Password Manager: 'Mega(Sync)'!");
                    parent.finishedSyncing();
                    return;
                }
                */
                #endregion firstTry

                #region retry
                /*
                //if (parent.GetMegaStuff("username") != "" && parent.GetMegaStuff("username") != string.Empty)
                if (parent.GetMegaStuff("url") != "" && parent.GetMegaStuff("url") != string.Empty && parent.GetMegaStuff("url") != "https://mega.nz/register")
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
                        parent.finishedSyncing();
                        return;
                    }

                    //login to the Mega.nz account
                    parent.addSyncResponse("Logging into Mega.nz");
                    var mega = new MegaApiClient();
                    try
                    {
                        mega.LoginAnonymous();
                    }
                    catch (Exception)
                    {
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem logging into Mega.nz!");
                        parent.finishedSyncing();
                        return;
                    }
                    INode syncFolder = null;
                    INode syncFile = null;

                    IEnumerable<INode> nodes = mega.GetNodesFromLink(new Uri(parent.GetMegaStuff("url")));
                    foreach (INode node in nodes.Where(x => x.Type == NodeType.Directory))
                    {
                        MessageBox.Show(node.Name);
                        if (node.Name == "dumbManager")
                        {
                            syncFolder = node;
                        }
                    }
                    if (syncFolder == null)
                    {
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "Your url doesnt seem link to the folder 'dumbManager'!");
                        parent.finishedSyncing();
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
                            INode newFile = mega.UploadFile(fpath + ".db", syncFolder);
                        }
                        catch (Exception)
                        {
                            mega.Logout();
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem uploading your file!");
                            parent.finishedSyncing();
                            return;
                        }
                        mega.Logout();
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "Uploaded local file.");
                        parent.finishedSyncing();
                        return;
                    }

                    parent.finishedSyncing();
                    return;
                    */
                #endregion retry

                #region first DropNet
                bool pass = true;
                try
                {
                    _ = new DropboxClient(parent.GetDropStuff().Split('|')[1]);
                }
                catch(Exception)
                {
                    pass = false;
                }
                if (pass)
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
                        parent.finishedSyncing();
                        return;
                    }
                    try
                    {
                        _ = new DropboxClient(parent.GetDropStuff().Split('|')[1]);
                    }
                    catch (Exception)
                    {
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem logging into Dropbox!" + Environment.NewLine + "If this keeps happening, please delete the notes of Dropbox(Sync)!");
                        parent.finishedSyncing();
                        return;
                    }

                    var _client = new DropboxClient(parent.GetDropStuff().Split('|')[1]);

                    string tmpFolder = Path.Combine(Path.GetTempPath(), "dumbManagerSync");
                    while (Directory.Exists(tmpFolder))
                        tmpFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                    Directory.CreateDirectory(tmpFolder);

                    parent.addSyncResponse("Checking if file exists");
                    try
                    {
                        //Download file into temp Folder
                        var response = _client.Files.DownloadAsync("/" + HashIt(TxtFileIn.Text) + ".db");
                        var result = response.Result.GetContentAsStreamAsync();
                        using (var dwl = File.Create(Path.Combine(tmpFolder, HashIt(TxtFileIn.Text) + ".db")))
                        {
                            result.Result.CopyTo(dwl);
                        }
                    }
                    catch (Exception)
                    {
                        parent.addSyncResponse("Uploading local file");
                        try
                        {
                        using (var upl = new FileStream(fpath + ".db", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var response = _client.Files.UploadAsync("/" + HashIt(TxtFileIn.Text) + ".db", WriteMode.Overwrite.Instance, body: upl);
                            var rest = response.Result;
                        }
                        }
                        catch (Exception)
                        {
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem uploading your file!");
                            parent.finishedSyncing();
                            return;
                        }
                        
                        parent.addSyncResponse($"Deleting {Path.GetFileName(fpath)}");
                        File.Delete(fpath);
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "Uploaded local file.");
                        parent.finishedSyncing();
                        return;
                    }
                
                    

                    /*!!! download possible other files, starting with same name(e.g encrypted files)
                    var onlineFiles = _client.Search(HashIt(TxtFileIn.Text) + "*");

                    foreach (var onlineFile in onlineFiles)
                    {
                        parent.addSyncResponse($"Downloading {onlineFile.Name}");
                        try
                        {
                            var fileBytes = _client.GetFile(onlineFile.Path);
                            using (var fs = new FileStream(Path.Combine(tmpFolder, onlineFile.Name), FileMode.Create, FileAccess.Write))
                            {
                                fs.Write(fileBytes, 0, fileBytes.Length);
                            }
                        }
                        catch (Exception)
                        {
                            Cleanup(tmpFolder);
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been problem downloading the files!");
                            parent.finishedSyncing();
                            return;
                        }
                    }
                    */

                    //Read local update file and update the downloaded File
                    if (File.Exists(fpath))
                    {
                        parent.addSyncResponse("Updating Password Manager");
                        try
                        {
                            con = new SQLiteConnection(new SQLiteConnectionString(Path.Combine(tmpFolder, HashIt(TxtFileIn.Text) + ".db"), Flags, true, key: pw));
                            con.CreateTable<FrmManager.dumbManager>();
                        }
                        catch(Exception)
                        {
                            parent.setSyncResponse("ERROR: Your local and online password dont seem to match!");
                            Cleanup(tmpFolder);
                            parent.finishedSyncing();
                            return;
                        }
                        con.BeginTransaction();

                        try
                        {
                            string line;
                            var n = new FrmManager.dumbManager();
                            SymmetricAlgorithm crypt = Aes.Create();
                            HashAlgorithm hash = SHA256.Create();
                            crypt.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(pw));
                            crypt.IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                            using (var str = new FileStream(fpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                using (StreamReader file = new StreamReader(str))
                                {
                                    while ((line = file.ReadLine()) != null)
                                    {
                                        byte[] bytes = Convert.FromBase64String(line);
                                        using (MemoryStream memoryStream = new MemoryStream(bytes))
                                        {
                                            using (CryptoStream cryptoStream =
                                            new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                                            {
                                                byte[] decryptedBytes = new byte[bytes.Length];
                                                cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                                                string decLine = Encoding.Unicode.GetString(decryptedBytes);
                                                //!!! apply lines to downloaded file
                                                string[] linePart = decLine.Split(",,,");
                                                switch (linePart[0])
                                                {
                                                    case "INSERT":
                                                        n = new FrmManager.dumbManager();
                                                        n.Name = linePart[1];
                                                        n.Username = linePart[2];
                                                        n.Password = linePart[3];
                                                        n.Url = linePart[4];
                                                        n.TwoFA = linePart[5];
                                                        n.Note = linePart[6];
                                                        parent.addSyncResponse($"Adding {linePart[1]}");
                                                        try
                                                        {
                                                            con.Insert(n);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            parent.addSyncResponse("ERROR:" + Environment.NewLine + $"{linePart[1]} could not be added");
                                                            failCount++;
                                                        }
                                                        n = null;
                                                        break;
                                                    case "UPDATE":
                                                        n = new FrmManager.dumbManager();
                                                        n.Id = Convert.ToInt32(linePart[1]);
                                                        n.Name = linePart[2];
                                                        n.Username = linePart[3];
                                                        n.Password = linePart[4];
                                                        n.Url = linePart[5];
                                                        n.TwoFA = linePart[6];
                                                        n.Note = linePart[7];
                                                        parent.addSyncResponse($"Updating {linePart[2]}");
                                                        try
                                                        {
                                                            con.Update(n);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            parent.addSyncResponse($"ERROR: {linePart[2]} could not be updated");
                                                            failCount++;
                                                        }
                                                        n = null;
                                                        break;
                                                    case "DELETE":
                                                        n = new FrmManager.dumbManager();
                                                        n.Id = Convert.ToInt32(linePart[1]);
                                                        n.Name = linePart[2];
                                                        n.Username = linePart[3];
                                                        n.Url = linePart[4];
                                                        parent.addSyncResponse($"Deleting {linePart[2]}");
                                                        try
                                                        {
                                                            con.Delete(n);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            parent.addSyncResponse($"ERROR: {linePart[2]} could not be Deleted");
                                                            failCount++;
                                                        }
                                                        n = null;
                                                        break;
                                                    default:
                                                        parent.addSyncResponse($"ERROR: Could not Resolve Command");
                                                        failCount++;
                                                        break;
                                                }
                                        }
                                    }
                                }
                                con.Commit();
                                con.Close();
                            }
                        }
                            
                        }
                        catch (Exception)
                        {
                            con.Close();
                            Cleanup(tmpFolder);
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been an unknown error while updating local file!");
                            parent.finishedSyncing();
                            return;
                        }
                        parent.addSyncResponse("Error:" + Environment.NewLine + $"There have been {failCount} Errors while Syncing!");
                        if (failCount > 0)
                        {
                            new FrmLittleBox($"There have been {failCount} Errors while Syncing!", parent.getSyncResponse()).Show();
                            if (MessageBox.Show($"There have been {failCount} Errors while Syncing!" + Environment.NewLine + "Are you sure that you want to continue?", $"Encountered {failCount} Errors", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                            {
                                Cleanup(tmpFolder);
                                parent.SafeSyncFile(fpath + ".log");
                                parent.setSyncResponse("You can find the log file at" + Environment.NewLine + fpath + ".log");
                                parent.finishedSyncing();
                                return;
                            }
                        }
                    }

                    //delete online file
                    try
                    {
                        var folders = _client.Files.DeleteV2Async("/" + HashIt(TxtFileIn.Text) + ".db");
                        var result = folders.Result;
                    }
                    catch (Exception)
                    {
                        parent.setSyncResponse($"ERROR: Failed to delete online file");
                        Cleanup(tmpFolder);
                        parent.finishedSyncing();
                        return;
                    }

                    //upload local file
                    try
                    {
                        using (var upl = new FileStream(fpath + ".db", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var response = _client.Files.UploadAsync("/" + HashIt(TxtFileIn.Text) + ".db", WriteMode.Overwrite.Instance, body: upl);
                            var rest = response.Result;
                        }
                    }
                    catch (Exception e)
                    {
                        parent.setSyncResponse("Error:" + Environment.NewLine + "There has been a problem updating the online file!" + e.Message);//!!!
                        Cleanup(tmpFolder);
                        parent.finishedSyncing();
                        return;
                    }

                    //Move all files and overwrite only Password Manager
                    string[] files = Directory.GetFiles(tmpFolder);
                    string localFolder = Path.GetDirectoryName(fpath);

                    foreach (string file in files)
                    {
                        parent.addSyncResponse($"Moving {Path.GetFileName(file)} to local Folder");
                        if (Path.Combine(localFolder, Path.GetFileName(file)) == fpath + ".db") //!!!
                        {
                            try
                            {
                                File.Copy(file, Path.Combine(localFolder, Path.GetFileName(file) + ".tmp"), false);
                            }
                            catch (Exception)
                            {
                                parent.setSyncResponse("Error:" + Environment.NewLine + "There has been a problem copying the new updated file!");
                                Cleanup(tmpFolder);
                                parent.finishedSyncing();
                                return;
                            }
                        }
                        else
                            File.Move(file, Path.Combine(localFolder, Path.GetFileName(file)), false);
                    }

                    Cleanup(tmpFolder);
                    try
                    {
                        parent.addSyncResponse($"Deleting {Path.GetFileName(fpath)}");
                        File.Delete(fpath);
                    }
                    catch (Exception)
                    {
                        parent.addSyncResponse($"ERROR: Failed to delete " + Environment.NewLine + Path.GetFileName(fpath));
                    }

                    parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "" + Environment.NewLine + "You have to restart in Order for the changes to take affect!");

                    //!!! restart
                    //!!! Process.Start(Application.ExecutablePath);
                    //!!! parent.TrayExit(null, null);
                    parent.finishedSyncing();
                    return;
                }
                else
                {
                    parent.setSyncResponse("You have to create an Account on dropbox.com authorize the App!");
                    Uri Url = DropboxOAuth2Helper.GetAuthorizeUri(APIKEY);
                    var tmp = new FrmLittleBox("Please open this Link in your browser and paste the Access Code below!", Url.AbsoluteUri, "Paste Access Code here");
                    tmp.ShowDialog();
                    if (tmp.ret == "" || tmp.DialogResult != DialogResult.OK)
                    {
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "You have to enter an Access Code!");
                        parent.finishedSyncing();
                        return;
                    }
                    parent.CreateDropStuff(tmp.ret);

                    Sync();
                    /* //!!!
                    var _client = new DropboxClient(tmp.ret);
                    tmp.Dispose();
                    try
                    {
                        using (var upl = new FileStream(fpath + ".db", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var response = _client.Files.UploadAsync("/" + HashIt(TxtFileIn.Text) + ".db", WriteMode.Overwrite.Instance, body: upl);
                            var rest = response.Result;
                        }
                        
                    }
                    catch (Exception)
                    {
                        _client.Dispose();
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem uploading your file!");
                        parent.finishedSyncing();
                        return;
                    }

                    File.Delete(fpath);
                    _client.Dispose();
                    parent.finishedSyncing();
                    return;
                    */
                }
                #endregion first DropNet

            }
            else
            {
                parent.BtnManager_Click(null, null);
                parent.setSyncResponse("ERROR:" + Environment.NewLine + "Please login first!");
                parent.finishedSyncing();
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
                    if (Path.GetFileName(file) != HashIt(TxtFileIn.Text))
                    {
                        parent.addSyncResponse($"Deleting {Path.GetFileName(file)}");
                        File.Delete(file);
                    }
                }
                catch (Exception)
                {
                    parent.addSyncResponse("ERROR: Failed to delete" + Environment.NewLine + Path.GetFileName(file));
                }
            }
        }
    }
}

