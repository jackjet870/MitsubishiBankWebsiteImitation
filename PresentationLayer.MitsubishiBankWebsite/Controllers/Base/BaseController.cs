using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.ATMCommon;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Interfaces.MitsubishiBank.BankInterfaces;
using Infrastructure.Data.MitsubishiBank.BankContexts;
using Infrastructure.Data.MitsubishiBank.Repositories;
using Raven.Abstractions.Extensions;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Base
{
    public class BaseController : Controller
    {
        private double sum = 0;
        private Random rand = new Random();
        public BankRepository Repository;


        public void CreateSystem()
        {
            Bank bank = new Bank();

            BankProfile profile = new BankProfile
            {
                BankProfileId = bank.BankId,
                Name = "Bank of Tokyo-Mitsubishi UFJ",
                Location = "Tokyo - Shibuya - Sector II - Building 'Mitsubishi Corporation Office'",
                Code = "JAP_MITSU_BANK_MAIN",
                Country = "Japan"
            };
            List<BankAccount> accounts = new List<BankAccount>
            {
                new BankAccount
                {
                    AccountCode = profile.Code,
                    AccountName = profile.Name.Replace("MAIN", "TOKYO"),
                    TotalFinanceAmount = 2000000000,
                },
                new BankAccount
                {
                    AccountCode = profile.Code,
                    AccountName = profile.Name.Replace("MAIN", "OSAKA"),
                    TotalFinanceAmount = 1000000000,
                },
                new BankAccount
                {
                    AccountCode = profile.Code,
                    AccountName = profile.Name.Replace("MAIN", "KYOTO"),
                    TotalFinanceAmount = 500000000,
                }
            };
            bank.Profile = profile;
            foreach (var e in accounts)
            {
                bank.Accounts.Add(e);
            }
            foreach (var e in accounts)
            {
                sum = sum += e.TotalFinanceAmount;
            }
            List<AutomatedTellerMachine> automatedTellerMachines = new List<AutomatedTellerMachine>();
            for (int i = 0; i < 10; i++)
            {
                automatedTellerMachines.Add(new AutomatedTellerMachine
                {
                    AutomatedTellerMachineCode =
                        profile.Code.Replace("MAIN", "ATM_" + "ID_" + rand.Next(0, 9) + rand.Next(0, 9)),
                    CurrentAviableMoneyAmount = sum/10,
                    OwnerBankCode = profile.Code
                });

            }
            foreach (var e in automatedTellerMachines)
            {
                bank.BankAutomatedTellerMachines.Add(e);
            }

            Repository.CreateBank(bank, AdministrationAccessLevel.FullAccessToSystem);
        }

        public BaseController()
        {
            this.Repository = new BankRepository();
            CreateSystem();
        }

    }
}