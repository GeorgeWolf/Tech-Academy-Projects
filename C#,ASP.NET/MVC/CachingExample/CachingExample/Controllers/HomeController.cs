using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CachingExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [OutputCache(Duration = 10, VaryByParam = "*", Location = System.Web.UI.OutputCacheLocation.Any, NoStore = true)]
        public ActionResult Index()
        {
            ViewBag.CurrentExecutedDateTime = DateTime.Now.ToString("hh:mm:ss.fff");
            return View();
        }


        public ActionResult DonutHoleCache()
        {
            ViewBag.LastExecutedDateTime = DateTime.Now.ToString("hh:mm:ss.fff");
            return PartialView("_DonutHole");
        }
    }
}