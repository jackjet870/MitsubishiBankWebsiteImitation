using System;
using Domain.Core.MitsubishiBank.ATMCommon;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Core.MitsubishiBank.CustomerCommon;
using Domain.Interfaces.MitsubishiBank.CustomerInterfaces;

namespace Domain.Interfaces.MitsubishiBank.BankInterfaces
{
    public interface IBankControl : IDisposable
    {
        Bank CreateBank(Bank bank, AdministrationAccessLevel accessLevel 
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        BankProfile CreateBankProfile(BankProfile bankProfile, AdministrationAccessLevel accessLevel
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        BankAccount CreateBankAccount(BankAccount bankAccount, AdministrationAccessLevel accessLevel
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        BankOperationHistory CreateBankOperationHistoryRecord(BankOperationHistory record,
            AdministrationAccessLevel accessLevel
                = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        AutomatedTellerMachine CreateAutomatedTellerMachine(AutomatedTellerMachine machine,
            AdministrationAccessLevel accessLevel
                = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        AutomatedTellerMachineHistory CreateAutomatedTellerMachineHistoryRecord(AutomatedTellerMachineHistory record,
            AdministrationAccessLevel accessLevel
                = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        void AddBankProfile(Bank bank, BankProfile bankProfile, AdministrationAccessLevel accessLevel
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        void AddBankAccount(Bank bank, BankAccount bankAccount, AdministrationAccessLevel accessLevel 
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        void AddBankAutomatedTellerMachine(Bank bank, AutomatedTellerMachine automatedTellerMachine, AdministrationAccessLevel accessLevel
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        void AddBankHistoryRecord(Bank bank, BankOperationHistory record, AdministrationAccessLevel accessLevel
            = AdministrationAccessLevel.ReadOnlyAccessToSystem);
        void AddAutomatedTellerMachineHistoryRecord(AutomatedTellerMachine machine, AutomatedTellerMachineHistory record,
            AdministrationAccessLevel accessLevel
                = AdministrationAccessLevel.ReadOnlyAccessToSystem);


    }
}