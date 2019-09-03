namespace SmartCities.Web.Controllers
{
    using AutoMapper;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        private bool disposed = false;

        protected TDto MapModelToDto<TDto>(object model)
            where TDto : class
            => Mapper.Map<TDto>(model);

        protected TViewModel MapDtoToViewModel<TViewModel>(object dto)
            where TViewModel : class
            => Mapper.Map<TViewModel>(dto);

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