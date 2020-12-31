using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Booking_App.Startup))]
namespace Booking_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
