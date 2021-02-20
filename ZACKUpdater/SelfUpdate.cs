using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace ZACKUpdater
{
    public class SelfUpdate
    {
        readonly WebClient _client = new WebClient();

        private string downloadedFile { get; set; }
        public static string newProccessInfo { get; set; }

        public void Install(Uri address, string compressedFile, string newProcess)
        {
            _client.DownloadFileCompleted += new AsyncCompletedEventHandler(ExtractExit);
            _client.DownloadFileAsync(address, compressedFile);
            newProccessInfo = newProcess;
            downloadedFile = compressedFile;
        }

        private void ExtractExit(object sender, AsyncCompletedEventArgs e)
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
                    var newProccess = new ProcessStartInfo(newProccessInfo);
                    newProccess.UseShellExecute = true;
                    newProccess.Verb = "runas";
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
