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
            var needHelp = new string[]
            {
                "?",
                "how",
                "help"
            };

            if(args.Length > 0 && needHelp.Any(prompt => prompt.Equals(args[0], StringComparison.CurrentCultureIgnoreCase)))
            {
                ShowHelp();
                return;
            }

            var appArgs = new ZipThisArgs(args);

            if (appArgs.Source.Equals(Directory.GetCurrentDirectory()))
            {
                Console.WriteLine($"Cant zip 'zipthis' source directory!");
                return;
            }

            Console.WriteLine($"Start zipping {appArgs.Source} ...");

            var files = new List<FileInfo>();

            var sourceType = appArgs.Source.IsFileOrDirectory();

            switch (sourceType)
            {
                case SourceType.File:
                    var fileInfo = new FileInfo(appArgs.Source);
                    files.Add(fileInfo);
                    break;
                case SourceType.Directory:
                    var sourceDir = new DirectoryInfo(appArgs.Source);
                    sourceDir.FindAllFiles(files);
                    break;
                default:
                    Console.WriteLine("File or Directory on source path is not exists");
                    return;
            }

            Console.WriteLine($"Files count: {files.Count}");

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
            Console.WriteLine($"Zipping finished. The archive is available at {appArgs.Destination}");
        }

        static void ShowHelp()
        {
            var help = new string[]
            {
                "HOW TO USE 'ZIPTHIS':",
                @"?> zipthis {zip archive name} {zip archive source} {zip archive destination}",
                "WHERE:",
                "{zip archive name} - is final archive name. Default value is source directory name;",
                "{zip archive source} - is the source directory to be archived. Default value is 'zipthis' execution directory;",
                "{zip archive destination} - is directory where the archive will be created. Default value is 'zipthis' execution directory.",
            };

            foreach (var item in help)
            {
                Console.WriteLine(item);
            }
        }
    }
}
