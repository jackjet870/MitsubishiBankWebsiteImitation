using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.ATMCommon;
using Domain.Core.MitsubishiBank.BankCommon;
using Infrastructure.Data.MitsubishiBank.BankContexts;
using MongoDB.Bson;
using PresentationLayer.MitsubishiBankWebsite.Controllers.Base;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}