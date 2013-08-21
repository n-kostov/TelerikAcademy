//Write a program, which using XmlReader extracts all song titles from catalog.xml.

using System;
using System.Xml;

class ExtractSongs
{
    static void Main()
    {
        Console.WriteLine("Songs titles in the catalogue:");
        using (XmlReader reader = XmlReader.Create("../../catalogue.xml"))
        {
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "title"))
                {
                    Console.WriteLine(reader.ReadElementString());
                }
            }
        }
    }
}
