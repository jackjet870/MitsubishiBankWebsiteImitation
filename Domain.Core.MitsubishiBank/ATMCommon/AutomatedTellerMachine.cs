using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.BankCommon;

namespace Domain.Core.MitsubishiBank.ATMCommon
{
    public class AutomatedTellerMachine
    {
        [Key]
        public Guid AutomatedTellerMachineId { get; set; }
        [Display(Name = "ATM Code")]
        public string AutomatedTellerMachineCode { get; set; }
        public string OwnerBankCode { get; set; }
        [Display(Name = "Current Cash")]
        public double CurrentAviableMoneyAmount { get; set; }
        public virtual Bank Bank { get; set; }

        public ICollection<AutomatedTellerMachineHistory> OperationsHistory { get; set; }

        public AutomatedTellerMachine()
        {
            OperationsHistory = new List<AutomatedTellerMachineHistory>();
            AutomatedTellerMachineId = Guid.NewGuid();
        }

    }
}
