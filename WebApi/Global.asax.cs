using System;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;
using WebApi.App_Start;

namespace WebApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FormattersConfig.RegisterFormatters(GlobalConfiguration.Configuration);
        }
    }
}