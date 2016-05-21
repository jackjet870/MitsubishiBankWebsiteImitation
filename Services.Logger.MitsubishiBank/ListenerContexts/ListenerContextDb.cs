using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Listener.MitsubishiBank.ListenerContexts
{
    public class ListenerContextDb : DbContext
    {
        public ListenerContextDb() : base("name=MitsubishiBankListenerDatabaseConnection")
        {
            
        }
        public DbSet<Log> Logs { get; set; }
    }
}
