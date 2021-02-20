using System;

namespace ZACKUpdater
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
