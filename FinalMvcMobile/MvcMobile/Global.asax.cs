using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using System.Linq;                    // ViewEngines.Engines.OfType

namespace MvcMobile
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                    ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleMobileConfig.RegisterBundles(BundleTable.Bundles);

            // Cache never expires. You must restart application pool 
            // when you add/delete a view. A non-expiring cache can lead to 
            // heavy server memory load. 

           // ViewEngines.Engines.
          
            
            ViewEngines.Engines.OfType<RazorViewEngine>().First().ViewLocationCache =
            new DefaultViewLocationCache(System.Web.Caching.Cache.NoSlidingExpiration);

            // Add or Replace RazorViewEngine with WebFormViewEngine 
            // if you are using the Web Forms View Engine. 
        }
    }
}