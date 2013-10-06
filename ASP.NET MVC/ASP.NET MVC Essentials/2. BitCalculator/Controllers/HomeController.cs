using _2.BitCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2.BitCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calculator(CalculateModel model)
        {
            if (model.Type == null)
            {
                ViewBag.TypeValue = Math.Pow(2, (int)Types.b);
                ViewBag.Quantity = 1;
                ViewBag.Bandwidth = 1024;
            }
            else
            {
                ViewBag.Quantity = model.Quantity;
                ViewBag.Bandwidth = model.Bandwidth;
                if (model.Bandwidth == 1024)
                {
                    ViewBag.TypeValue = Math.Pow(2, int.Parse(model.Type));
                }
                else
                {
                    ViewBag.TypeValue = Math.Pow(10, Math.Round(int.Parse(model.Type) / 10.0) * 3)
                        * Math.Pow(2, -int.Parse(model.Type) % 10 != 0 ? 3 : 0);
                }
            }

            return View();
        }
    }
}