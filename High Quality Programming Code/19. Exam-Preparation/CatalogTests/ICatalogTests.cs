namespace CatalogTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KPK_Practical_Exam;

    [TestClass]
    public class ICatalogTests
    {
        [TestMethod]
        public void UpdateContentTest()
        {
            ICatalog catalog = new Catalog();

            catalog.Add(new Content(ContentType.Book, new string[]{"Intro c#", "S.Nakov",
                "12763892", "http://www.introprogramming.info"}));
            catalog.Add(new Content(ContentType.Application, new string[]{"Firefox v.11.0", 
                "Mozilla", "16148072", "http://www.mozilla.org"}));
            catalog.Add(new Content(ContentType.Song, new string[]{"One", 
                "Metallica", "8771120", "http://goo.gl/dIkth7gs"}));
            catalog.Add(new Content(ContentType.Movie, new string[]{"The Secret", 
                "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d"}));
            catalog.Add(new Content(ContentType.Movie, new string[]{"One", 
                "James Wong (2001)", "969763002", "http://www.imdb.com/title/tt0267804/"}));

            int updated = catalog.UpdateContent("http://www.introprogramming.info",
                "http://introprograming.info/en/");

            Assert.AreEqual(1, updated);
        }

        [TestMethod]
        public void GetListContetnTest()
        {
            ICatalog catalog = new Catalog();

            catalog.Add(new Content(ContentType.Book, new string[]{"Intro c#", "S.Nakov",
                "12763892", "http://www.introprogramming.info"}));
            catalog.Add(new Content(ContentType.Application, new string[]{"Firefox v.11.0", 
                "Mozilla", "16148072", "http://www.mozilla.org"}));
            catalog.Add(new Content(ContentType.Song, new string[]{"One", 
                "Metallica", "8771120", "http://goo.gl/dIkth7gs"}));
            catalog.Add(new Content(ContentType.Movie, new string[]{"The Secret", 
                "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d"}));
            catalog.Add(new Content(ContentType.Movie, new string[]{"One", 
                "James Wong (2001)", "969763002", "http://www.imdb.com/title/tt0267804/"}));

            var list = catalog.GetListContent("Intro c#", 1).GetEnumerator();
            IContent expected = new Content(ContentType.Book, new string[]{"Intro c#", "S.Nakov",
                "12763892", "http://www.introprogramming.info"});

            list.MoveNext();
            Assert.IsTrue(expected.CompareTo(list.Current) == 0);
        }
    }
}
