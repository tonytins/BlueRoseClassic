using System;
using System.IO;
using Nett;

namespace BlueRose.Core.Bootstrap
{
    class BootstrapSettings
    {
        public bool Preview { get; } = false;

        public static BootstrapSettings GetSettings
        {
            get
            {
                var tomlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bluerose.toml");
                var settings = new BootstrapSettings();

                return File.Exists(tomlPath) ? Toml.ReadFile<BootstrapSettings>(tomlPath) : settings;
            }
        }
    }
}
