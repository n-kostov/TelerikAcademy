using System;
using System.Collections.Generic;
using System.IO;

namespace _3.FileSystemTree
{
    public class Folder
    {
        private string name;
        private File[] files;
        private Folder[] childFolders;

        public Folder(string name, File[] files, Folder[] childFolders)
        {
            this.name = name;
            this.files = files;
            this.childFolders = childFolders;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The folder's name cannot be null or whitespace!", "name");
                }

                this.name = value;
            }
        }

        public File[] Files
        {
            get
            {
                return this.files;
            }

            private set
            {
                if (value != null)
                {
                    this.files = value;
                }
            }
        }

        public Folder[] ChildFolders
        {
            get
            {
                return this.childFolders;
            }

            private set
            {
                if (value != null)
                {
                    this.childFolders = value;
                }
            }
        }

        public static Folder CreateFileSystemTree(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path", "The path to this directory cannot be null or whitespace!");
            }

            DirectoryInfo directory = new DirectoryInfo(path);
            Folder root = CreateFolder(directory);
            return root;
        }

        private static Folder CreateFolder(DirectoryInfo dir)
        {
            List<Folder> currentFolderSubFolders = new List<Folder>();

            foreach (var folder in dir.GetDirectories())
            {
                Folder current = CreateFolder(folder);
                currentFolderSubFolders.Add(current);
            }

            FileInfo[] currentDirectoryFiles = dir.GetFiles();
            File[] currentFolderFiles = new File[currentDirectoryFiles.Length];
            for (int i = 0; i < currentFolderFiles.Length; i++)
            {
                currentFolderFiles[i] = new File(currentDirectoryFiles[i].Name, currentDirectoryFiles[i].Length);
            }

            Folder root = new Folder(dir.Name, currentFolderFiles, currentFolderSubFolders.ToArray());
            return root;
        }

        public long GetSize()
        {
            long size = 0;
            for (int i = 0; i < this.ChildFolders.Length; i++)
            {
                size += this.childFolders[i].GetSize();
            }

            long currentFolderFilesSize = 0;
            for (int i = 0; i < this.Files.Length; i++)
            {
                currentFolderFilesSize += this.Files[i].Size;
            }

            return size + currentFolderFilesSize;
        }
    }
}
