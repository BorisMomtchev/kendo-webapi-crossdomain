using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessObjects;
using DataObjects;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the WebApi controller for the Products.
    /// 
    /// This class is using the Unity IoC container for Dependency Injection.
    /// Check the Global.asax file for usage. (Bootstrapper.cs)
    /// </summary>
    public class ProductController : BaseController<Product>
    {
        // FIELDS
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Dependency Injection using Unity.  Look at the App_Start/UnityWebApi.cs file for usage.
        /// </summary>
        /// <param name="repository"></param>
        public ProductController(IProductRepository productRepository) : base(productRepository)
        {
            this._productRepository = productRepository;
        }


        #region Custom Actions

        /// <summary>
        /// This is a custom action that returns Product by category.
        /// Check how the route is created in the RouteConfig.cs file in the App_Start folder.
        /// </summary>
        /// <param name="category">Category Name</param>
        /// <returns></returns>
        public List<Product> GetProductsByCategory(string category)
        {
            Expression<Func<Product, bool>> exp = null;
            if (!string.IsNullOrEmpty(category))
                exp = c => c.Category.CategoryName.ToLower() == category.ToLower();

            return _productRepository.Get(exp).ToList();
        }

        /// <summary>
        /// Get a Product by name.  Check the RouteConfig.cs file for routing.
        /// </summary>
        /// <param name="name">Product Name</param>
        /// <returns></returns>
        public Product GetProductByName(string name)
        {
            Product product = _productRepository.Get(p => p.Name.ToLower() == name.ToLower()).SingleOrDefault();
            if (product == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return product;
        }

        #endregion
    }
}