using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Raven.Client;

namespace TestSection.Development.WebAPI.Rest.Controllers.RavenControllers
{
    public abstract class RavenTestController : ApiController
    {
        public bool AutoSave { get; set; }

        public RavenTestController()
        {
            this.AutoSave = true;
        }
        public IDocumentSession RavenSession { get; protected set; }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (RavenSession != null)
                {
                    using (RavenSession)
                    {
                        if (this.AutoSave)
                            RavenSession.SaveChanges();
                        RavenSession.Dispose();
                        RavenSession = null;
                    }
                }
            }

            base.Dispose(disposing);
        }

    }
}