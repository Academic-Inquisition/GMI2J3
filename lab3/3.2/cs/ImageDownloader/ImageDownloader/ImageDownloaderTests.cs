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

        [TestMethod]
        public async Task Mocked_GetImage_SaveImage()
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

            ImageDownloader handler = new(httpClient, file_handler.Object);

            // Act
            var http_result = await handler.GetNewFile();
            var io_result = handler.WriteImageToDisk("./temp/images/", http_result.url);

            // Assert
            Assert.AreEqual("This is a photo of a cookie", http_result.msg);
            Assert.AreEqual("https://assets.bonappetit.com/photos/5ca534485e96521ff23b382b/1:1/w_2560%2Cc_limit/chocolate-chip-cookie.jpg", http_result.url);

            Assert.IsTrue(io_result);

        }
    }
}