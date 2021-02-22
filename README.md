# Blue Rose Core

Blue Rose Core is a launcher and updater kit for Github projects.

## Background

Blue Rose, now known as Blue Rose Classic, was originally written as a launcher and later updater for FreeSO in the mid-2010s. It downloaded the game's build artifacts from their using a custom and hacked together TeamCity API. It was based on the .NET Framework and used Windows Forms. Given it's frequent usage at the time, I'd say it's one of my battle tested projects I've ever written. However, a bug in the unzipping process of the 2.x branch forced me to turn the 1.x branch into an LTS release in order to maintain support.

There have been plenty of attempts to rewrite Blue Rose into something more general purpose which is why the original FreeSO version was given the "Classic" title. Though, this mostly involved retrofitted the existing and now aging codebase. Blue Rose Core attempts to address this by targeting .NET 5 and using a modified version of [GitHub Release Downloader](https://github.com/kalilistic/GitHub.ReleaseDownloader), due to the original targeting the .NET Framework, in order to be used as a general purpose launcher kit for Github projects. It'll be used as the foundation for the [Beyond Launcher](https://github.com/tonytins/Beyond) project.

## Requirements

### Prerequisites

* Windows 10 1703+ or 7 SP1
* Visual Studio 2019 16.8+
* .NET 5 SDK
## License

I license this project under the GNU GPL-2.0 license - see the [LICENSE](LICENSE) file for details.