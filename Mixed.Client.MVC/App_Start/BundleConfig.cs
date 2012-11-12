using System.Web;
using System.Web.Optimization;

namespace Mixed.Client.MVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/kendo/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/kendo/kendo.*"));

            // bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/kendo/").Include("~/Content/kendo/kendo.mobile.all.min.css"));
        }
    }
}


