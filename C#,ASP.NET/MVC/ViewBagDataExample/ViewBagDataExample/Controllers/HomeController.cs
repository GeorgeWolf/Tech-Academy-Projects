using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewBagDataExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MyDynamicProperty = "Hello ViewBag!";

            ViewData.Add(new KeyValuePair<string, object>("MyViewDataProperty", "Hello ViewData!"));
            ViewData["MyOtherViewDataProperty"] = "Hello Other ViewData!";

            return View();
        }
    }
}