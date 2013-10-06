using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystem.Models;
using LibrarySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Areas.Administration.Controllers
{
    [Authorize]
    [ValidateInput(false)]
    public class BooksController : Controller
    {
        private LibrarySystemEntities db = new LibrarySystemEntities();
        //
        // GET: /Administration/Books/

        public ActionResult Index()
        {
            var books = db.Books.Include("Category").Select(BookViewModel.FromBook);
            ViewData["categories"] = db.Categories.Select(cat => new BookCategoryViewModel
            {
                CategoryId = cat.CategoryId,
                CategoryName = cat.CategoryName
            });

            return View(books);
        }

        public ActionResult GetBooks([DataSourceRequest] DataSourceRequest request)
        {
            var books = db.Books.Include("Category").Select(BookViewModel.FromBook);
            return Json(books.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateBook([DataSourceRequest] DataSourceRequest request, BookViewModel bookViewModel)
        {
            if (bookViewModel != null && ModelState.IsValid)
            {
                var book = db.Books.Find(bookViewModel.BookId);
                var category = db.Categories.FirstOrDefault(cat => cat.CategoryName == bookViewModel.Category);
                if (book != null)
                {
                    book.Author = bookViewModel.Author;
                    book.CategoryId = category.CategoryId;
                    book.Description = bookViewModel.Description;
                    book.ISBN = bookViewModel.ISBN;
                    book.Title = bookViewModel.Title;
                    book.Website = bookViewModel.Website;
                    db.SaveChanges();
                }
            }

            return Json(new[] { bookViewModel }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult CreateBook([DataSourceRequest] DataSourceRequest request, BookViewModel bookViewModel)
        {
            if (bookViewModel != null && ModelState.IsValid)
            {
                var book = new Book
                {
                    Author = bookViewModel.Author,
                    Description = bookViewModel.Description,
                    ISBN = bookViewModel.ISBN,
                    Title = bookViewModel.Title,
                    Website = bookViewModel.Website
                };

                var category = db.Categories.FirstOrDefault(cat => cat.CategoryName == bookViewModel.Category);

                book.CategoryId = category.CategoryId;
                db.Books.Add(book);
                db.SaveChanges();
            }

            return Json(new[] { bookViewModel }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult DeleteBook([DataSourceRequest] DataSourceRequest request, BookViewModel bookViewModel)
        {
            if (bookViewModel != null)
            {
                var book = db.Books.Find(bookViewModel.BookId);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }

            return Json(new[] { bookViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
