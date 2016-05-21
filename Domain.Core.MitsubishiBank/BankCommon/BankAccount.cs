using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.BankCommon
{
    public class BankAccount
    {
        public int BankFinanceId { get; set; }
        public string BankFinanceGuid { get; set; }
        public string AccountName { get; set; }
        public string AccountCode { get; set; }


        public double TotalFinanceAmount { get; set; }

        public BankAccount()
        {
            BankFinanceGuid = new Guid().ToString();
        }
    }
}
