using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommunityKitchen.Startup))]
namespace CommunityKitchen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
