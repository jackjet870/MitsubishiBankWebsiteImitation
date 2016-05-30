using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Data.MitsubishiBank.BankContexts;
using PresentationLayer.MitsubishiBankWebsite.StaticHelpers;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Internet
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            BankContext db = new BankContext();

            return View(db.Customers.First(p => p.CustomerId == Globals.CurrentCustomerGuid));
        }

        [HttpGet]
        public ActionResult SignIn(string Email, string Password)
        {
            BankContext db = new BankContext();
            if (db.Customers.FirstOrDefault(p => p.Profile.Email == Email && p.Profile.Password == Password) != null)
            {
                TempData["message"] = null;
                Globals.CurrentCustomerGuid =
                    db.Customers.FirstOrDefault(p => p.Profile.Email == Email && p.Profile.Password == Password)
                        .CustomerId;
                return RedirectToAction("MyProfile");
            }
            TempData["message"] = "Wrong credentials";
            return RedirectToAction("Index");
        }

        public ActionResult Exit()
        {
            Globals.CurrentCustomerGuid = new Guid();
            return RedirectToAction("Index");

        }
    }
}