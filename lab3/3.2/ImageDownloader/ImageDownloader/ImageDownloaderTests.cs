using Moq.Protected;
using System.IO;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ImageDownloader
{
    [TestClass]
    public class ImageDownloaderTests
    {

        private class ImageDownloaderMock
        {
            private readonly HttpClient _client;

            public ImageDownloaderMock(HttpClient client) 
            {
                _client = client;
            }

            public async Task<ImageResponse> GetNewFile(CancellationToken token = default)
            {
                var response = await _client.GetAsync("https://www.google.com", token);
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStringAsync(token);
                    return JsonSerializer.Deserialize<ImageResponse>(stream);
                }
                return JsonSerializer.Deserialize<ImageResponse>("");
            }
        }

        private class SystemImageHandlerMock
        {
            private readonly IFileSystemHandler _fileSystem;

            public SystemImageHandlerMock(IFileSystemHandler fileSystem)
            {
                _fileSystem = fileSystem;
            }

            public bool WriteImageToDisk(string path, string input)
            {
                
                return _fileSystem.WriteLine(path, input) && _fileSystem.Exists(path);
            }
        }

        private class ImageResponse
        {
            public string msg { get; set; }
            public string url { get; set; }

            public ImageResponse(string msg, string url)
            {
                this.msg = msg;
                this.url = url;
            }
        }

        public interface IFileSystemHandler
        {
            bool Exists(string path);
            bool WriteLine(string path, string cnt);
        }

        [TestMethod]
        public async Task GivenMockedHandler_WhenRunningMain_ThenHandlerResponds()
        {
            // Arrange
            var http_handler = new Mock<HttpMessageHandler>();
            var file_handler = new Mock<IFileSystemHandler>();

            HttpResponseMessage response = new()
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(new
                {
                    msg = "This is a photo of a cookie",
                    url = "https://assets.bonappetit.com/photos/5ca534485e96521ff23b382b/1:1/w_2560%2Cc_limit/chocolate-chip-cookie.jpg"
                })
            };

            http_handler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(response);
            file_handler.Setup<bool>(x => x.WriteLine(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            file_handler.Setup<bool>(x => x.Exists(It.IsAny<string>())).Returns(true);


            HttpClient httpClient = new(http_handler.Object)
            {
                BaseAddress = new System.Uri("http://localhost")
            };

            ImageDownloaderMock downloader = new(httpClient);
            SystemImageHandlerMock handler = new(file_handler.Object);

            // Act
            var http_result = await downloader.GetNewFile();
            var io_result = handler.WriteImageToDisk("./temp/images/", http_result.url);

            // Assert
            Assert.AreEqual("This is a photo of a cookie", http_result.msg);
            Assert.AreEqual("https://assets.bonappetit.com/photos/5ca534485e96521ff23b382b/1:1/w_2560%2Cc_limit/chocolate-chip-cookie.jpg", http_result.url);

            Assert.IsTrue(io_result);

        }
    }
}