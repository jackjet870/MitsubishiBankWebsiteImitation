using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.CustomerCommon;
using Infrastructure.Data.MitsubishiBank.BankContexts;
using PresentationLayer.MitsubishiBankWebsite.StaticHelpers;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Internet
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TransactionBetweenCustomers(string Password, double Amount, string Email)
        {
            
            BankContext db = new BankContext();
            if (db.Customers.FirstOrDefault(p => p.Profile.Password == Password).CustomerId == Globals.CurrentCustomerGuid)
            {
                if (db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Account.Cash >= Amount)
                {
                    if (db.Customers.FirstOrDefault(p => p.Profile.Email == Email)!=null)
                    {
                        db.Customers.FirstOrDefault(p => p.Profile.Email == Email).Account.Cash += Amount;
                        db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Account.Cash -=
                            Amount;
                        db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).AccountHistory.Add(new CustomerHistory
                        {
                            RecieverGuid = db.Customers.FirstOrDefault(p => p.Profile.Email == Email).CustomerId.ToString(),
                            RecieverMail = db.Customers.FirstOrDefault(p => p.Profile.Email == Email).Profile.Email,
                            SenderGuid = db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).CustomerId.ToString(),
                            SenderMail = db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Profile.Email,
                            Status = "Transaction",
                            Summ = Amount,
                            Time = DateTime.Now.ToLongDateString(),
                            

                        });
                        db.SaveChanges();
                    }
                }
                
            }
            return RedirectToAction("MyProfile", "Site");
        }

        public ActionResult MakePayment(string Password, double Amount, string ServiceName)
        {

            BankContext db = new BankContext();
            if (db.Customers.FirstOrDefault(p => p.Profile.Password == Password).CustomerId == Globals.CurrentCustomerGuid)
            {
                if (db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Account.Cash >= Amount)
                {
                    {
                        db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Account.Cash -=
                            Amount;
                        db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).AccountHistory.Add(new CustomerHistory
                        {
                            RecieverGuid = db.Banks.First().BankId.ToString(),
                            RecieverMail = db.Banks.First().Profile.Name,
                            SenderGuid = db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).CustomerId.ToString(),
                            SenderMail = db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Profile.Email,
                            Status = ServiceName,
                            Summ = Amount,
                            Time = DateTime.Now.ToLongDateString(),


                        });
                        db.SaveChanges();
                    }
                }

            }
            return RedirectToAction("MyProfile", "Site");
        }
    }
}