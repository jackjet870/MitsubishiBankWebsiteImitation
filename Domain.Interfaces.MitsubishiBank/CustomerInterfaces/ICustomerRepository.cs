using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.CustomerCommon;

namespace Domain.Interfaces.MitsubishiBank.CustomerInterfaces
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> GetCustomerList(CustomerInformationLevel informationLevel 
            = CustomerInformationLevel.AccountInformation);

        Customer GetCustomerById(int id, CustomerInformationLevel informationLevel 
            = CustomerInformationLevel.AccountInformation);

        Customer GetCustomerByGuid(string guid, CustomerInformationLevel informationLevel
            = CustomerInformationLevel.AccountInformation);

        Customer GetCustomerByName(string firstName, string lastName, string middleName,
            CustomerInformationLevel informationLevel
                = CustomerInformationLevel.AccountInformation);

        Customer GetCustomerByEmail(string email, CustomerInformationLevel informationLevel
            = CustomerInformationLevel.AccountInformation);

    }
}
