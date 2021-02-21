// This project is licensed under the MIT license.
// See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BlueRose.Github.Releases.Tests
{
    public class HttpMessageHandlerMock : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var isRateLimited = request.RequestUri.ToString().ToUpper().Contains("RATE-LIMITED");
            var isBadRepoName = request.RequestUri.ToString().ToUpper().Contains("BAD-REPO");
            var isOtherError = request.RequestUri.ToString().ToUpper().Contains("OTHER-ERROR");
            var isPageRequest = request.RequestUri.Query.ToUpper().Contains("PAGE");
            var isReleasesRequest = request.RequestUri.ToString().ToUpper().EndsWith("RELEASES");
            var isAssetUrlsRequest = request.RequestUri.ToString().ToUpper().EndsWith("ASSETS");
            var responseMessage = new HttpResponseMessage();
            string response;
            string headers;
            HttpStatusCode status;

            if (isRateLimited)
            {
                status = HttpStatusCode.Forbidden;
                headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "rate_limit_headers_403.txt"), cancellationToken);
                response = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "rate_limit_response_403.txt"), cancellationToken);
            }
            else if (isBadRepoName)
            {
                status = HttpStatusCode.NotFound;
                headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "repo_not_found_headers_404.txt"), cancellationToken);
                response = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "repo_not_found_response_404.txt"), cancellationToken);
            }
            else if (isOtherError)
            {
                status = HttpStatusCode.GatewayTimeout;
                headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "repo_not_found_headers_404.txt"), cancellationToken);
                response = "GitHub API is broken.";
            }
            else if (isReleasesRequest || isPageRequest)
            {
                status = HttpStatusCode.OK;
                var pageNumber = isPageRequest
                    ? Convert.ToInt32(request.RequestUri.Query.Split('=').Last())
                    : 1;

                switch (pageNumber)
                {
                    case 1:
                        headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page1_headers_200.txt"), cancellationToken);
                        response = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page1_response_200.txt"), cancellationToken);
                        break;
                    case 2:
                        headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page2_headers_200.txt"), cancellationToken);
                        response = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page2_response_200.txt"), cancellationToken);
                        break;
                    case 3:
                        headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page3_headers_200.txt"), cancellationToken);
                        response = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page3_response_200.txt"), cancellationToken);
                        break;
                    case 4:
                        headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page4_headers_200.txt"), cancellationToken);
                        response = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page4_response_200.txt"), cancellationToken);
                        break;
                    case 5:
                        headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page5_headers_200.txt"), cancellationToken);
                        response = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "page5_response_200.txt"), cancellationToken);
                        break;
                    default:
                        throw new Exception("Bad page number.");
                }
            }
            else if (isAssetUrlsRequest)
            {
                status = HttpStatusCode.OK;
                headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "assets_headers_200.txt"), cancellationToken);
                response = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "assets_response_200.txt"), cancellationToken);
            }
            else
            {
                status = HttpStatusCode.OK;
                headers = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory, "stubs", "assets_headers_200.txt"), cancellationToken);
                response = "This is a sample downloaded file";
            }

            responseMessage.StatusCode = status;
            responseMessage.Content = new StringContent(response);
            AddHeaders(responseMessage, headers);

            return await Task.FromResult(responseMessage);
        }

        static void AddHeaders(HttpResponseMessage responseMessage, string headersString)
        {
            var headerLines = headersString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var headerLine in headerLines)
            {
                var header = headerLine.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                responseMessage.Headers.Add(header[0], new List<string> { header[1] });
            }
        }
    }
}
