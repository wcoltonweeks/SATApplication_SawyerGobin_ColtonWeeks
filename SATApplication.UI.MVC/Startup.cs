using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SATApplication.UI.MVC.Startup))]
namespace SATApplication.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
