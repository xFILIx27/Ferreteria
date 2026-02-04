using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FerreteriaDiego.Startup))]
namespace FerreteriaDiego
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
