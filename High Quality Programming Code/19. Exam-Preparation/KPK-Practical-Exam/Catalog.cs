namespace KPK_Practical_Exam
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> urls;
        private OrderedMultiDictionary<string, IContent> titles;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.titles = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.urls = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.titles.Add(content.Title, content);
            this.urls.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from content in this.titles[title] select content;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            int updatedElements = 0;

            List<IContent> contentToUpdate = this.urls[oldUrl].ToList();

            foreach (var content in contentToUpdate)
            {
                for (int i = 0; i < this.titles[content.Title].Count; i++)
                {
                    this.titles[content.Title].ElementAt(i).URL = newUrl;
                }

                for (int i = 0; i < this.urls[content.URL].Count; i++)
                {
                    this.urls[content.URL].ElementAt(i).URL = newUrl;
                }

                updatedElements++;
            }

            return updatedElements;
        }
    }
}
