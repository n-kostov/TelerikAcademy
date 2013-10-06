using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_3.InformationalSite.Startup))]
namespace _3.InformationalSite
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
