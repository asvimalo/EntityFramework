using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaStoreWebApp.Startup))]
namespace MediaStoreWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
