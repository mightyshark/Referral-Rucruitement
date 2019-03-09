using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRsmartWeb.Startup))]
namespace HRsmartWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
