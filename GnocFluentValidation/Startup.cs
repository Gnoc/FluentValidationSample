using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GnocFluentValidation.Startup))]
namespace GnocFluentValidation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
