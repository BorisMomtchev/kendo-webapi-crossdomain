[assembly: WebActivator.PreApplicationStartMethod(typeof(WebApi.App_Start.UnityWebApi), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(WebApi.App_Start.UnityWebApi), "Stop")]

namespace WebApi.App_Start
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using DataObjects;
    using Microsoft.Practices.Unity;

    public static class UnityWebApi
    {
        private static IUnityContainer container;

        #region Public Methods

        public static void Start()
        {
            Initialise();
        }

        public static void Stop(){} 

        #endregion

        #region Private Methods

        private static void Initialise()
        {
            container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IProductRepository, ProductRepository>();
            return container;
        } 

        #endregion
    }
}