using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.MitsubishiBank.EmployeeCommon
{
    public class EmployeeActionHistory
    {
        public int EmployeeActionHistoryId { get; set; }
        public string EmployeeActionHistoryGuid { get; set; }

        public EmployeeActionHistory()
        {
            EmployeeActionHistoryGuid = new Guid().ToString();
        }
    }
}
