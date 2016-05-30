using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.ATMCommon;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Core.MitsubishiBank.BaseCommon;
using Domain.Interfaces.MitsubishiBank.BankInterfaces;
using Infrastructure.Data.MitsubishiBank.BankContexts;

namespace Infrastructure.Data.MitsubishiBank.Repositories
{
    
    public class BankRepository : IBankRepository, IBankControl
    {
        private BankContext db;
        private bool _disposed = false;
        public BankRepository()
        {
            this.db = new BankContext();
        }

        public Bank CreateBank(Bank bank, AdministrationAccessLevel accessLevel)
        {
            if (accessLevel == AdministrationAccessLevel.FullAccessToSystem)
            {
                if (!db.Banks.Any())
                {
                    db.Banks.Add(bank);
                    db.SaveChanges();
                }
                else
                {
                    return db.Banks.First();
                }
            }
            return bank;
        }

        public BankProfile CreateBankProfile(BankProfile bankProfile, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            if (accessLevel == AdministrationAccessLevel.FullAccessToSystem)
            {
                if (db.Banks.Any())
                {
                    var bank = db.Banks.First();
                    if (bank.Profile == null)
                    {
                        AddBankProfile(bank, bankProfile, AdministrationAccessLevel.FullAccessToSystem);
                    }
                }
            }
            else
            {
                return null;
            }
            return bankProfile;
        }

        public BankAccount CreateBankAccount(BankAccount bankAccount, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            if (accessLevel == AdministrationAccessLevel.FullAccessToSystem)
            {
                if (db.Banks.Any())
                {
                    var bank = db.Banks.First();
                    AddBankAccount(bank, bankAccount, AdministrationAccessLevel.FullAccessToSystem);
                }
            }

            return bankAccount;
        }

        public BankOperationHistory CreateBankOperationHistoryRecord(BankOperationHistory record, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            if (accessLevel == AdministrationAccessLevel.FullAccessToSystem)
            {
                if (db.Banks.Any())
                {
                    var bank = db.Banks.First();
                    AddBankHistoryRecord(bank, record , AdministrationAccessLevel.FullAccessToSystem);
                }
            }
            return record;
        }

        public AutomatedTellerMachine CreateAutomatedTellerMachine(AutomatedTellerMachine machine, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            if (accessLevel == AdministrationAccessLevel.FullAccessToSystem)
            {
                if (db.Banks.Any())
                {
                    var bank = db.Banks.First();
                    AddBankAutomatedTellerMachine(bank, machine, AdministrationAccessLevel.FullAccessToSystem);
                }
            }
            return machine;
        }

        public AutomatedTellerMachineHistory CreateAutomatedTellerMachineHistoryRecord(AutomatedTellerMachineHistory record, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            if (db.Banks.Any())
            {
                var bank = db.Banks.First(); // Bug here : no selection of which ATM's record it is
                AddAutomatedTellerMachineHistoryRecord(bank.BankAutomatedTellerMachines.First(), record, AdministrationAccessLevel.FullAccessToSystem);

            }
            return record;
        }

        public void AddBankProfile(Bank bank, BankProfile bankProfile, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            db.Banks.Find(bank).Profile = bankProfile;
            db.SaveChanges();
        }

        public void AddBankAccount(Bank bank, BankAccount bankAccount, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            db.Banks.Find(bank).Accounts.Add(bankAccount);
            db.SaveChanges();

        }

        public void AddBankAutomatedTellerMachine(Bank bank, AutomatedTellerMachine automatedTellerMachine, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            db.Banks.Find(bank).BankAutomatedTellerMachines.Add(automatedTellerMachine);
            db.SaveChanges();

        }

        public void AddBankHistoryRecord(Bank bank, BankOperationHistory record, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            db.Banks.Find(bank).BankOperationsHistory.Add(record);
            db.SaveChanges();

        }

        public void AddAutomatedTellerMachineHistoryRecord(AutomatedTellerMachine machine, AutomatedTellerMachineHistory record, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            //Bug here!
            db.Banks.First().BankAutomatedTellerMachines.First().OperationsHistory.Add(record);
            db.SaveChanges();
        }

        public Bank ShowInformation(AccessLevels accessLevels)
        {
            try
            {
                return db.Banks.First();
            }
            catch (Exception e)
            {
                return null;
            }
            
        }


        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
