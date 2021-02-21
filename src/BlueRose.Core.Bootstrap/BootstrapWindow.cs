using System;
using System.Net.Http;
using System.Windows.Forms;
using BlueRose.Github.Releases;

namespace BlueRose.Core.Bootstrap
{
    public partial class BootstrapWindow : Form
    {
        const string PROGRAM = "BlueRose.exe";

        public BootstrapWindow()
        {
            try
            {
                InitializeComponent();
                var majorMinor = $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}";
                var patchCommit = $"{ThisAssembly.Git.SemVer.Patch}-{ThisAssembly.Git.Commit}";
                Text += $@" {majorMinor}.{patchCommit}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void BootstrapWindow_Load(object sender, EventArgs e)
        {
            progBar.Style = ProgressBarStyle.Marquee;
            progBar.MarqueeAnimationSpeed = 50;

            try
            {
                using var client = new HttpClient();
                var dev = "tonytins";
                var repo = "BlueRose";
                var settings = new ReleaseDownloaderSettings(client, dev, repo,
                    BootstrapSettings.GetSettings.Preview,
                    AppDomain.CurrentDomain.BaseDirectory);
                var downloader = new ReleaseDownloader(settings);

                var curVersion = $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.SemVer.Patch}";
                var isMostRecent = downloader.IsLatestRelease(curVersion);

                if (!isMostRecent)
                    downloader.DownloadLatestRelease();
                else
                {
                    MessageBox.Show("Launched Blue Rose");
                }

                downloader.DeInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //try
                //{
                //    var launcherProcess = new Process { StartInfo = { FileName = PROGRAM, UseShellExecute = true } };

                //    launcherProcess.Start();
                //    Application.Exit();
                //}
                //catch
                //{
                //    try
                //    {
                //        Application.Exit();
                //    }
                //    catch
                //    {
                //        Environment.Exit(0);
                //    }
                //}
            }
        }
    }
}
