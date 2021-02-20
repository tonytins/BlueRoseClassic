using System;
using System.Diagnostics;
using System.Windows.Forms;
using ZACKUpdater;

namespace SimplyUpdate
{
    public partial class UpdateWindow : Form
    {
        readonly Uri _address = new Uri(@"https://dl.dropboxusercontent.com/u/42345729/bluerose.zip");
        static readonly string _program = "BlueRoseLauncher.exe";
        public static string[] updateParmas { get; set; }

        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void UpdateWindow_Load(object sender, EventArgs e)
        {
            useLessProgressBar.Style = ProgressBarStyle.Marquee;
            useLessProgressBar.MarqueeAnimationSpeed = 50;

            try
            {
                UpdateInfo.SelfUpdate(_program, _address, "update.zip");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                try
                {
                    var launcherProcess = new Process();

                    launcherProcess.StartInfo.FileName = _program;
                    launcherProcess.StartInfo.UseShellExecute = true;
                    launcherProcess.Start();
                    Application.Exit();
                }
                catch
                {
                    try
                    {
                        Application.Exit();
                    }
                    catch
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

    }
}
