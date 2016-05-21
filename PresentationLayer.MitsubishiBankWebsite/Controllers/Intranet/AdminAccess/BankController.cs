using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Interfaces.MitsubishiBank.BankInterfaces;
using PresentationLayer.MitsubishiBankWebsite.Controllers.Base;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Intranet.AdminAccess
{
    public class BankController : BaseController
    {
        private IBankRepository _repository;

        public BankController(IBankRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult ShowBankFullInformation(Bank bank)
        {
            _repository.ShowFullInformation(bank, AdministrationAccessLevel.FullAccessToSystem);
            return View(bank);
        }

        [HttpGet]
        public ActionResult CreateBank()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBank(Bank bank)
        {
            if (ModelState.IsValid)
            {
                bankDb.Banks.Add(bank);
                bankDb.SaveChanges();
            }
            return RedirectToAction("ShowBankFullInformation", new { bank = bank });
        }
    }
}