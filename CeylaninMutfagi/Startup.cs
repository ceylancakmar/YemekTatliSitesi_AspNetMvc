using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CeylaninMutfagi.Startup))]
namespace CeylaninMutfagi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
