using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Guid BankId { get; set; }
        public virtual BankProfile Profile { get; set; } 
        public virtual ICollection<BankAccount> Accounts { get; set; }
        public virtual ICollection<AutomatedTellerMachine> BankAutomatedTellerMachines { get; set; }
        public virtual ICollection<BankOperationHistory> BankOperationsHistory { get; set; } 

        public Bank()
        {
            BankId = Guid.NewGuid();
            Accounts = new List<BankAccount>();
            BankAutomatedTellerMachines = new List<AutomatedTellerMachine>();
            BankOperationsHistory = new List<BankOperationHistory>();
        }
    }
}
