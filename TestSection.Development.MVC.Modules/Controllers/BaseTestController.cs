using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.BankCommon;
using Infrastructure.Data.MitsubishiBank.BankContexts;

namespace TestSection.Development.MVC.Modules.Controllers
{
    public class BaseTestController : Controller
    {
        private BankContext bankDb;

        public BaseTestController()
        {
             bankDb = new BankContext();
        }
        // GET: BaseTest

        public ActionResult TEST_JSON_FILL_BANKDATA()
        {

            Bank b1 = new Bank();
            Bank b2 = new Bank();

            bankDb.Banks.AddRange(new List<Bank> { b1, b2 });
            bankDb.SaveChanges();

            BankProfile bp1 = new BankProfile { BankProfileId = b1.BankId, Name = "JapanBank", Location = "Tokyo", Code = "JPNB", Country = "Japan" };
            BankProfile bp2 = new BankProfile { BankProfileId = b2.BankId, Name = "KazBank", Location = "Almaty", Code = "KAZB", Country = "Kazakhstan" };

            bankDb.BanksProfile.AddRange(new List<BankProfile> { bp1, bp2 });

            bankDb.SaveChanges();

            b1.Accounts.Add(new BankAccount { AccountCode = "B1_REF1", AccountName = "B1_REF1", TotalFinanceAmount = 2000 });
            b1.Accounts.Add(new BankAccount { AccountCode = "B1_REF2", AccountName = "B1_REF2", TotalFinanceAmount = 3000 });
            b1.Accounts.Add(new BankAccount { AccountCode = "B1_REF3", AccountName = "B1_REF3", TotalFinanceAmount = 4000 });
            b2.Accounts.Add(new BankAccount { AccountCode = "B2_REF1", AccountName = "B2_REF1", TotalFinanceAmount = 2000 });
            b2.Accounts.Add(new BankAccount { AccountCode = "B2_REF2", AccountName = "B2_REF2", TotalFinanceAmount = 3000 });
            b2.Accounts.Add(new BankAccount { AccountCode = "B2_REF3", AccountName = "B2_REF3", TotalFinanceAmount = 4000 });

            bankDb.SaveChanges();

            return Json("SUCCESS", JsonRequestBehavior.AllowGet);
        }
        
    }
}