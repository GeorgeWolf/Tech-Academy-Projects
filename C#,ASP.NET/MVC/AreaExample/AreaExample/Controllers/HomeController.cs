using AreaExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var context = new ACMEEntities();
            var products = context.Products.ToList();

            return View(products);
        }
    }
}