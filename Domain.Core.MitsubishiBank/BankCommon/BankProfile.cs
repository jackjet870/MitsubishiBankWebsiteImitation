using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.BankCommon
{
    public class BankProfile
    {
        [Key]
        public int BankProfileId { get; set; }
        public string BankProfileGuid { get; set; }
        public string Name { get; set; }
        /*
         *  Code used to identify alias AutomatedTellerMachines
         */
        public string Code { get; set; } 
        public string Country { get; set; }
        public string Location { get; set; }



        public BankProfile()
        {
            BankProfileGuid = Guid.NewGuid().ToString();
        }
    }
}
