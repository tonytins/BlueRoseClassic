// This project is licensed under the GNU GPL-2.0 license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows.Forms;

namespace BlueRose.Classic.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            WhiteRose.fsoParmas = args;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BlueRoseGUI());

        }
    }
}
