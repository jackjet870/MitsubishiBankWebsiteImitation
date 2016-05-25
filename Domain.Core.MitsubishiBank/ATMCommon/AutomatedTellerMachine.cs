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
        public string AutomatedTellerMachineCode { get; set; }
        public string OwnerBankCode { get; set; }
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
