using CustomDisplayTemplateExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomDisplayTemplateExample.Controllers
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
            var product = ProductManager.GetProducts().FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

    }
}