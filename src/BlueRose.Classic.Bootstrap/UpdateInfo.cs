// This project is licensed under the GNU GPL-2.0 license.
// See the LICENSE file in the project root for more information.
using System;

namespace BlueRose.Classic.Bootstrap
{
    public class UpdateInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="processInfo"></param>
        /// <param name="address"></param>
        /// <param name="compressedFile"></param>
        public static void SelfUpdate(string processInfo, Uri address, string compressedFile)
        {
            var install = new SelfUpdate();
            install.Install(address, compressedFile, processInfo);
        }

        public static void ClientUpdate()
        {

        }
    }
}
