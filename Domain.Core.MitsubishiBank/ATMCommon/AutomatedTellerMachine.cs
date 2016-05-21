using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.ATMCommon
{
    public class AutomatedTellerMachine
    {
        public int AutomatedTellerMachineId { get; set; }
        public string AutomatedTellerMachineGuid { get; set; }
        public string AutomatedTellerMachineCode { get; set; }
        public string OwnerBankCode { get; set; }
        public double CurrentAviableMoneyAmount { get; set; }

        public List<AutomatedTellerMachineHistory> OperationsHistory { get; set; }

        public AutomatedTellerMachine()
        {
            AutomatedTellerMachineGuid = new Guid().ToString();
        }

    }
}
