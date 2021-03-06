// This project is licensed under the GNU GPL-2.0 license.
// See the LICENSE file in the project root for more information.

// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using Ionic.Zip;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;

namespace BlueRose.Classic.Client
{
    public partial class BlueRoseGUI : Form
    {
        readonly string _errorBtn = "ERROR";
        readonly WebClient _client = new WebClient();
        string _netBuild = $"#{WhiteRose.DistNumLegacy()}";
        readonly string _buildFile = "fsobuild";
        readonly string _simplyupdate = "simplyupdate.zip";
        readonly string _blupdateraddress = "https://dl.dropboxusercontent.com/u/42345729/simplyupdateb.zip";

        public BlueRoseGUI()
        {
            try
            {
                InitializeComponent();

                MaximizeBox = false;
                MinimizeBox = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void updaterdownload(object sender, AsyncCompletedEventArgs e)
        {
            using (var zip2 = ZipFile.Read(_simplyupdate))
            {
                foreach (var ex in zip2)
                {
                    ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }

            Process.Start("SimplyUpdate.exe");
        }

        void playBtn_Click(object sender, EventArgs e)
        {
            WhiteRose.StartFSO("FreeSO.exe", parmaBox.Text);

        }

        void devBtn_Click(object sender, EventArgs e)
        {
            WhiteRose.StartFSO("FSO.IDE.exe", parmaBox.Text);
        }

        void BlueRoseGUI_Load(object sender, EventArgs e)
        {
            WhiteRose.ZipGC();

            var distroDll = "BlueRose.Distro.dll";
            var distroPdb = "BlueRose.Distro.pdb";
            if (File.Exists(distroDll) && File.Exists(distroPdb))
            {
                File.Delete(distroDll);
                File.Delete(distroPdb);
            }

            try
            {
                localBuild.Text = WhiteRose.ReadBuild(_buildFile);
                onlineBuildLabel.Text = $"#{WhiteRose.DistNumLegacy()}";
                Text = $"BlueRose v{WhiteRose.appVersion}";

#if DEBUG
                var pinger = new Ping();
                var pingable = false;

                try
                {
                    var reply = pinger.Send(_blupdateraddress);
                    if (pingable = reply.Status == IPStatus.Success)
                    {
                        _client.DownloadFileCompleted += new AsyncCompletedEventHandler(updaterdownload);

                        _client.DownloadFileAsync(new Uri(_blupdateraddress), _simplyupdate);
                    }
                }
                catch (PingException ex)
                {
                    Console.WriteLine(ex.Message);
                    // MessageBox.Show(ex.Message);

                }
#endif
            }
            catch
            {
                onlineBuildLabel.Text = "Offline";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                WhiteRose.ZipGcCompat();

                _client.DownloadFileCompleted += new AsyncCompletedEventHandler(freeSODownloadCompleted);
                _client.DownloadFileAsync(TeamCity.teamCityAddress(), "teamcity.zip");
                idleProgressBar.Style = ProgressBarStyle.Marquee;
                btnUpdate.Text = "Update FreeSO";
                btnUpdate.Enabled = false;
                devBtn.Enabled = false;
                playBtn.Enabled = false;
                btnUpdateLauncher.Enabled = false;

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                btnUpdate.Text = _errorBtn;
                btnUpdate.Enabled = false;
            }


        }

        void freeSODownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {

            btnUpdate.Text = "Installing";

            try
            {
                TeamCity.tcUnpack();

                btnUpdate.Enabled = true;
                btnUpdateLauncher.Enabled = true;
                devBtn.Enabled = true;
                playBtn.Enabled = true;

                WhiteRose.WriteBuild(_buildFile);

                localBuild.Text = WhiteRose.ReadBuild(_buildFile);
                idleProgressBar.Style = ProgressBarStyle.Blocks;
                btnUpdate.Text = "Update FreeSO";
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                btnUpdate.Text = _errorBtn;
                localBuild.Text = "?";
                btnUpdate.Enabled = false;
                devBtn.Enabled = false;
                playBtn.Enabled = false;
            }

        }


        void btnUpdateLauncher_Click(object sender, EventArgs e)
        {
            try
            {
                var newProccess = new ProcessStartInfo("SimplyUpdate.exe");
                newProccess.UseShellExecute = true;
                newProccess.Verb = "runas";
                Process.Start(newProccess);
                try
                {
                    Application.Exit();
                }
                catch
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void onlineBuildLabel_Click(object sender, EventArgs e)
        {
            try
            {
                onlineBuildLabel.Text = $"#{WhiteRose.DistNumLegacy()}";
            }
            catch
            {
                onlineBuildLabel.Text = "FAILED";
            }
        }
    }
}
