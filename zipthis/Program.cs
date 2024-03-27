using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace zipthis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appArgs = new ZipThisArgs(args);

            var files = new List<FileInfo>();
            var sourceInfo = new DirectoryInfo(appArgs.Source);

            FindAllFilesInDirectory(sourceInfo, files);

            var zipPath = Path.Combine(appArgs.Destination, appArgs.Name);

            using (var zipFile = new FileStream(zipPath, FileMode.Create))
            {
                using (var archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                {
                    foreach (var file in files)
                    {
                        archive.CreateEntryFromFile(file.FullName, file.Name);
                    }
                }
            }
        }

        static void FindAllFilesInDirectory(DirectoryInfo dir, List<FileInfo> filesNamesCol)
        {
            var subDirs = dir.GetDirectories();
            if (subDirs.Any())
            {
                foreach (var subDir in subDirs)
                {
                    FindAllFilesInDirectory(subDir, filesNamesCol);
                }
            }
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                filesNamesCol.Add(file);
            }
        }
    }
    class ZipThisArgs
    {
        private const string _ext = ".zip";

        public ZipThisArgs(string[] args)
        {
            if(args.Length > 0)
            {
                Name = args[0].EndsWith(_ext) ? args[0] : args[0] + _ext;
            }

            if(args.Length > 1)
            {
                Source = args[1];
            }

            if (args.Length > 2)
            {
                Destination = Path.Combine(args[2], Name);
            }
        }

        public string Name { get; set; } = new DirectoryInfo(Environment.CurrentDirectory).Name + _ext;

        //TODO: delete test path
        public string Source { get; set; } = Path.Combine(Environment.CurrentDirectory, "test");
        public string Destination { get; set; } = Path.Combine(Environment.CurrentDirectory);
    }
}
