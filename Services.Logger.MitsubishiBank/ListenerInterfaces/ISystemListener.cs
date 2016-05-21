using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Listener.MitsubishiBank.ListenerInterfaces
{
    public interface ISystemListener
    {
        void CreateLog(bool toDbLog, bool toFileLog, string toFilePath,  string executerGuid, string actionType);
    }
}
