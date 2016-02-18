using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wunderlist.Web.Startup))]
namespace Wunderlist.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
