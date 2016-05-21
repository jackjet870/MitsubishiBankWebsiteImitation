using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Listener.MitsubishiBank.ListenerContexts
{
    public class Log
    {
        public int LogId { get; set; }
        public string LogName { get; set; }
        public DateTime LogTime { get; set; }
        public string LogCalledGuid { get; set; }
        public string LogType { get; set; }

    }
}
