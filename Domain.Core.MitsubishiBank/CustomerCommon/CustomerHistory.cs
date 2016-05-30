using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.CustomerCommon
{
    public class CustomerHistory
    {
        [Key]
        public Guid CustomerHistoryId { get; set; }
        public virtual Customer Customer { get; set; }
        public double Summ { get; set; }
        public string SenderMail { get; set; }
        public string RecieverMail { get; set; }
        public string SenderGuid { get; set; }
        public string RecieverGuid { get; set; }


        public string Time { get; set; }
        public string Status { get; set; }


        public CustomerHistory()
        {
            CustomerHistoryId = Guid.NewGuid();
        }
    }
}
