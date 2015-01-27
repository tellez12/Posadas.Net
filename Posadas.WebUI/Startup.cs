using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Posadas.WebUI.Startup))]
namespace Posadas.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
