﻿// Copyright(C) 2016  Blue Rose Project

// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.

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

namespace BlueRose
{
    public partial class BlueRoseGUI : Form
    {
        private string errorBtn = "ERROR";
        WebClient client = new WebClient();
        string netBuild = "#" + WhiteRose.DistNumLegacy();
        string buildFile = "fsobuild";
        string simplyupdate = "simplyupdate.zip";
        string blupdateraddress = "https://dl.dropboxusercontent.com/u/42345729/simplyupdateb.zip";

        public BlueRoseGUI()
        {
            try
            {
                InitializeComponent();

                this.MaximizeBox = false;
                this.MinimizeBox = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

        private void updaterdownload(object sender, AsyncCompletedEventArgs e)
        {
            using (ZipFile zip2 = ZipFile.Read(simplyupdate))
            {
                foreach (ZipEntry ex in zip2)
                {
                    ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }

            Process.Start("SimplyUpdate.exe");
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            WhiteRose.StartFSO("FreeSO.exe", parmaBox.Text);
           
        }

        private void devBtn_Click(object sender, EventArgs e)
        {
            WhiteRose.StartFSO("FSO.IDE.exe", parmaBox.Text);
        }

        private void BlueRoseGUI_Load(object sender, EventArgs e)
        {
            WhiteRose.ZipGC();

            string distroDLL = "BlueRose.Distro.dll";
            string distroPdb = "BlueRose.Distro.pdb";
            if (File.Exists(distroDLL) && File.Exists(distroPdb))
            {
                File.Delete(distroDLL);
                File.Delete(distroPdb);
            }

            try
            {
                localBuild.Text = WhiteRose.ReadBuild(buildFile);
                onlineBuildLabel.Text = "#" + WhiteRose.DistNumLegacy();
                this.Text = "BlueRose v" + WhiteRose.appVersion;

#if DEBUG
                Ping pinger = new Ping();
                bool pingable = false;

                try
                {
                    PingReply reply = pinger.Send(blupdateraddress);
                    if (pingable = reply.Status == IPStatus.Success)
                    {
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(updaterdownload);

                        client.DownloadFileAsync(new Uri(blupdateraddress), simplyupdate);
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                WhiteRose.ZipGcCompat();
                
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(freeSODownloadCompleted);
                client.DownloadFileAsync(TeamCity.teamCityAddress(), "teamcity.zip");
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
                btnUpdate.Text = errorBtn;
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

                WhiteRose.WriteBuild(buildFile);

                localBuild.Text = WhiteRose.ReadBuild(buildFile);
                idleProgressBar.Style = ProgressBarStyle.Blocks;
                btnUpdate.Text = "Update FreeSO";
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                btnUpdate.Text = errorBtn;
                localBuild.Text = "?";
                btnUpdate.Enabled = false;
                devBtn.Enabled = false;
                playBtn.Enabled = false;
            }

        }
        

        private void btnUpdateLauncher_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo newProccess = new ProcessStartInfo("SimplyUpdate.exe");
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

        private void onlineBuildLabel_Click(object sender, EventArgs e)
        {
            try
            {
                onlineBuildLabel.Text = "#" + WhiteRose.DistNumLegacy();
            }
            catch
            {
                onlineBuildLabel.Text = "FAILED";
            }
        }
    }
}
