﻿using System;
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
//using CG.Web.MegaApiClient;
using Open.Mega;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

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
                //Check for updated file
                if (File.Exists(filepath + ".tmp"))
                {
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
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "An updated file has been detected but there has been a problem replacing the old file!");
                        }
                    }
                    if (cont)
                    {
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "An updated file has been detected and successfully replaced!");
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

        public void AddToFile(string line)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(line);
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = SHA256.Create();
            crypt.BlockSize = 128;
            crypt.Key = hash.ComputeHash(Encoding.ASCII.GetBytes(pw));
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
                
                #region first OpenMega
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
                    var mega = new MegaClient();
                    try
                    {
                        mega.Login(parent.GetMegaStuff("username"), parent.GetMegaStuff("password"), CancellationToken.None);
                    }
                    catch (Exception)
                    {
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem logging into your mega account!" + Environment.NewLine + "Please review your password of 'Mega(Sync)'.");
                        parent.finishedSyncing();
                        return;
                    }
                    var wait4node = mega.GetNodes(CancellationToken.None);
                    //wait4node.Wait();
                    var nodes = wait4node.Result;

                    //Test if this is the first Sync of this account
                    Node syncFolder = null;
                    Node syncFile = null;
                    parent.addSyncResponse("Checking if folder exists");
                    try //Create "dumbManager" folder if it doesn't exist
                    {
                        syncFolder = nodes.Single(x => x.Name == "dumbManager");
                    }
                    catch (Exception)
                    {
                        Node root = nodes.Single(x => x.Type == NodeType.Root);
                        try
                        {
                            var wait4syncFolder = mega.CreateFolder("dumbManager", root, CancellationToken.None);
                            //wait4syncFolder.Start();
                            //wait4syncFolder.Wait();
                            syncFolder = wait4syncFolder.Result;
                            using (Stream uplStream = new FileStream(fpath + ".db", FileMode.Open))
                            {
                                var wait4uploadFile = mega.Upload(uplStream, HashIt(TxtFileIn.Text), syncFolder, null, CancellationToken.None);
                            }
                        }
                        catch (Exception)
                        {
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem uploading your file!");
                            parent.finishedSyncing();
                            return;
                        }
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "Uploaded local file.");
                        parent.finishedSyncing();
                        return;
                    }
                    parent.addSyncResponse("Checking if file exists");
                    try
                    {
                        syncFile = nodes.Single(x => x.Name == Path.GetFileName(fpath));
                    }
                    catch (Exception)
                    {
                        try
                        {
                            using (Stream uplStream = new FileStream(fpath + ".db", FileMode.Open))
                            {
                                var wait4uploadFile = mega.Upload(uplStream, HashIt(TxtFileIn.Text), syncFolder, null, CancellationToken.None);
                                //wait4uploadFile.Start();
                                //wait4uploadFile.Wait();
                                //!!! wait4uploadFile.Dispose();
                            }
                        }
                        catch (Exception)
                        {
                            parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been a problem uploading your file!");
                            parent.finishedSyncing();
                            return;
                        }
                        parent.setSyncResponse("SUCCESS:" + Environment.NewLine + "Uploaded local file.");
                        parent.finishedSyncing();
                        return;
                    }

                    //Download files into temp Folder
                    string tmpFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                    try
                    {
                        while (Directory.Exists(tmpFolder))
                            tmpFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                        Directory.CreateDirectory(tmpFolder);

                        foreach (Node node in nodes.Where(x => x.Type == NodeType.File))
                        {
                            parent.addSyncResponse($"Downloading {node.Name}");
                            var wait4downloadFile = mega.Download(node, CancellationToken.None); //Path.Combine(tmpFolder, node.Name)
                            //wait4downloadFile.Start();
                            wait4downloadFile.Wait();
                            //!!! wait4downloadFile.Dispose();
                        }
                    }
                    catch (Exception)
                    {
                        Cleanup(tmpFolder);
                        parent.setSyncResponse("ERROR:" + Environment.NewLine + "There has been problem downloading the files!");
                        parent.finishedSyncing();
                        return;
                    }

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
                        mega.Delete(syncFile, CancellationToken.None);
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
                                using (Stream uplStream = new FileStream(Path.Combine(localFolder, Path.GetFileName(file)), FileMode.Open))
                                {
                                    var wait4uploadFile = mega.Upload(uplStream, HashIt(TxtFileIn.Text), syncFolder, null, CancellationToken.None);
                                    //wait4uploadFile.Start();
                                    //wait4uploadFile.Wait();
                                    //!!! wait4uploadFile.Dispose();
                                }
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
                #endregion first OpenMega

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
                    parent.addSyncResponse($"Deleting {Path.GetFileName(file)}");
                    File.Delete(file);
                }
                catch (Exception)
                {
                    parent.addSyncResponse("ERROR: Failed to delete" + Environment.NewLine + Path.GetFileName(file));
                }
            }
            try
            {
                parent.addSyncResponse("Deleting temporary folder");
                Directory.Delete(folderpath, true);
            }
            catch (Exception)
            {
                parent.addSyncResponse("ERROR: Failed to delete temporary folder");
            }
        }
    }
}

