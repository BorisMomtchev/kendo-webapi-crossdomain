using System;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace WebApi.App_Start
{
    /// <summary>
    /// Register your routes here.
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // This allows you to get a product by name.
            // (Used only as route example in this demo app)
            routes.MapHttpRoute(
                name: "ProductByName",
                routeTemplate: "api/product/byname/{name}",
                defaults: new { controller = "Product", action = "GetProductByName" }
            );

            // This route allows you to get products by category.
            // (Used only as route example in this demo app)
            routes.MapHttpRoute(
                name: "ProductsByCategory",
                routeTemplate: "api/product/category/{category}",
                defaults: new { controller = "Product", action = "GetProductsByCategory", category = "" }
            );

            // This is the default route.
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}

/*
 
-- /api/product - get all products
-- /api/product/4 - get a selected product by id
-- /api/product/byname/crossbow - get a selected product by name
-- /api/product/category/electronics - get products by category name
 
 */