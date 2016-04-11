using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TuPrecio.Startup))]
namespace TuPrecio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
