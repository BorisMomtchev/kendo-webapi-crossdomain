using System;
using System.Linq;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;

namespace WebApi.App_Start
{
    /// <summary>
    /// Register your formatters here.
    /// </summary>
    public class FormattersConfig
    {
        public static void RegisterFormatters(HttpConfiguration config)
        {
            config.Formatters.Insert(0, new JsonpMediaTypeFormatter());
        }
    }
}