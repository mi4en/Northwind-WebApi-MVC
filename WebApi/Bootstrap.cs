using ProjectFourthServices.Interfaces;
using ProjectFourthServices.Classes;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Lifetime;
using Unity.Exceptions;
using Unity.Injection;

namespace WebApi
{
    public class Bootstrapper
    {
        public static void Initialise(HttpConfiguration config)
        {
            var container = BuildUnityContainer();

            config.DependencyResolver = new UnityResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ICustomerService, CustomerService>(new ContainerControlledLifetimeManager());


            // container.RegisterType<>
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();            

            return container;
        }
    }

    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            this.container = container ?? throw new ArgumentNullException("container");
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                //    throw ex.Message;
                return null;
            }
            //catch (Exception ex)
            //{
            //    throw ex.Message;
            //}
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            container.Dispose();
        }
    }
}
