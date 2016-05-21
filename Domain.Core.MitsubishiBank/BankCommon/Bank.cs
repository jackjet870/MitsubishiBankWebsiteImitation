using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.ATMCommon;

namespace Domain.Core.MitsubishiBank.BankCommon
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankGuid { get; set; }
        public BankProfile Profile { get; set; }
        public List<BankAccount> Accounts { get; set; }
        public List<AutomatedTellerMachine> BankAutomatedTellerMachines { get; set; }


        public Bank()
        {
            BankGuid = new Guid().ToString();
        }
    }
}
