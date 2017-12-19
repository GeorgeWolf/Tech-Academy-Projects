using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalizationExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Languages = Request.UserLanguages;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}