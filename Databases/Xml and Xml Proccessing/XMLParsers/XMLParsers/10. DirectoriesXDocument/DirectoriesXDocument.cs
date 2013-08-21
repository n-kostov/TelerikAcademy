//Rewrite the last exercises using XDocument, XElement and XAttribute.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

class TraverseDirectories
{
    static void Main()
    {
        string folderLocation = "../../";
        DirectoryInfo dir = new DirectoryInfo(folderLocation);
        var doc = new XDocument(CreateXML(dir));

        Console.WriteLine(doc.ToString());
    }
    private static XElement CreateXML(DirectoryInfo dir)
    {
        var xmlInfo = new XElement("MyDirectories");
       
        //get all the files first
        foreach (var file in dir.GetFiles())
        {
            xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
        }

        //get subdirectories
        var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);

        foreach (var subDir in subdirectories)
        {
            xmlInfo.Add(CreateSubdirectoryXML(subDir));
        }

        return xmlInfo;
    }

    private static XElement CreateSubdirectoryXML(DirectoryInfo dir)
    {
        //get directories
        var xmlInfo = new XElement("dir", new XAttribute("name", dir.Name));

        //get all the files first
        foreach (var file in dir.GetFiles())
        {
            xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
        }

        //get subdirectories
        var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);
        foreach (var subDir in subdirectories)
        {
            xmlInfo.Add(CreateSubdirectoryXML(subDir));
        }

        return xmlInfo;
    }
}