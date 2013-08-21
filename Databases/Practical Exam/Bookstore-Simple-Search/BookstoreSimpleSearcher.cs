using System;
using System.Globalization;
using System.Threading;
using System.Xml;
using Bookstore.Data;

namespace Bookstore_Simple_Search
{
    public static class BookstoreSimpleSearcher
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");
            string title = xmlDoc.GetChildText("/query/title");
            string author = xmlDoc.GetChildText("/query/author");
            string isbn = xmlDoc.GetChildText("query/isbn");
            var books =
                BookstoreDAL.FindBooksByTitleAuthorAndIsbn(
                    title, author, isbn);
            if (books.Count > 0)
            {
                Console.WriteLine("{0} books found:", books.Count);
                foreach (var book in books)
                {
                    Console.WriteLine("{0} --> {1}", book.Title, book.Reviews.Count);
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
            }
        }

        private static string GetChildText(
            this XmlNode node, string xpath)
        {
            XmlNode childNode = node.SelectSingleNode(xpath);
            if (childNode == null)
            {
                return null;
            }

            return childNode.InnerText.Trim();
        }
    }
}
