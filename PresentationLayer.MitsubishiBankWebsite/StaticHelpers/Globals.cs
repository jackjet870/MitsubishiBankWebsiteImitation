using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.MitsubishiBankWebsite.StaticHelpers
{
    public static class Globals
    {
        public static string CurrentAction { get; set; } = "ShowBank";
        public static Random Random { get; set; } = new Random();
        public static Guid CurrentCustomerGuid { get; set; }
    }
}