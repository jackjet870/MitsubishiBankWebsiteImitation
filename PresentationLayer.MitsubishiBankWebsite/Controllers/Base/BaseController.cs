using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Data.MitsubishiBank.BankContexts;
using Infrastructure.Data.MitsubishiBank.Repositories;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Base
{
    public class BaseController : Controller
    {
        public BankRepository Repository;

        public void CleanSystemDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BankContext>());
        }
        public BaseController()
        {
            this.Repository = new BankRepository();
        }
    }
}