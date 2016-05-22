using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.BaseCommon
{
    public class BaseProfile
    {
        public int ProfileId { get; set; }
        public string ProfileGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public BaseProfile()
        {
            ProfileGuid = Guid.NewGuid().ToString();
        }
    }
}
