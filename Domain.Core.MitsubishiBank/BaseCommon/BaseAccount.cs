using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.CustomerCommon;

namespace Domain.Core.MitsubishiBank.BaseCommon
{
    public class BaseAccount
    {
        [Key, ForeignKey("Customer")]
        public Guid BaseAccountId { get; set; }
        public double Cash { get; set; }
        public virtual Customer Customer { get; set; }
        public BaseAccount()
        {
            BaseAccountId = Guid.NewGuid();
        }
    }
}
