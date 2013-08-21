using System.Globalization;
using System.Threading;
using System.Transactions;
using System.Xml;
using Bookstore.Data;

namespace Bookstore_Simple_Importer
{
    public static class BooksSimpleImporter
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            //TransactionScope tran = new TransactionScope(
            //TransactionScopeOption.Required,
            //    new TransactionOptions()
            //    {
            //        IsolationLevel = IsolationLevel.RepeatableRead
            //    });
            //using (tran)
            //{
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../simple-books.xml");
                string xPathQuery = "/catalog/book";

                XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode bookNode in booksList)
                {
                    string author = bookNode.GetChildText("author");
                    string title = bookNode.GetChildText("title");
                    string priceValue = bookNode.GetChildText("price");
                    decimal? price;
                    if (priceValue == null)
                    {
                        price = null;
                    }
                    else
                    {
                        price = decimal.Parse(priceValue);
                    }

                    string isbn = bookNode.GetChildText("isbn");
                    string website = bookNode.GetChildText("web-site");

                    BookstoreDAL.AddBook(author, title, isbn, price, website);
                }

            //    tran.Complete();
            //}
        }

        private static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }

            return childNode.InnerText.Trim();
        }
    }
}
