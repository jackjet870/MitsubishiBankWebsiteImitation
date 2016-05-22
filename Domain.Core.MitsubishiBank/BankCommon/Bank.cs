using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.ATMCommon;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core.MitsubishiBank.BankCommon
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }
        public string BankGuid { get; set; }
        public BankProfile Profile { get; set; }
        public List<BankAccount> Accounts { get; set; }
        public List<AutomatedTellerMachine> BankAutomatedTellerMachines { get; set; }
        public List<BankOperationHistory> BankOperationsHistory { get; set; }



        public Bank()
        {
            BankGuid = Guid.NewGuid().ToString();
        }
    }
}
