using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2.ExtractExeFiles
{
    class Program
    {
        public static class DirectoryTraverserBFS
        {
            public static void Main()
            {
                string currentDirectory = Environment.CurrentDirectory;
                DirectoryInfo dir = new DirectoryInfo(currentDirectory);
                dir = dir.Parent.Parent.Parent;
                string fileExtension = "*.exe";
                string[] files = Directory.GetFiles(dir.FullName, fileExtension, SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
        }
    }
}
