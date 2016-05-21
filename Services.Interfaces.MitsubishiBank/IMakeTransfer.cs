using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.ATMCommon;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Core.MitsubishiBank.CustomerCommon;
using Domain.Core.MitsubishiBank.EmployeeCommon;

namespace Services.Interfaces.MitsubishiBank
{
    public interface IMakeTransfer
    {
        /// <summary>
        /// Make transfer of money amount to customer
        /// </summary>
        /// <param name="reciever">Reciever</param>
        /// <param name="sender">Sender Bank</param>
        /// <param name="executer">Operation executer</param>
        /// <param name="amount">Amount</param>
        void SendMoneyToCustomerViaBank(Customer reciever, Bank sender, Employee executer, double amount);

        void SendMoneyToCustomerViaBank(Customer reciever, Customer sender, Employee executer, double amount);

        void SendMoneyToCustomerViaAtm(Customer reciever, Customer sender, AutomatedTellerMachine executer, double amount);
    }
}
