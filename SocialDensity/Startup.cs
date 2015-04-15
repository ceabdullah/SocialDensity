using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialDensity.Startup))]
namespace SocialDensity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
