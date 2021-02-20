// Copyright(C) 2016  Blue Rose Project

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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Ionic.Zip;

namespace BlueRose
{
    public class WhiteRose
    {

        public static string[] fsoParmas { get; set; }

        public static string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// Returns all files by their extensions within the current directory.
        /// You only need to type in the name of the extension.
        /// </summary>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public static FileInfo[] FileWildCard(string fileExt)
        {
            var dir = new DirectoryInfo(Environment.CurrentDirectory);
            var files = dir.GetFiles($"*.{fileExt.ToLower()}").Where(p => p.Extension == $".{fileExt.ToLower()}").ToArray();
            return files;
        }

        /// <summary>
        /// Returns all files by their extensions in the selected directory.
        /// </summary>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public static FileInfo[] FileWildCard(string fileExt, string fileDir)
        {
            var dir = new DirectoryInfo(fileDir);
            var files = dir.GetFiles($"*.{fileExt.ToLower()}").Where(p => p.Extension == $".{fileExt.ToLower()}").ToArray();
            return files;
        }

        /// <summary>
        /// Returns a given URL. If it isn't there,
        /// default to Google.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>new Uri(url);</returns>
        public static Uri WebPage(string url)
        {
            try
            {
                return new Uri(url);
            }
            catch
            {
                return new Uri("https://google.com");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>new Uri(url);</returns>
        public static Uri WebURI(string url)
        {
            try
            {
                return new Uri(url);
            }
            catch
            {
                return new Uri(null);
            }
        }

        /// <summary>
        /// If FreeSO isn't found, alert the user.
        /// If OpenAL isn't installed, show downloads address.
        /// </summary>
        /// <param name="fso"></param>
        public static void StartFSO(string fso)
        {

            try
            {
                var fsoProcess = new Process
                {
                    StartInfo =
                    {
                        FileName = fso,
                        UseShellExecute = true,
                        Arguments = ConvertStringArrayToString(fsoParmas)
                    }
                };

                fsoProcess.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, fso);
            }
        }

        public static void StartFSO(string fso, string args)
        {

            try
            {
                var fsoProcess = new Process
                {
                    StartInfo =
                {
                    FileName = fso,
                    UseShellExecute = true,
                    Arguments = args
                }
                };

                fsoProcess.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, fso);
            }
        }

        /// <summary>
        /// Return the latest dist number as a string
        /// Thanks to LRB. http://forum.freeso.org/threads/974/
        /// </summary>
        /// <returns>sLine</returns>
        public static string DistNumLegacy()
        {
            try
            {
                const string url = "http://servo.freeso.org/externalStatus.html?js=1";
                var wrGeturl = WebRequest.Create(url);
                var objStream = wrGeturl.GetResponse().GetResponseStream();
                var objReader = new StreamReader(objStream);
                var sLine = "";
                var fll = objReader.ReadLine();
                sLine = fll.Remove(0, 855);
                sLine = sLine.Remove(sLine.IndexOf("</a>", StringComparison.Ordinal));
                return sLine;
            }
            catch
            {
                return "NONE";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ReadBuild(string file)
        {
            try
            {
                var buildFile = $@"{Environment.CurrentDirectory}/{file}";
                var fileRead = new StreamReader(buildFile);
                string line;
                while ((line = fileRead.ReadLine()) != null)
                {
                    return $"#{line}";
                }

                fileRead.Close();
            }
            catch
            {
                return "NONE";
            }

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public static void WriteBuild(string file)
        {
            var buildFile = $@"{Environment.CurrentDirectory}/{file}";
            var localDist = DistNumLegacy();

            try
            {
                File.WriteAllText(buildFile, localDist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cleans up any ZIP files.
        /// Uses Code Project's Wildcard class.
        /// </summary>
        public static void ZipGcCompat()
        {

            var wildZip = new Wildcard("*.zip", RegexOptions.IgnoreCase);
            var files = Directory.GetFiles(Environment.CurrentDirectory);

            foreach (var file in files)
            {
                if (wildZip.IsMatch(file))
                    File.Delete(file);
            }
        }

        /// <summary>
        /// Cleans up any ZIP files.
        /// </summary>
        public static void ZipGC()
        {
            var files = FileWildCard("zip");

            foreach (var file in files)
            {
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Detects for any present zips and unpacks them.
        /// Uses Code Project's Wildcard class.
        /// </summary>
        public static void WildUnZipCompat()
        {
            var unpacker = new Wildcard("*.zip", RegexOptions.IgnoreCase);

            // Get a list of files in the My Documents folder
            var files = Directory.GetFiles(Environment.CurrentDirectory);

            foreach (var file in files)
            {
                if (!unpacker.IsMatch(file))
                    continue;
                using (var zip2 = ZipFile.Read(file))
                {
                    foreach (var ex in zip2)
                    {
                        ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
        }

        /// <summary>
        /// Detects for any present zips and unpacks them.
        /// </summary>
        public static void WildUnZip()
        {
            var dir = new DirectoryInfo(Environment.CurrentDirectory);
            var files = dir.GetFiles("*.zip").Where(p => p.Extension == ".zip").ToArray();

            foreach (var file in files)
            {
                using (var zip2 = ZipFile.Read(file.FullName))
                {
                    foreach (var ex in zip2)
                    {
                        ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ConvertStringArrayToString(IEnumerable<string> array)
        {
            //
            // Concatenate all the elements into a StringBuilder.
            //
            var builder = new StringBuilder();
            foreach (var value in array)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            return builder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ConvertStringArrayToStringJoin(IEnumerable<string> array)
        {
            //
            // Use string Join to concatenate the string elements.
            //
            var result = string.Join(".", array);
            return result;
        }


        public static void distUnZip(string dist)
        {
            using (var zip2 = ZipFile.Read(dist))
            {
                foreach (var ex in zip2)
                {
                    ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

    }
}
