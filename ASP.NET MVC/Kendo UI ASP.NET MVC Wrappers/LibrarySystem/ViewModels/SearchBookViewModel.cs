using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.ViewModels
{
    public class SearchBookViewModel
    {
        //public static Expression<Func<Book, SearchBookViewModel>> FromBook
        //{
        //    get
        //    {
        //        return x => new SearchBookViewModel
        //        {
        //            Author = x.Author,
        //            Title = x.Title,
        //        };
        //    }
        //}

        //public string Title { get; set; }
        //public string Author { get; set; }

        public string TitleAndAuthor { get; set; }
    }
}