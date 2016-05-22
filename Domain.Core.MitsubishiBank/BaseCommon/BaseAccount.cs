using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.BaseCommon
{
    public class BaseAccount
    {
        public int AccountId { get; set; }
        public string AccountGuid { get; set; }

        public BaseAccount()
        {
            AccountGuid = Guid.NewGuid().ToString();
        }
    }
}
