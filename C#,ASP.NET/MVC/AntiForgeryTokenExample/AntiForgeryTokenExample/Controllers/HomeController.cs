using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiForgeryTokenExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session.IsNewSession)
            {
                Session["userId"] = Guid.NewGuid();
                Session["funds"] = 100.0M;
            }
            ViewBag.UserId = Session["userId"];
            ViewBag.Funds = Session["funds"];

            return View();
        }

        public ActionResult Transfer()
        {
            if (Session.IsNewSession)
            {
                Session["userId"] = Guid.NewGuid();
                Session["funds"] = 100.0M;
            }
            ViewBag.UserId = Session["userId"];
            ViewBag.Funds = Session["funds"];

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Transfer(string account, decimal amount)
        {

            string userId = Session["userId"].ToString();
            decimal funds = Convert.ToDecimal(Session["funds"].ToString());

            // If this were a real application, then
            // the business logic would look
            // up the account to transfer money TO.
            // In this case, I'll just deduct it
            // from the user's funds (since this is
            // a silly example.

            funds -= amount;
            Session["funds"] = funds;
            return RedirectToAction("Index");
        }
    }
}