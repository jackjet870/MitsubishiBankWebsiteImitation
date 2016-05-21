using System;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Core.MitsubishiBank.CustomerCommon;
using Domain.Interfaces.MitsubishiBank.CustomerInterfaces;

namespace Domain.Interfaces.MitsubishiBank.BankInterfaces
{
    public interface IBankControl : IDisposable
    {
        void CreateBank(Bank bank, AdministrationAccessLevel accessLevel 
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        void UpdateBank(Bank bank, AdministrationAccessLevel accessLevel
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
    }
}