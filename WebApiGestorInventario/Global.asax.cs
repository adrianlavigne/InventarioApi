using Microsoft.Owin;
using Owin;
using System.Web;

[assembly: OwinStartup(typeof(WebApiGestorInventario.Startup))]
namespace WebApiGestorInventario
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
