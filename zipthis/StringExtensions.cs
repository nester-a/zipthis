using System.IO;

namespace zipthis
{
    internal static class StringExtensions
    {
        internal static SourceType IsFileOrDirectory(this string sourcePath)
        {
            if (Directory.Exists(sourcePath))
            {
                return SourceType.Directory;
            }
            else if (File.Exists(sourcePath))
            {
                return SourceType.File;
            }
            else
            {
                return SourceType.Unknown;
            }
        }
    }
}
