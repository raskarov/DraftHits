using DraftHits.Core.Unity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DraftHits.Website.Startup))]
namespace DraftHits.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
