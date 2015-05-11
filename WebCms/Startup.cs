using Microsoft.Owin;
using Owin;
using WebCms;

[assembly: OwinStartup(typeof(Startup))]
namespace WebCms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
