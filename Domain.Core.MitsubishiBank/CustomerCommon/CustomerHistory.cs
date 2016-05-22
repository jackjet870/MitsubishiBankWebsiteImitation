using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.CustomerCommon
{
    public class CustomerHistory
    {
        public int CustomerHistoryId { get; set; }
        public string CustomerHistoryGuid { get; set; }

        public CustomerHistory()
        {
            CustomerHistoryGuid = Guid.NewGuid().ToString();
        }
    }
}
