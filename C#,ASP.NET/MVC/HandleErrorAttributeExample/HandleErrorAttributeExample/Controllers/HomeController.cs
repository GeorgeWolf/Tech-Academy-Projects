using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandleErrorAttributeExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HandleError()]
        public ActionResult Index()
        {

            // You must also add:
            // <customErrors mode="On" defaultRedirect="Error" />
            // ... to the <system.web> section of the Web.config

            throw new Exception("Just a test exception!");
            return View();
        }
    }
}