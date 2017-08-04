using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResearchSummary.Startup))]
namespace ResearchSummary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
