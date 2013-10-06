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
    public class CategoriesController : Controller
    {
        private LibrarySystemEntities db = new LibrarySystemEntities();
        //
        // GET: /Administration/Books/

        public ActionResult Index()
        {
            var categories = db.Categories.Select(cat => new BookCategoryViewModel
            {
                CategoryId = cat.CategoryId,
                CategoryName = cat.CategoryName
            });

            return View(categories);
        }

        public ActionResult GetCategories([DataSourceRequest] DataSourceRequest request)
        {
            var categories = db.Categories.Select(cat => new BookCategoryViewModel
            {
                CategoryId = cat.CategoryId,
                CategoryName = cat.CategoryName
            });

            return Json(categories.ToDataSourceResult(request, ModelState));
        }

        public ActionResult UpdateCategory([DataSourceRequest] DataSourceRequest request, BookCategoryViewModel categoryViewModel)
        {
            if (categoryViewModel != null && ModelState.IsValid)
            {
                var category = db.Categories.Find(categoryViewModel.CategoryId);
                if (category != null)
                {
                    category.CategoryName = categoryViewModel.CategoryName;
                    db.SaveChanges();
                }
            }

            return Json(new[] { categoryViewModel }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult CreateCategory([DataSourceRequest] DataSourceRequest request, BookCategoryViewModel categoryViewModel)
        {
            if (categoryViewModel != null && ModelState.IsValid)
            {
                var category = new Category { CategoryName = categoryViewModel.CategoryName };
                db.Categories.Add(category);
                db.SaveChanges();
            }

            return Json(new[] { categoryViewModel }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult DeleteCategory([DataSourceRequest] DataSourceRequest request, BookCategoryViewModel categoryViewModel)
        {
            if (categoryViewModel != null)
            {
                var category = db.Categories.Find(categoryViewModel.CategoryId);
                db.Categories.Remove(category);
                db.SaveChanges();
            }

            return Json(new[] { categoryViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
