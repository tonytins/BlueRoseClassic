// This project is licensed under the GNU GPL-2.0 license.
// See the LICENSE file in the project root for more information.
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace ZACKUpdater
{
    class ClientUpdate
    {
        readonly WebClient _client = new WebClient();

        private string downloadedFile { get; set; }

        public void Install(Uri address, string compressedFile)
        {
            _client.DownloadFileCompleted += new AsyncCompletedEventHandler(Extract);
            _client.DownloadFileAsync(address, compressedFile);
            downloadedFile = compressedFile;
        }

        private void Extract(object sender, AsyncCompletedEventArgs e)
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
