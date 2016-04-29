using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CacheControl.Startup))]
namespace CacheControl
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
