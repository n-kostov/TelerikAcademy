using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.ViewModels
{
    public class BookViewModel
    {
        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return x => new BookViewModel
                {
                    BookId = x.BookId,
                    Author = x.Author,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Title = x.Title,
                    Website = x.Website,
                    Category = x.Category.CategoryName
                };
            }
        }

        public int BookId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [StringLength(50)]
        public string ISBN { get; set; }
        [StringLength(250)]
        public string Website { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
    }
}