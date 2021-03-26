using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Valorant__
{
    public partial class Form1 : Form
    {
        private string valorantPath = "-";

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
            NewLog("running...");
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
                                NewLog("valorant has not been detected yet. maybe you specified the wrong valorant path.");
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
