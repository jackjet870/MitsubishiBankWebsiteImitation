using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.CustomerCommon;

namespace Domain.Interfaces.MitsubishiBank.CustomerInterfaces
{
    public interface ICustomerControl : IDisposable
    {
        void CreateCustomer(Customer customer, CustomerControlAccessLevel accessLevel 
            = CustomerControlAccessLevel.ManagerAccess);

        void DeleteCustomerById(int id, CustomerControlAccessLevel accessLevel);
        void DeleteCustomerByGuid(string guid, CustomerControlAccessLevel accessLevel);

        void UpdateCustomer(int id, Customer newRecord, CustomerControlAccessLevel accessLevel
            = CustomerControlAccessLevel.ManagerAccess);

        void UpdateCustmer(string guid, Customer newRecord, CustomerControlAccessLevel accessLevel
            = CustomerControlAccessLevel.ManagerAccess);
    }
}
