using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.BankCommon
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }
        public string BankAccountGuid { get; set; }
        public string AccountName { get; set; }
        public string AccountCode { get; set; }


        public double TotalFinanceAmount { get; set; }

        public BankAccount()
        {
            BankAccountGuid = Guid.NewGuid().ToString();
        }
    }
}
