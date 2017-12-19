using ChildActionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildActionExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var products = ProductManager.GetProducts();
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult Categories()
        {
            var categories = CategoryManager.GetCategories();
            return PartialView("Categories", categories);
        }
    }
}