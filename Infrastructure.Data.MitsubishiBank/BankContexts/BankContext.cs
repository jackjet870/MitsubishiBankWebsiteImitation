using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.ATMCommon;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Core.MitsubishiBank.BaseCommon;
using Domain.Core.MitsubishiBank.CustomerCommon;

namespace Infrastructure.Data.MitsubishiBank.BankContexts
{
    public class BankContext : DbContext
    {
        public BankContext() : base("name=MitsubishiBankDatabaseConnection")
        {
            
        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankProfile> BanksProfile { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankOperationHistory> BankOperationHistories { get; set; }
        public DbSet<AutomatedTellerMachine> AutomatedTellerMachines { get; set; }
        public DbSet<AutomatedTellerMachineHistory> AutomatedTellerMachineHistories { get; set; }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<BaseProfile> BaseProfiles { get; set; }
        public DbSet<BaseAccount> BaseAccounts { get; set; }
        public DbSet<CustomerHistory> CustomerHistories { get; set; }


    }
}
