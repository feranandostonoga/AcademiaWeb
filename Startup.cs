using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Academia.Startup))]
namespace Academia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
