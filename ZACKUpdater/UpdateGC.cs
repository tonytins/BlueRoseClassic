using System;
using System.IO;
using System.Linq;

namespace ZACKUpdater
{
    class UpdateGC
    {
        public static void GC()
        {
            var di = new DirectoryInfo(Environment.CurrentDirectory);
            var files = di.GetFiles("*.zip").Where(p => p.Extension == ".zip").ToArray();

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
    }
}
