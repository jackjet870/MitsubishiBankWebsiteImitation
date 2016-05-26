using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.MitsubishiBankWebsite.Models.Bank
{
    public class BankCreateBaseModel
    {
        //Profile
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        //Account
        public string AccountName { get; set; }
        public string AccountCode { get; set; }
        public double TotalFinanceAmount { get; set; }

    }
}