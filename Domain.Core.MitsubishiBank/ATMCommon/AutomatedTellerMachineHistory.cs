using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.CustomerCommon;

namespace Domain.Core.MitsubishiBank.ATMCommon
{
    public class AutomatedTellerMachineHistory
    {
        [Key]
        public Guid AutomatedTellerMachineHistoryId { get; set; }

        public double OperationAmount { get; set; }
        public string OperationInitializerGuid { get; set; }
        public string OperationRecieverGuid { get; set; }
        public string OperationExecutedTime { get; set; }
        public string OperationStatus { get; set; }

        public string CalledFunctionality { get; set; }
        public virtual AutomatedTellerMachine AutomatedTellerMachine { get; set; }


        public AutomatedTellerMachineHistory()
        {
            AutomatedTellerMachineHistoryId = Guid.NewGuid();
        }

    }
}
