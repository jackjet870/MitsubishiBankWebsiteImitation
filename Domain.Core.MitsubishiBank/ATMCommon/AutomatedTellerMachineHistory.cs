using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.CustomerCommon;

namespace Domain.Core.MitsubishiBank.ATMCommon
{
    public class AutomatedTellerMachineHistory
    {
        public int AutomatedTellerMachineHistoryId { get; set; }
        public string AutomatedTellerMachineHistoryGuid { get; set; }

        public double OperationAmount { get; set; }
        public string OperationInitializerGuid { get; set; }
        public string OperationRecieverGuid { get; set; }
        public DateTime OperationExecutedTime { get; set; }
        public OperationStatusCode OperationStatus { get; set; }

        public AutomatedTellerMachineFunctionality Functionality { get; set; }

        public AutomatedTellerMachineHistory()
        {
            AutomatedTellerMachineHistoryGuid = new Guid().ToString();
        }

    }
}
