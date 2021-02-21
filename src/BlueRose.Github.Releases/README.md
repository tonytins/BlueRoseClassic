# BlueRose Github Downloader

Based on [GitHub Release Downloader](https://github.com/kalilistic/GitHub.ReleaseDownloader),   BlueRose Github Downloader allows you to compare GitHub versions and download latest release assets.

## Background

The original library targeted the .NET Framework. This has been updated to use the .NET Standard.

## Key Features

* Check if current version is most recent using SemVer.
* Download latest release artifacts from GitHub releases.
* Include / exclude pre-releases.
  
## How To Use

```csharp
// create settings object
HttpClient httpClient = new HttpClient();
string author = "kalilistic";
string repo = "github.releasedownloader";
bool includePreRelease = true;
string downloadDirPath = "C:\assets";
IReleaseDownloaderSettings settings = new ReleaseDownloaderSettings(httpClient, author, repo, includePreRelease, downloadDirPath);

// create downloader
IReleaseDownloader downloader = new ReleaseDownloader(settings);

// check version
string currentVersion = "5.0.0";
bool isMostRecentVersion = downloader.IsLatestRelease(currentVersion);

// download latest github release
if (!isMostRecentVersion) {
  downloader.DownloadLatestRelease();
}

// clean up
downloader.DeInit();
httpClient.Dispose();
```

## Considerations
* Versions must be SemVer-compliant or exception will be thrown.
* Will not compare and silently skip over GitHub releases that aren't Semver-compliant.
* GitHub API calls are made anonymously and subject to rate limits.

## How To Contribute

Feel free to open an issue or submit a PR.