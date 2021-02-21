// This project is licensed under the MIT license.
// See the LICENSE file in the project root for more information.
using System.Net.Http;

namespace BlueRose.Github.Releases
{
 public interface IReleaseDownloaderSettings
 {
  HttpClient HTTPClient { get; set; }
  string Author { get; set; }
  string Repository { get; set; }
  bool IncludePreRelease { get; set; }
  string DownloadDirPath { get; set; }
  IReleaseDownloaderSettings Copy();
 }
}
