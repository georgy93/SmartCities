namespace SmartCities.Web.Infrastructure
{
    using ApplicationCore.Services;
    using Ninject;
    using SmartCities.Infrastructure.Logging;
    using SmartCities.Infrastructure.Services;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;

            AddBindings();
        }
        
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICDService>().To<CDRService>();

            kernel.Bind<ILogger>().To<Logger>().InSingletonScope();
        }
    }
}