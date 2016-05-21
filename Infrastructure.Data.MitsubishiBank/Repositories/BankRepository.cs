using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Interfaces.MitsubishiBank.BankInterfaces;
using Infrastructure.Data.MitsubishiBank.BankContexts;

namespace Infrastructure.Data.MitsubishiBank.Repositories
{
    
    public class BankRepository : IBankRepository, IBankControl
    {
        private BankContext db;
        private bool disposed = false;


        public BankRepository()
        {
            this.db = new BankContext();
        }
        public Bank ShowFullInformation(Bank bank, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            if (accessLevel == AdministrationAccessLevel.ReadOnlyAccessToSystem
                || accessLevel == AdministrationAccessLevel.FullAccessToSystem)
            {
                return db.Banks.Find(bank);
            }
            else
            {
                return null;
            }
            
        }

        public void CreateBank(Bank bank, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            if (accessLevel == AdministrationAccessLevel.FullAccessToSystem && db.Banks.Any() == false)
            {
                db.Banks.Add(new Bank());
            }
        }

        public void UpdateBank(Bank bank, AdministrationAccessLevel accessLevel = AdministrationAccessLevel.ReadOnlyAccessToSystem)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
