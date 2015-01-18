using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlyAwayForSchool.Startup))]
namespace FlyAwayForSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
