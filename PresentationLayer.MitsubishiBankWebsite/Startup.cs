using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PresentationLayer.MitsubishiBankWebsite.Startup))]
namespace PresentationLayer.MitsubishiBankWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
