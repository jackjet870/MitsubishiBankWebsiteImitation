using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILayer.MitsubishiBankRestful.Models.RavenDbTestModels
{
    public class RavenCustomerTest
    {
        public int Id { get; set; }
        public string CustomerGuid { get; set; }
        public string Name { get; set; }
        public double CustomerFinance { get; set; }

        public RavenCustomerTest()
        {
            CustomerGuid = Guid.NewGuid().ToString();
        }

    }
}