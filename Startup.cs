using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Drop.Startup))]
namespace Drop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
