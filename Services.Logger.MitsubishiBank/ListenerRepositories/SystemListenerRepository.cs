using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Services.Listener.MitsubishiBank.ListenerInterfaces;
using Services.Listener.MitsubishiBank.ListenerContexts;

namespace Services.Listener.MitsubishiBank.ListenerRepositories
{
    public class SystemListenerRepository : ISystemListener
    {
        private ListenerContextDb db;
 
        public void CreateLog(bool toDbLog, bool toFileLog, string toFilePath, string executerGuid, string actionType)
        {
            if (toDbLog)
            {
                this.db = new ListenerContextDb(); 
                db.Logs.Add(new Log
                {
                    LogCalledGuid = executerGuid,
                    LogName = actionType,
                    LogTime = DateTime.Now,
                    LogType = actionType
                });
                db.SaveChanges();
            }
            if (toFileLog)
            {
                var log = new Log
                {
                    LogCalledGuid = executerGuid,
                    LogName = actionType,
                    LogTime = DateTime.Now,
                    LogType = actionType
                };
                var json = new JavaScriptSerializer().Serialize(log);
                File.WriteAllText(toFilePath, json, Encoding.UTF8);


            }
        }
    }
}
