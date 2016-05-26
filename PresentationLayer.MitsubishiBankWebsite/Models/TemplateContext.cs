using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PresentationLayer.MitsubishiBankWebsite.Models.Bank;

namespace PresentationLayer.MitsubishiBankWebsite.Models
{
    public class TemplateContext : DbContext
    {
        public TemplateContext() : base("name=TemplateContextConnection")
        {
            
        }

        private DbSet<BankCreateBaseModel> BankCreateTemplate { get; set; }

        public System.Data.Entity.DbSet<PresentationLayer.MitsubishiBankWebsite.Models.Bank.BankCreateBaseModel> BankCreateBaseModels { get; set; }
    }
}