// This project is licensed under the MIT license.
// See the LICENSE file in the project root for more information.
using System;
using System.IO;
using System.Net.Http;
using NUnit.Framework;

namespace BlueRose.Github.Releases.Tests
{
    [TestFixture]
    public class ReleaseDownloaderTest
    {
        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient(new HttpMessageHandlerMock());
            _downloadDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "assets");
        }

        [TearDown]
        public void TearDown()
        {
            _httpClient.Dispose();
            _downloader.DeInit();
        }

        private const string Author = "sixam";
        private const string Repo = "isow";
        private HttpClient _httpClient;
        private string _downloadDirPath;
        private IReleaseDownloader _downloader;

        [Test]
        public void DeInit_RemovesAgentHeader()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, Repo, true, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            _downloader.DeInit();
            Assert.IsEmpty(_httpClient.DefaultRequestHeaders.UserAgent);
        }

        [Test]
        [Ignore("Integration Test using real GitHub API")]
        public void DownloadLatestRelease_IT_ReturnsTrue()
        {
            var httpClient = new HttpClient();
            var settings = new ReleaseDownloaderSettings(httpClient, Author, Repo, true, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.IsTrue(_downloader.DownloadLatestRelease());
            httpClient.Dispose();
        }

        [Test]
        public void DownloadLatestRelease_ReturnsTrue()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, Repo, true, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Directory.CreateDirectory(_downloadDirPath);
            _downloader.DownloadLatestRelease();
        }

        [Test]
        public void IsLatestRelease_BadRepo_ThrowsException()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, "BAD-REPO", true, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.Throws<AggregateException>(() => _downloader.IsLatestRelease("5.0.0"));
        }

        [Test]
        public void IsLatestRelease_BadVersion_ThrowsException()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, Repo, true, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.Throws<Exception>(() => _downloader.IsLatestRelease("bad-version"));
        }

        [Test]
        public void IsLatestRelease_IsLatestNoPR_ReturnsTrue()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, Repo, false, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.IsTrue(_downloader.IsLatestRelease("6.0.30"));
        }

        [Test]
        public void IsLatestRelease_IsLatestPR_ReturnsTrue()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, Repo, true, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.IsTrue(_downloader.IsLatestRelease("6.0.53"));
        }

        [Test]
        public void IsLatestRelease_IsNotLatestNoPR_ReturnsFalse()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, Repo, false, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.IsFalse(_downloader.IsLatestRelease("6.0.29"));
        }

        [Test]
        public void IsLatestRelease_IsNotLatestPR_ReturnsFalse()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, Repo, true, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.IsFalse(_downloader.IsLatestRelease("5.0.0"));
        }

        [Test]
        [Ignore("Integration Test using real GitHub API")]
        public void IsLatestRelease_IT_ReturnsTrue()
        {
            var httpClient = new HttpClient();
            var settings = new ReleaseDownloaderSettings(httpClient, Author, Repo, false, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.IsTrue(_downloader.IsLatestRelease("6.0.30"));
            httpClient.Dispose();
        }

        [Test]
        public void IsLatestRelease_OtherAPIError_ThrowsException()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, "OTHER-ERROR", true, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.Throws<AggregateException>(() => _downloader.IsLatestRelease("5.0.0"));
        }

        [Test]
        public void IsLatestRelease_RateLimit_ThrowsException()
        {
            var settings = new ReleaseDownloaderSettings(_httpClient, Author, "RATE-LIMITED", true, _downloadDirPath);
            _downloader = new ReleaseDownloader(settings);
            Assert.Throws<AggregateException>(() => _downloader.IsLatestRelease("5.0.0"));
        }
    }
}
