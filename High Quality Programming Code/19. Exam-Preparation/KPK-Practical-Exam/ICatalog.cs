namespace KPK_Practical_Exam
{
    using System.Collections.Generic;

    public interface ICatalog
    {
        /// <summary>
        /// Adds <paramref name="content"/> to the catalog
        /// </summary>
        /// <param name="content"></param>
        void Add(IContent content);

        /// <summary>
        /// Returns collection with all items that have title <paramref name="title"/>
        /// but no more than <paramref name="numberOfContentElementsToList"/> items
        /// </summary>
        /// <param name="title"></param>
        /// <param name="numberOfContentElementsToList"></param>
        /// <returns>Collection containing all items with title <paramref name="title"/></returns>
        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        /// <summary>
        /// Replaces from all items old Url with a new one
        /// </summary>
        /// <param name="oldUrl"></param>
        /// <param name="newUrl"></param>
        /// <returns>Returns the number of replaces urls</returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
