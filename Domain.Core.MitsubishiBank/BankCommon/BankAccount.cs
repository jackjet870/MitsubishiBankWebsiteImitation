using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.BankCommon
{
    public class BankAccount
    {
        [Key]
        public Guid BankAccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountCode { get; set; }
        public double TotalFinanceAmount { get; set; }
        public virtual Bank Bank { get; set; }
        public BankAccount()
        {
            BankAccountId = Guid.NewGuid();
        }
    }
}
