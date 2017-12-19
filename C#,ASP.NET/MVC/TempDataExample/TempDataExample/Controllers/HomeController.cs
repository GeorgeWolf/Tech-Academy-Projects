using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TempDataExample.Models;

namespace TempDataExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var products = ProductManager.GetProducts();

            var value = TempData.Peek("message") == null ? "" : TempData.Peek("message").ToString();
            if (value.Contains("bob"))
            {
                TempData.Keep("message");
            }

            return View(products);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var products = ProductManager.GetProducts();
            var product = products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                TempData["message"] = "Item '" + collection["Name"] + "' was successfully created.";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var products = ProductManager.GetProducts();
            var product = products.FirstOrDefault(p => p.ProductId == id);

            return View(product);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                TempData["message"] = "Item was successfully updated.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var products = ProductManager.GetProducts();
            var product = products.FirstOrDefault(p => p.ProductId == id);

            return View(product);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                TempData["message"] = "Item was successfully deleted.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}