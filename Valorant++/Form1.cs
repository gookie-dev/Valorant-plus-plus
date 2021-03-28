using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
using DiscordRPC;


namespace Valorant__
{
    public partial class Form1 : Form
    {
        private string valorantPath = "-";
        private dynamic userData;
        private string valorantData;
        private string password;
        private string port;
        private string puuid = "";
        private DiscordRpcClient drpc;
        bool discord = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(450, 520);
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
            NewLog("getting valorant data from " + this.userData.game_name + "#" + this.userData.game_tag + " ...");
            GetValorantData();
            NewLog("valorant data from " + this.userData.game_name + "#" + this.userData.game_tag + " were detected!");
            Thread isValorantStillRunningThread = new Thread(new ThreadStart(IsValorantStillRunning));
            isValorantStillRunningThread.IsBackground = true;
            isValorantStillRunningThread.Start();
            drpc = new DiscordRpcClient("825736299583504435");
            drpc.Initialize();
            Thread updateThread = new Thread(new ThreadStart(ValorantDataUpdate));
            updateThread.IsBackground = true;
            updateThread.Start();
        }

        public void DiscordUpdater()
        {
            string details = String.Empty;
            string state = String.Empty;
            string largeImageKey = $"valorant";
            string largeImageText = String.Empty;
            string smallImageKey = $"green";
            string smallImageText = String.Empty;

            if(discord)
            {
                drpc.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = details,
                    State = state,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageKey,
                        LargeImageText = largeImageText,
                        SmallImageKey = smallImageKey,
                        SmallImageText = smallImageText
                    }
                });
            }
        }

        private string GenerateClientApiData()
        {
            byte[] data = Convert.FromBase64String(this.valorantData);
            return userData.ToString().Replace("{", "").Replace("}", "").Remove(0, 1) + JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data)).ToString().Replace("{", "").Replace("}", "").Remove(0, 1);
        }

        private void ValorantDataUpdate()
        {
            NewClientApi(GenerateClientApiData());
            DiscordUpdater();
            while (true)
            {
                string currentValorantData = this.valorantData;
                GetValorantData();
                if(currentValorantData != this.valorantData)
                {
                    NewClientApi(GenerateClientApiData());
                    DiscordUpdater();
                }
                Thread.Sleep(100);
            }
        }

        private void IsValorantStillRunning()
        {
            while(Process.GetProcessesByName("VALORANT").Length > 0) {Thread.Sleep(100);}
            NewLog("valorant was closed! valorant++ will close in 10 seconds.");
            Thread.Sleep(10000);
            Application.Exit();
        }

        private void GetValorantData()
        {
            while(true)
            {
                dynamic request = JsonConvert.DeserializeObject(ClientApiRequest("https://127.0.0.1:" + this.port + "/chat/v4/presences", this.password));
                foreach(dynamic d in request.presences)
                {
                    if(d.puuid == this.puuid)
                    {
                        this.valorantData = Dynamic.InvokeGet(d, "private").ToString();
                        return;
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void GetUserData()
        {
            BypassCertificateError();

            while (true)
            {
                this.userData = JsonConvert.DeserializeObject(ClientApiRequest("https://127.0.0.1:" + this.port + "/chat/v1/session", this.password));
                this.puuid = this.userData.puuid;
                if(this.userData.puuid > 1 && this.userData.game_name > 1)
                {
                    NewLog("found player: " + this.userData.game_name + "#" + this.userData.game_tag);
                    return;
                }
                Thread.Sleep(100);
            }
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
                            i ++;
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

        private void txtValorantPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.exe | *.exe";
            openFileDialog1.Title = "Valorant++";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = @"C:\Program Files (x86)\Riot Games\Riot Client";
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;

            if (path != "")
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.discord = checkBox1.Checked;
            if(this.discord == false)
            {
                drpc.ClearPresence();
                NewLog("discord rich presence was disabled");
            }
            if (this.discord == true)
            {
                DiscordUpdater();
                NewLog("discord rich presence was enabled");
            }
        }
    }
}
