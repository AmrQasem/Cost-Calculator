using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CostCalc.Web.Startup))]
namespace CostCalc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
