﻿//Write a program, which extract from the file catalog.xml the prices
//for all albums, published 5 years ago or earlier. Use XPath query.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtractPriceAlbums
{
    class ExtractPrice
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../catalogue.xml");

            string xPathQuery = "/catalogue/album[year<2008]";
            XmlNodeList priceList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode priceNode in priceList)
            {
                string albumName = priceNode.SelectSingleNode("name").InnerText;
                string price = priceNode.SelectSingleNode("price").InnerText;
                Console.WriteLine("Price of {0}-> {1}.00 USD", albumName, price);
            }
        }
    }
}