﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.BankCommon;

namespace Infrastructure.Data.MitsubishiBank.BankContext
{
    public class BankContext : DbContext
    {
        public BankContext() : base("name=MitsubishiBankDatabaseConnection")
        {
            
        }

        public DbSet<Bank> Banks { get; set; }

    }
}
