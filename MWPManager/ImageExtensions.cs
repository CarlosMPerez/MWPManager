using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace MWPManager
{
    public static class ImageExtensions
    {
        private static HashSet<string> extensions;
        
        static ImageExtensions()
        {
            extensions = new HashSet<string>();
            extensions.Add(".jpg");
            extensions.Add(".tiff");
            extensions.Add(".jpeg");
            extensions.Add(".bmp");
            extensions.Add(".gif");
            extensions.Add(".png");
        }

        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir)
        {
            var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);
            return dir.EnumerateFiles().Where(f => allowedExtensions.Contains(f.Extension));
        }
    }
}
