// This project is licensed under the GNU GPL-2.0 license.
// See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace BlueRose.Classic.Bootstrap
{
    public partial class UpdateWindow : Form
    {
        readonly Uri _address = new Uri(@"https://dl.dropboxusercontent.com/u/42345729/bluerose.zip");
        static readonly string _program = "BlueRoseLauncher.exe";
        public static IEnumerable<string> UpdateParmas { get; set; }

        public UpdateWindow()
        {
            InitializeComponent();
        }

        void UpdateWindow_Load(object sender, EventArgs e)
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
                    var launcherProcess = new Process
                    {
                        StartInfo =
                        {
                            FileName = _program,
                            UseShellExecute = true
                        }
                    };

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
