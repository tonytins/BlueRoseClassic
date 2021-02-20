// Copyright(c) 2016 Blue Rose Project

// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
//  associated documentation files (the "Software"), to deal in the Software without restriction, including
//  without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
//  copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to 
//  the following conditions:

// The above copyright notice and this permission notice shall be included in all copies or substantial 
//  portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//  INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
//  PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
//  FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
//  ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

namespace BlueRose
{
    public class TeamCity
    {

        public static Uri teamCityDist(string address = "servo.freeso.org", string buildType = "ProjectDollhouse_TsoClient", string buildId = "316")
        {
            return new Uri(
                $@"http://{address}/repository/download/{buildType}/{buildId}:id/dist-{WhiteRose.DistNumLegacy()}.zip");
        }

        public static Uri teamCityAddress(string address = "servo.freeso.org", string buildType = "ProjectDollhouse_TsoClient")
        {
            return new Uri(
                $@"http://{address}/guestAuth/downloadArtifacts.html?buildTypeId={buildType}&buildId=lastSuccessful");
        }

        /// <summary>
        /// Downloads and extracts teamcity.zip into the current directory.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <param name="distFile"></param>
        public static void tcManaged(string address = "servo.freeso.org", string buildType = "ProjectDollhouse_TsoClient", string distFile = "teamcity.zip")
        {
            try
            {
                var client = new WebClient();

                var uri = new Uri(
                    $@"http://{address}/guestAuth/downloadArtifacts.html?buildTypeId={buildType}&buildId=lastSuccessful");
                distFile = Path.GetFileName(uri.LocalPath);

                client.DownloadFileAsync(tcAddress(address, buildType), distFile);

                using (var buildUnpack = ZipFile.Read(distFile))
                {
                    foreach (var ex in buildUnpack)
                    {
                        ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Return the latest dist number as a string
        /// Thanks to LRB. http://forum.freeso.org/threads/974/
        /// </summary>
        /// <returns>sLine</returns>
        public static string distNum()
        {
            var url = "http://servo.freeso.org/externalStatus.html?js=1";
            WebRequest wrGeturl;
            wrGeturl = WebRequest.Create(url);
            Stream objStream;
            objStream = wrGeturl.GetResponse().GetResponseStream();
            var objReader = new StreamReader(objStream);
            var sLine = "";
            string fll;
            fll = objReader.ReadLine();
            sLine = fll.Remove(0, 855);
            sLine = sLine.Remove(sLine.IndexOf("</a>", StringComparison.Ordinal));
            return sLine;
        }

        /// <summary>
        /// Html parser version.
        /// </summary>
        /// <param name="website"></param>
        /// <returns></returns>
        public static async Task<string> distNum(string website)
        {
            var http = new HttpClient();
            var reponse = await http.GetByteArrayAsync(website);
            var source = Encoding.GetEncoding("dist-").GetString(reponse, 0, reponse.Length - 1);
            source = WebUtility.HtmlDecode(source);
            // html.HtmlDocument result = new html.HtmlDocument();
            // result.LoadHtml(source);

            // List<html.HtmlNode> title = result.DocumentNode.Descendants().
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distFile"></param>
        public static void tcUnpack(string distFile = "teamcity.zip")
        {
            using (var buildUnpack = ZipFile.Read(distFile))
            {
                buildUnpack.ExtractAll(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
            }

            File.Delete(distFile);

            WhiteRose.WildUnZip();

            /* using (ZipFile build2Unpack = ZipFile.Read("dist-" + distNum() + ".zip"))
            {
                build2Unpack.ExtractAll(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
            } */
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <param name="distFile"></param>
        public static string tcDistFile(string address = "servo.freeso.org", string buildType = "ProjectDollhouse_TsoClient", string distFile = "teamcity.zip")
        {
            try
            {
                var uri = new Uri(
                    $@"http://{address}/guestAuth/downloadArtifacts.html?buildTypeId={buildType}&buildId=lastSuccessful");
                distFile = Path.GetFileName(uri.LocalPath);
                return distFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <returns></returns>
        public static Uri tcAddress(string address = "servo.freeso.org", string buildType = "ProjectDollhouse_TsoClient")
        {
            try
            {
                return new Uri(
                    $@"http://{address}/guestAuth/downloadArtifacts.html?buildTypeId={buildType}&buildId=lastSuccessful?guest=1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
