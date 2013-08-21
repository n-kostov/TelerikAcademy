using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using Bookstore.Data;
using Logs.Data;

namespace Bookstore_Reviews_Search
{
    public static class BookstoreReviewsSearcher
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            using (var context = new LogsDB())
            {
                context.Database.CreateIfNotExists();
            }

            string fileName = "../../reviews-search-results.xml";
            using (XmlTextWriter writer =
                new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                ProcessSearchQueries(writer);

                writer.WriteEndDocument();
            }
        }

        private static void ProcessSearchQueries(XmlTextWriter writer)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../reviews-queries.xml");
            foreach (XmlNode query in xmlDoc.SelectNodes("/review-queries/query"))
            {
                // 7
                using (var context = new LogsDB())
                {
                    SearchLog searchLog = new SearchLog();
                    searchLog.Date = DateTime.Now;
                    searchLog.QueryXml = query.OuterXml;
                    context.SearchLogs.Add(searchLog);
                    context.SaveChanges();
                }

                // 6
                IList<Review> reviews = new List<Review>();
                string type = query.SelectSingleNode("@type").Value;
                if (type == "by-period")
                {
                    DateTime startDate = DateTime.Parse(query.GetChildText("start-date"));
                    DateTime endDate = DateTime.Parse(query.GetChildText("end-date"));
                    reviews = BookstoreDAL.FindReviewsByPeriod(startDate, endDate);
                }
                else
                {
                    string author = query.GetChildText("author-name");
                    reviews = BookstoreDAL.FindReviewsByAuthor(author);
                }

                WriteReviews(writer, reviews);
            }
        }

        private static void WriteReviews(
            XmlTextWriter writer, IList<Review> reviews)
        {
            writer.WriteStartElement("result-set");
            foreach (var review in reviews)
            {
                writer.WriteStartElement("review");
                if (review.DateOfCreation != null)
                {
                    writer.WriteElementString("date", review.DateOfCreation.ToString("dd-MMM-yyyy"));
                }

                if (review.ReviewText != null)
                {
                    writer.WriteStartElement("content");
                    writer.WriteValue(review.ReviewText.Replace("/", "/"));
                    //writer.WriteString(review.ReviewText);
                    writer.WriteEndElement();
                    //writer.WriteElementString("content", review.ReviewText);
                }

                if (review.Book != null)
                {
                    writer.WriteStartElement("book");
                    if (review.Book.Title != null)
                    {
                        writer.WriteElementString("title", review.Book.Title);
                        
                    }

                    if (review.Book.Authors != null && review.Book.Authors.Count > 0)
                    {
                        writer.WriteElementString("authors",
                            string.Join(", ", review.Book.Authors.Select(x => x.Name).OrderBy(x => x)));
                    }

                    if (review.Book.ISBN != null)
                    {
                        writer.WriteElementString("isbn", review.Book.ISBN);
                    }

                    if (review.Book.Website != null)
                    {
                        writer.WriteStartElement("url");
                        writer.WriteString(review.Book.Website);
                        writer.WriteEndElement();
                        //writer.WriteElementString("url", review.Book.Website);
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
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
