using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.BankCommon;
using Infrastructure.Data.MitsubishiBank.BankContexts;
using PresentationLayer.MitsubishiBankWebsite.Controllers.Base;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Intranet
{
    public class BankAdminController : BaseController
    {
        /*
         * Admin-home
         */
        public ActionResult Index()
        {
            return View();
        }
    }
}
