using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnuWeb.Startup))]
namespace KnuWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
