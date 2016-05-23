using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.ATMCommon;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Interfaces.MitsubishiBank.BankInterfaces;
using PresentationLayer.MitsubishiBankWebsite.Controllers.Base;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Intranet.AdminAccess
{
    public class BankController : BaseController
    {
        private IBankRepository _repository;

        public BankController(/*IBankRepository repository*/)
        {
            //_repository = repository;
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

        public void Test()
        {
            bankDb.Banks.Add(new Bank
            {
                Profile = new BankProfile
                {
                    Code = "TEST_BANK#001",
                    Country = "Japan",
                    Location = "Tokyo",
                    Name = "Mitsubishi UFJ Bank",
                   
                },
                Accounts = new List<BankAccount>
                {
                    new BankAccount
                    {
                        AccountCode = "MAIN_FIN_ACC#001",
                        AccountName = "Private Founds",
                        TotalFinanceAmount = 1000000
                    }
                },
                BankAutomatedTellerMachines = new List<AutomatedTellerMachine>
                {
                    new AutomatedTellerMachine
                    {
                        AutomatedTellerMachineCode = "ATM_001",
                        CurrentAviableMoneyAmount = 2000,
                        OwnerBankCode = "TEST_BANK#001",
                        OperationsHistory = new List<AutomatedTellerMachineHistory>()
                    }
                },
                BankOperationsHistory = new List<BankOperationHistory>
                {
                    new BankOperationHistory
                    {
                        
                    }
                }

            });
            bankDb.SaveChanges();

            
        }

        [HttpGet]
        public ActionResult ShowBankMeta(Bank bank)
        {
            for (int i = 0; i < 100000; i++)
            {
                Test();
            }
            //Test();
            var banks = bankDb.Banks.ToList();
            
            return Json(banks, JsonRequestBehavior.AllowGet);
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