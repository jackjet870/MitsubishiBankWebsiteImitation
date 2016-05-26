using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.BankCommon
{
    public class BankProfile
    {
        [Key, ForeignKey("Bank")]
        public Guid BankProfileId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Code { get; set; } 
        public string Country { get; set; }
        public string Location { get; set; }

        public virtual Bank Bank { get; set; }

        public BankProfile()
        {
            BankProfileId = Guid.NewGuid();
        }
    }
}
