using System;
using System.Collections.Generic;
using System.IO;

namespace _3.FileSystemTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string currentDirectory = Environment.CurrentDirectory;
            DirectoryInfo dir = new DirectoryInfo(currentDirectory);
            dir = dir.Parent.Parent.Parent;

            Folder root = Folder.CreateFileSystemTree(dir.FullName);

            Folder folder = root.ChildFolders[0].ChildFolders[0];
            long size = folder.GetSize();
            Console.WriteLine("Directory {0} has {1} bytes size.", folder.Name, folder.GetSize());
        }
    }
}
