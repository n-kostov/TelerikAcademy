using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3.InformationalSite.Areas.Administration.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //
        // GET: /Administration/Admin/
        public ActionResult Index()
        {
            return View();
        }
    }
}