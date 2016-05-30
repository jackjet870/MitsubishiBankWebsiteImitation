using Domain.Core.MitsubishiBank.BankCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.BaseCommon;

namespace Domain.Core.MitsubishiBank.CustomerCommon
{
    public class Customer 
    {
        /*
         * Profile : stores presentational data about customer.
         * Account : stores financial data about customer.
         * History : stores all transactions records.
         */

        public Guid CustomerId { get; set; }
        public virtual BaseProfile Profile { get; set; }
        public virtual BaseAccount Account { get; set; }
        public virtual  ICollection<CustomerHistory> AccountHistory { get; set; }
        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
