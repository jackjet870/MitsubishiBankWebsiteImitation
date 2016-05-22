using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.MitsubishiBankWebsite.Controllers.Base;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return Index();
        }

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