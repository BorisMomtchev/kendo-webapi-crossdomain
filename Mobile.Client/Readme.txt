NO ASP.NET and MVC

Cross Domain WebApi Sample
http://www.kendoui.com/code-library/mobile/listview/cross-domain-webapi-sample.aspx


NuGet packages used to create this project:
-- Microsoft.AspNet.WebApi - this is the WebApi framework
-- Unity.WebApi - this is the Unity IoC container for WebApi
-- WebApiContrib.Formatting.Jsonp - this is the necessary MediaTypeFormatter for cross-domain communication
-- WebActivator - this is used to enable Unity outside of the Global.asax file


-- /api/product - get all products
-- /api/product/4 - get a selected product by id
-- /api/product/byname/crossbow - get a selected product by name
-- /api/product/category/electronics - get products by category name