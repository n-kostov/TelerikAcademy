using LibrarySystem.Models;
using LibrarySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    [ValidateInput(false)]
    public class HomeController : Controller
    {
        private LibrarySystemEntities db = new LibrarySystemEntities();
        public ActionResult Index()
        {
            var categories = db.Categories.Include("Books")
                .Select(x =>
                    new CategoryViewModel
                    {
                        CategoryId = x.CategoryId,
                        CategoryName = x.CategoryName,
                        Books = x.Books.AsQueryable().Select(BookViewModel.FromBook).ToList()
                    });

            return View(categories);
        }

        public JsonResult GetCategories()
        {
            var categories = db.Categories.Include("Books")
                .Select(x =>
                    new CategoryViewModel
                    {
                        CategoryId = x.CategoryId,
                        CategoryName = x.CategoryName,
                        Books = x.Books.AsQueryable().Select(BookViewModel.FromBook).ToList()
                    });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BookDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        public ActionResult Search(string query)
        {
            var books = db.Books.Include("Category").AsQueryable();
            if (!string.IsNullOrWhiteSpace(query))
            {
                var queryToLower = query.ToLower();
                books = books.Where(book => book.Title.ToLower().Contains(queryToLower) ||
                    book.Author.ToLower().Contains(queryToLower));
            }

            if (books == null)
            {
                return HttpNotFound();
            }

            ViewBag.Query = query;
            return View(books);
        }

        public JsonResult GetBooks(string text)
        {
            var books = db.Books;
            var booksByTitle = books.Where(book => book.Title.ToLower().Contains(text.ToLower()));

            var selectedBooks = new List<SearchBookViewModel>();
            selectedBooks.AddRange(booksByTitle.Select(book => new SearchBookViewModel { TitleAndAuthor = book.Title }));

            var booksByAuthor = books.Where(book => book.Author.ToLower().Contains(text.ToLower()));
            selectedBooks.AddRange(booksByAuthor.Select(book => new SearchBookViewModel { TitleAndAuthor = book.Author }));

            return Json(selectedBooks, JsonRequestBehavior.AllowGet);
        }
    }
}