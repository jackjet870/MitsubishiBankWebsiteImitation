using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.BaseCommon;
using Domain.Core.MitsubishiBank.CustomerCommon;

namespace Domain.Core.MitsubishiBank.EmployeeCommon
{
    public class Employee : Customer
    {
        public int EmployeeId { get; set; }
        public string EmployeeGuid { get; set; }
        public EmployeeRank Rank { get; set; }
        public List<EmployeeActionHistory> ActionHistory { get; set; }
        public EmployeeInnerData InnerData { get; set; }



        public Employee() 
        {
            EmployeeGuid = new Guid().ToString();
        }
    }
}
