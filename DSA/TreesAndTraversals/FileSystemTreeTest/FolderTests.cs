using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using _3.FileSystemTree;
using System.Linq;

namespace FileSystemTreeTest
{
    [TestClass]
    public class FolderTests
    {
        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void TestSystemFolder()
        {
            string currentDirectory = Environment.SystemDirectory;
            DirectoryInfo dir = new DirectoryInfo(currentDirectory);
            dir = dir.Parent;

            Folder root = Folder.CreateFileSystemTree(dir.FullName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWithNoName()
        {
            Folder root = Folder.CreateFileSystemTree("\n");
        }

        [TestMethod]
        public void TestBinFolderSize()
        {
            string currentDirectory = Environment.CurrentDirectory;
            DirectoryInfo dir = new DirectoryInfo(currentDirectory);
            DirectoryInfo parentDirectory = dir.Parent.Parent.Parent;

            Folder root = Folder.CreateFileSystemTree(parentDirectory.FullName);

            Folder folder = root.ChildFolders[4].ChildFolders[0];
            long actualSize = folder.GetSize();
            long expectedSize = dir.Parent.GetFiles("*", SearchOption.AllDirectories).Sum(x => x.Length);
            Assert.AreEqual(expectedSize, actualSize);
        }
    }
}
