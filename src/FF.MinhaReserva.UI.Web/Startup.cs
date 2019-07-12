using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FF.MinhaReserva.UI.Web.Startup))]
namespace FF.MinhaReserva.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
