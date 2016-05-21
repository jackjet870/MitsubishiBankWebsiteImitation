using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Data.MitsubishiBank.BankContexts;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Base
{
    public class BaseController : Controller
    {
        public BankContext bankDb;
        public BaseController()
        {
            this.bankDb = new BankContext();
        }
    }
}