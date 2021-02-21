// This project is licensed under the GNU GPL-2.0 license.
// See the LICENSE file in the project root for more information.
using System;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BlueRose.Classic.Bootstrap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            UpdateWindow.UpdateParmas = args;
            /*
            Ping pinger = new Ping();
            bool pingable = false;
            PingReply reply = pinger.Send(@"https://www.google.com");
            if (pingable = reply.Status == IPStatus.Success)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new UpdateWindow());
            }
            else if (pingable = reply.Status == IPStatus.DestinationNetworkUnreachable)
            {
                ProcessStartInfo launcherProcess = new ProcessStartInfo();
                launcherProcess.FileName = "BlueRoseLauncher.exe";
                launcherProcess.UseShellExecute = true;
                Process.Start(launcherProcess);
                Environment.Exit(0);
            }
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UpdateWindow());

        }

        public static bool isOnline()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(@"https://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static string ConvertStringArrayToString(string[] array)
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

        public static string ConvertStringArrayToStringJoin(string[] array)
        {
            //
            // Use string Join to concatenate the string elements.
            //
            var result = string.Join(".", array);
            return result;
        }
    }
}
