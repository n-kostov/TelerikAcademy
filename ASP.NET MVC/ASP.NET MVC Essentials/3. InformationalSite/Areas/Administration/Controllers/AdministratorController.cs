using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3.InformationalSite.Areas.Administration.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        //
        // GET: /Administration/Administrator/
        public ActionResult Index()
        {
            return View();
        }
    }
}