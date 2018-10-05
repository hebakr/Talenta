using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Talenta.Startup))]
namespace Talenta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
