using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AddsSystem.Client.Startup))]
namespace AddsSystem.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
