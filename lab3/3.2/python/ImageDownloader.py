import json


class ImageDownloader:
    class ImageResponse:
        def __init__(self, msg: str, url: str):
            self.msg = msg
            self.url = url

    def __init__(self, client, file_system):
        self._client = client
        self._file_system = file_system
        self._image_response = None

    async def get_new_file(self, token=None):
        response = await self._client.get("https://www.google.com", token=token)
        if response.status_code == 200:
            stream = await response.content.read()
            self._image_response = json.loads(stream, object_hook=decode_response)
            return self._image_response
        return ImageDownloader.ImageResponse("", "")

    def write_image_to_disk(self, path, input):
        return self._file_system.write_line(path, input) and self._file_system.exists(path)

    def get_last_image_response(self):
        return self._image_response


def decode_response(obj):
    if 'msg' in obj and 'url' in obj:
        return ImageDownloader.ImageResponse(obj['msg'], obj['url'])