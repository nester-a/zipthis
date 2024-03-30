using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace zipthis
{
    internal static class DirectoryInfoExtensions
    {
        internal static void FindAllFiles(this DirectoryInfo dir, List<FileInfo> filesNamesCol)
        {
            var subDirs = dir.GetDirectories();
            if (subDirs.Any())
            {
                foreach (var subDir in subDirs)
                {
                    subDir.FindAllFiles(filesNamesCol);
                }
            }
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                filesNamesCol.Add(file);
            }
        }
    }
}
