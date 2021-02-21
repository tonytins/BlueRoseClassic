// This project is licensed under the GNU GPL-2.0 license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows.Forms;

namespace BlueRose.Core.Client
{
    public partial class BlueRoseGUI : Form
    {
        public BlueRoseGUI()
        {
            try
            {
                InitializeComponent();
                var majorMinor = $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}";
                var patchCommit = $"{ThisAssembly.Git.SemVer.Patch}-{ThisAssembly.Git.Commit}";
                Text += $@" {majorMinor}.{patchCommit}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
