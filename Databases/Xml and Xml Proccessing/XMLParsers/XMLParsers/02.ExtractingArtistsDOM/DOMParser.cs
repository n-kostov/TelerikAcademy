//Write program that extracts all different artists which are found in the 
//catalog.xml. For each author you should print the number of albums in the 
//catalogue. Use the DOM parser and a hash-table.


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtractingArtistsDOM
{
    class DOMParser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;
            Dictionary<string, int> artistDict = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artistName = node["artist"].InnerText;

                if (artistDict.ContainsKey(artistName))
                {
                    artistDict[artistName]++;
                }
                else
                {
                    artistDict.Add(artistName, 1);
                }
            }

            foreach (var item in artistDict)
            {
                Console.WriteLine("Artist Name:{0,-25}Number of Albums {1,10}", 
                    item.Key, item.Value);
            }
        }
    }
}
