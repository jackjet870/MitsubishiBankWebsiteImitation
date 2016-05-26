using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Interfaces.MitsubishiBank.BankInterfaces;
using Infrastructure.Data.MitsubishiBank.BankContexts;
using Infrastructure.Data.MitsubishiBank.Repositories;
using PresentationLayer.MitsubishiBankWebsite.Controllers.Base;
using PresentationLayer.MitsubishiBankWebsite.Models.Bank;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Intranet
{
    public class BankAdminController : BaseController
    {
        /*
         * Admin-home
         */

        private BankRepository repository;

        public BankAdminController()
        {
            repository = new BankRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageBankAction(string action)
        {
            switch (action)
            {
                case "create":
                    return RedirectToAction("CreateBank", "BankAdmin");
                case "update":
                    return RedirectToAction("UpdateBank", "BankAdmin");
                case "show":
                    return RedirectToAction("ShowBank", "BankAdmin");
            }
            return null;
        }

        [HttpGet]
        public ActionResult CreateBank()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBank([Bind(Include = "Id,Name,Code,Country,Location,AccountName,AccountCode,TotalFinanceAmount")] BankCreateBaseModel model)
        {
            if (ModelState.IsValid)
            {
                Bank bank = new Bank();
                BankProfile profile = new BankProfile
                {
                    BankProfileId = bank.BankId,
                    Name = model.Name,
                    Location = model.Location,
                    Code = model.Code,
                    Country = model.Country
                };
                BankAccount account = new BankAccount
                {
                    AccountCode = model.AccountCode,
                    AccountName = model.AccountName,
                    TotalFinanceAmount = 
                    model.TotalFinanceAmount
                };
                bank.Profile = profile;
                bank.Accounts.Add(account);

                Repository.CreateBank(bank, AdministrationAccessLevel.FullAccessToSystem);
                    
                return RedirectToAction("Index", "BankAdmin");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
