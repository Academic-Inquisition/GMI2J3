using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader
{
    public interface IFileSystemHandler
    {
        bool Exists(string path);
        bool WriteLine(string path, string cnt);
    }
}
