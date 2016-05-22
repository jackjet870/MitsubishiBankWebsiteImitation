using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MitsubishiBank.BankContexts
{
    public class BankContextController : DropCreateDatabaseAlways<BankContext>
    {
        protected override void Seed(BankContext context)
        {
            base.Seed(context);
        }
    }
}
