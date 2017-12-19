using CustomRoutesExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomRoutesExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var products = ProductManager.GetProducts();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var products = ProductManager.GetProducts();
            var product = products.FirstOrDefault(p => p.ProductId == id);

            return View(product);
        }
    }
}