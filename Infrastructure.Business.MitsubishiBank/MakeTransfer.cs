using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.ATMCommon;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Core.MitsubishiBank.CustomerCommon;
using Domain.Core.MitsubishiBank.EmployeeCommon;
using Services.Interfaces.MitsubishiBank;

namespace Infrastructure.Business.MitsubishiBank
{
    public class MakeTransfer : IMakeTransfer
    {
        public void SendMoneyToCustomerViaBank(Customer reciever, Bank sender, Employee executer, double amount)
        {
            
        }

        public void SendMoneyToCustomerViaBank(Customer reciever, Customer sender, Employee executer, double amount)
        {

        }

        public void SendMoneyToCustomerViaAtm(Customer reciever, Customer sender, AutomatedTellerMachine executer, double amount)
        {
            
        }
    }
}
