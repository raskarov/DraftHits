using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DraftHits_CF.Startup))]
namespace DraftHits_CF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
