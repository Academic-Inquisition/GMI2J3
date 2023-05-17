import unittest
from unittest.mock import AsyncMock, MagicMock
from ImageDownloader import ImageDownloader


class TestImageDownloader(unittest.IsolatedAsyncioTestCase):
    async def test_get_new_file(self):
        # Mock HttpClient and IFileSystemHandler
        mock_client = AsyncMock()
        mock_client.get.return_value.status_code = 200
        mock_client.get.return_value.content.read.return_value = b'{"msg": "This is a photo of a cookie", "url": "https://assets.bonappetit.com/photos/5ca534485e96521ff23b382b/1:1/w_2560%2Cc_limit/chocolate-chip-cookie.jpg"}'

        mock_file_system = MagicMock()
        mock_file_system.write_line.return_value = True
        mock_file_system.exists.return_value = True

        # Create ImageDownloader instance with mocked dependencies
        downloader = ImageDownloader(mock_client, mock_file_system)

        # Call the method being tested
        response = await downloader.get_new_file()
        written = downloader.write_image_to_disk("./temp/images/", response.url)

        # Verify that the method returned an ImageResponse object with the expected values
        self.assertEqual(response.msg, "This is a photo of a cookie")
        self.assertEqual(response.url, "https://assets.bonappetit.com/photos/5ca534485e96521ff23b382b/1:1/w_2560%2Cc_limit/chocolate-chip-cookie.jpg")

        # Verify that the mock client was called with the expected URL and arguments
        mock_client.get.assert_called_once_with("https://www.google.com", token=None)

        # Verify that the mock file system was called with the expected arguments
        self.assertTrue(written)
        mock_file_system.write_line.assert_called_once_with("./temp/images/", response.url)
        mock_file_system.exists.assert_called_once_with("./temp/images/")