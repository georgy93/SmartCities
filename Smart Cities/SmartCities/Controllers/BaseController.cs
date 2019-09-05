namespace SmartCities.Web.Controllers
{
    using AutoMapper;
    using SmartCities.Infrastructure.Logging;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        private bool disposed = false;

        protected readonly ILogger logger;

        public BaseController()
            : this(DependencyResolver.Current.GetService<ILogger>())
        {
        }

        public BaseController(ILogger logger)
        {
            this.logger = logger;
        }

        protected TDto Map<TDto>(object model)
            where TDto : class
            => Mapper.Map<TDto>(model);

        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // free managed objects
            }

            // free unmanaged objects

            base.Dispose(disposing);

            disposed = true;
        }
    }
}