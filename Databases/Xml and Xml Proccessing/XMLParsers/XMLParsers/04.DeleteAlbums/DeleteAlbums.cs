//Using the DOM parser write a program to delete from catalog.xml 
//all albums having price > 20.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DeleteAlbums
{
    class DeletAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalogue.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                if (decimal.Parse(node["price"].InnerText) > 20)
                {
                    XmlNode parent = node.ParentNode;
                    parent.RemoveChild(node);
                }
            }

            Console.WriteLine("Modified XML document:");
            Console.WriteLine(doc.OuterXml);

            doc.Save("../../catalogueNEW.xml");
        }
    }
}
