using System;
using System.IO;
using System.Text.RegularExpressions;

namespace zipthis
{
    class ZipThisArgs
    {
        private const string _ext = ".zip";

        public ZipThisArgs(string[] args)
        {
            if(args.Length > 0)
            {
                var name = Regex.Replace(args[0], @"\?|\*|""|\:|<|\>|\|", "");

                if(!string.IsNullOrWhiteSpace(name))
                {
                    Name = name.EndsWith(_ext) ? name : name + _ext;
                }
            }

            if(args.Length > 1)
            {
                Source = args[1].Equals(Directory.GetCurrentDirectory()) ? Source : args[1];
            }

            if (args.Length > 2)
            {
                Destination = Path.Combine(args[2], Name);
            }
        }

        public string Name { get; set; } = new DirectoryInfo(Environment.CurrentDirectory).Name + _ext;
        public string Source { get; set; } = Environment.CurrentDirectory;
        public string Destination { get; set; } = Path.Combine(Environment.CurrentDirectory);
    }
}
