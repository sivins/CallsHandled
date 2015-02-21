using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CallsHandled.Startup))]
namespace CallsHandled
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
