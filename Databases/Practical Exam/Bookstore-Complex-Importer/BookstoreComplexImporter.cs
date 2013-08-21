using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Transactions;
using System.Xml;
using Bookstore.Data;

namespace Bookstore_Complex_Importer
{
    public static class BookstoreComplexImporter
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            TransactionOptions transcationScopeOptions =
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.RepeatableRead
                };

            TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, transcationScopeOptions);
            using (tran)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../complex-books.xml");
                string xPathQuery = "/catalog/book";

                XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode bookNode in booksList)
                {
                    List<string> authors = new List<string>();

                    XmlNode authorsNode = bookNode.SelectSingleNode("authors");
                    if (authorsNode != null)
                    {
                        foreach (XmlNode author in authorsNode)
                        {
                            authors.Add(author.InnerText);
                        }
                    }

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

                    List<string> reviewsAuthors = new List<string>();
                    List<DateTime> reviewDates = new List<DateTime>();
                    List<string> reviewTexts = new List<string>();

                    ProccessReviewsNode(bookNode, reviewsAuthors, reviewDates, reviewTexts);

                    BookstoreDAL.AddBookWithAuthorsAndReviews(authors.ToArray(), title, isbn,
                        price, website, reviewsAuthors, reviewDates, reviewTexts);
                }

                tran.Complete();
            }
        }

        private static void ProccessReviewsNode(XmlNode bookNode, List<string> reviewsAuthors, List<DateTime> reviewDates, List<string> reviewTexts)
        {
            XmlNode reviewsNode = bookNode.SelectSingleNode("reviews");
            if (reviewsNode != null)
            {
                foreach (XmlNode review in reviewsNode)
                {
                    var authorValue = review.SelectSingleNode("@author");
                    if (authorValue != null)
                    {
                        reviewsAuthors.Add(authorValue.Value);
                    }
                    else
                    {
                        reviewsAuthors.Add(null);
                    }

                    var dateValue = review.SelectSingleNode("@date");
                    if (dateValue != null)
                    {
                        reviewDates.Add(DateTime.Parse(dateValue.Value));
                    }
                    else
                    {
                        reviewDates.Add(DateTime.Now);
                    }

                    reviewTexts.Add(review.InnerText.Trim());
                }
            }
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
