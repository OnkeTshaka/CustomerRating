using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ratings.Startup))]
namespace ratings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
