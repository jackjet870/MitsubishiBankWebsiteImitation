using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.BankCommon
{
    public class BankProfile
    {
        public int BankProfileId { get; set; }
        public string BankProfileGuid { get; set; }
        public string Name { get; set; }
        /*
         *  Code used to identify alias AutomatedTellerMachines
         */
        public string Code { get; set; } 
        public string Country { get; set; }
        public string Location { get; set; }
        public List<string> Phones { get; set; }
        public List<string> Emails { get; set; }


        public BankProfile()
        {
            BankProfileGuid = new Guid().ToString();
        }
    }
}
