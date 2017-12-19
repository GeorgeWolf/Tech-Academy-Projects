using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttributeRoutingExample.Controllers
{
    [RoutePrefix("Products")]
    public class HomeController : Controller
    {
        // GET: Home
        [Route("Index", Name = "ProductsIndex", Order = 1)]
        public ActionResult Index()
        {
            return View();
        }

        [Route("{id}", Name = "PRoductDetails", Order = 2)]
        public ActionResult Details(int id, string name)
        {
            return View();
        }

        [Route("~/Deals")]
        public ActionResult Deals()
        {
            return View();
        }

    }
}