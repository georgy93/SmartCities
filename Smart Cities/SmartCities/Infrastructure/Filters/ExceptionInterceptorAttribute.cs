namespace SmartCities.Infrastructure.Filters
{
    using SmartCities.Infrastructure.Logging;
    using System;
    using System.Net;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionInterceptorAttribute : FilterAttribute, IExceptionFilter
    {
        private readonly ILogger logger;

        public ExceptionInterceptorAttribute()
            : this(DependencyResolver.Current.GetService<ILogger>())
        {
        }

        public ExceptionInterceptorAttribute(ILogger logger = null)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                logger?.Error(filterContext.Exception);

                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            filterContext.ExceptionHandled = true;
        }
    }
}