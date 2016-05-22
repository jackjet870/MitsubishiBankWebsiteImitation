using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.BankCommon
{
    public class BankOperationHistory
    {
        [Key]
        public int BankOperationHistoryId { get; set; }
        public string BankOperationHistoryGuid { get; set; }

        public BankOperationHistory()
        {
            BankOperationHistoryGuid = Guid.NewGuid().ToString();
        }


    }
}
