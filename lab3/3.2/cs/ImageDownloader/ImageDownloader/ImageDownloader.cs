using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageDownloader
{
    internal class ImageDownloader
    {

        private readonly HttpClient _client;
        private readonly IFileSystemHandler _fileSystem;

        private ImageResponse _imageResponse;

        public ImageDownloader(HttpClient client, IFileSystemHandler fileSystem)
        {
            _client = client;
            _fileSystem = fileSystem;
        }

        public async Task<ImageResponse> GetNewFile(CancellationToken token = default)
        {
            var response = await _client.GetAsync("https://www.google.com", token);
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStringAsync(token);
                _imageResponse = JsonSerializer.Deserialize<ImageResponse>(stream);
                return _imageResponse;
            }
            return JsonSerializer.Deserialize<ImageResponse>("");
        }

        public bool WriteImageToDisk(string path, string input)
        {
            return _fileSystem.WriteLine(path, input) && _fileSystem.Exists(path);
        }

        public ImageResponse GetLastImageResponse()
        {
            return _imageResponse;
        }

        public class ImageResponse
        {
            public string msg { get; set; }
            public string url { get; set; }

            public ImageResponse(string msg, string url)
            {
                this.msg = msg;
                this.url = url;
            }
        }

    }
}
