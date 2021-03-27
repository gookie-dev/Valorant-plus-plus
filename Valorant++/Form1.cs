using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Dynamitey;
using Newtonsoft.Json;

namespace Valorant__
{
    public partial class Form1 : Form
    {
        private string valorantPath = "-";
        private dynamic userData;
        private dynamic valorantData;
        private string password;
        private string port;
        private string puuid;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageLogs;
            Thread mainThread = new Thread(new ThreadStart(Main));
            mainThread.IsBackground = true;
            mainThread.Start();
        }

        private void Main()
        {
            GetSavedPath();
            IsValorantRunning();
            GetClientApiCredentials();
            GetUserData();
            GetValorantData();
            NewClientApi(this.userData.ToString() + this.valorantData.ToString());
        }

        private void GetValorantData()
        {
            dynamic request = JsonConvert.DeserializeObject(ClientApiRequest("https://127.0.0.1:" + this.port + "/chat/v4/presences", this.password));
            foreach(dynamic d in request.presences)
            {
                if(d.puuid == this.puuid)
                {
                    string playerData = Dynamic.InvokeGet(d, "private");
                    byte[] data = Convert.FromBase64String(playerData);
                    this.valorantData = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data));
                    return;
                }
            }
            NewLog("ERROR! cant read valorant data! maybe only the launcher is open and not the game");
            while (true) ;
        }

        private void GetUserData()
        {
            BypassCertificateError();

            this.userData = JsonConvert.DeserializeObject(ClientApiRequest("https://127.0.0.1:" + this.port + "/chat/v1/session", this.password));
            this.puuid = this.userData.puuid;
            if (this.puuid.Length < 1)
            {
                NewLog("ERROR! cant read user data! maybe you have the launcher open but are not logged in.");
                while (true) ;
            }
            NewLog("found player: " + this.userData.game_name + "#" + this.userData.game_tag);
        }

        private string ClientApiRequest(string url, string password)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var client = new WebClient { Credentials = new NetworkCredential("riot", password) };
            return client.DownloadString(url);
        }

        private static void BypassCertificateError()
        {
            ServicePointManager.ServerCertificateValidationCallback += delegate (Object sender1, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
        }

        private void GetClientApiCredentials()
        {
            NewLog("getting client api credentials...");
            try
            {
                File.Copy(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData) + @"\Riot Games\Riot Client\Config\lockfile",
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Riot Games\Riot Client\Config\Valorant DRP.txt", true);
            }
            catch (Exception)
            {
                NewLog("ERROR! cant read lockfile!");
                while (true) ;
            }

            try
            {
                Stream s = File.Open(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Riot Games\Riot Client\Config\Valorant DRP.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(s);
                string lockFile = sr.ReadLine();
                List<string> lockList = lockFile.Split(':').ToList();
                this.port = lockList[2];
                this.password = lockList[3];
            }
            catch (Exception)
            {
                NewLog("ERROR! cant read client api credentials!");
                while (true) ;
            }
        }

        public delegate void DisplayValorantPathDelegate(string path);

        private void DisplayValorantPath(string path)
        {
            if (!this.txtValorantPath.InvokeRequired)
            {
                this.txtValorantPath.Text = path;
            }
            else
            {
                this.Invoke(new DisplayValorantPathDelegate(DisplayValorantPath), new object[] { path });
            }
        }

        private void IsValorantRunning()
        {
            if (Process.GetProcessesByName("VALORANT").Length < 1)
            {
                if(this.valorantPath == "-")
                {
                    NewLog("valorant is not running! start valorant or set the valorant path in the settings to start it automatically.");
                    while (true) ;
                }
                else
                {
                    try
                    {
                        NewLog("starting valorant...");
                        Process p = new Process();
                        p.StartInfo.FileName = this.valorantPath;
                        p.StartInfo.Arguments = "--launch-product=valorant --launch-patchline=live";
                        p.Start();
                        int i = 1;
                        while(Process.GetProcessesByName("VALORANT").Length < 1)
                        {
                            i += 1;
                            if(i > 200)
                            {
                                NewLog("valorant has not been detected yet. maybe you specified the wrong valorant path or are not logged in!");
                                i = 0;
                            }
                            Thread.Sleep(100);
                        }
                    }
                    catch (Exception)
                    {
                        NewLog("ERROR! cant find " + this.valorantPath);
                        while (true) ;
                    }
                }
            }
            NewLog("valorant was successfully detected!");
            Thread.Sleep(1000);
        }

        private void GetSavedPath()
        {
            try
            {
                this.valorantPath = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Valorant++\settings.txt");
            }
            catch (Exception) { };
            DisplayValorantPath(this.valorantPath);
        }

        public delegate void NewLogDelegate(string log);
        private void NewLog(string log)
        {
            if (!this.txtBoxLogs.InvokeRequired)
            {
                this.txtBoxLogs.Text += ">_ " + log + "\r\n";
            }
            else
            {
                this.Invoke(new NewLogDelegate(NewLog), new object[] { log });
            }
        }

        public delegate void NewClientApiDelegate(string data);
        private void NewClientApi(string data)
        {
            if (!this.txtBoxLogs.InvokeRequired)
            {
                this.txtBoxClientApi.Text = data;
            }
            else
            {
                this.Invoke(new NewClientApiDelegate(NewClientApi), new object[] { data });
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.exe | *.exe";
            openFileDialog1.Title = "Valorant++";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = @"C:\Program Files (x86)\Riot Games\Riot Client";
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;

            if(path != "")
            {
                this.valorantPath = path;
                DisplayValorantPath(this.valorantPath);

                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Valorant++"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Valorant++");
                }

                using (StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Valorant++\settings.txt"))
                {
                    sw.Write(path);
                }

                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Valorant++\settings.txt", path);

                NewLog("valorant path changed! please restart valorant++");
                MessageBox.Show("The path has been changed. Please restart Valorant++", "Valorant++", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
