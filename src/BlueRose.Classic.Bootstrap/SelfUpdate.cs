// This project is licensed under the GNU GPL-2.0 license.
// See the LICENSE file in the project root for more information.
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace BlueRose.Classic.Bootstrap
{
    public class SelfUpdate
    {
        readonly WebClient _client = new WebClient();

        string downloadedFile { get; set; }
        public static string NewProccessInfo { get; set; }

        public void Install(Uri address, string compressedFile, string newProcess)
        {
            _client.DownloadFileCompleted += new AsyncCompletedEventHandler(ExtractExit);
            _client.DownloadFileAsync(address, compressedFile);
            NewProccessInfo = newProcess;
            downloadedFile = compressedFile;
        }

        void ExtractExit(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                using (var archive = ZipFile.OpenRead(downloadedFile))
                {
                    foreach (var ex in archive.Entries)
                    {
                        ex.ExtractToFile(Path.Combine(Environment.CurrentDirectory, ex.FullName), true);
                    }
                }

                UpdateGC.GC();

                try
                {
                    var newProccess = new ProcessStartInfo(NewProccessInfo) { UseShellExecute = true, Verb = "runas" };
                    Process.Start(newProccess);
                    Environment.Exit(0);
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
