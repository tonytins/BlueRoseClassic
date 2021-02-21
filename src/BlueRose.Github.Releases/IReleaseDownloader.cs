// This project is licensed under the MIT license.
// See the LICENSE file in the project root for more information.
namespace BlueRose.Github.Releases
{
    public interface IReleaseDownloader
    {
        bool IsLatestRelease(string version);
        bool DownloadLatestRelease();
        void DeInit();
    }
}
