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
        public Guid BankOperationHistoryId { get; set; }
        public string OperationName { get; set; }

        public virtual Bank Bank { get; set; }


        public BankOperationHistory()
        {
            BankOperationHistoryId = Guid.NewGuid();
        }


    }
}
