using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoWebAppTienda.Startup))]
namespace ProyectoWebAppTienda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
