namespace SmartCities.Controllers
{
    using AutoMapper;
    using System;
    using System.Web.Mvc;

    public class BaseController : Controller, IDisposable
    {
        private bool isDisposed = false;

        protected TDto MapModelToDto<TDto>(object model)
            where TDto : class
            => Mapper.Map<TDto>(model);

        protected TViewModel MapDtoToViewModel<TViewModel>(object dto)
            where TViewModel : class
            => Mapper.Map<TViewModel>(dto);

        protected override void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                // free managed objects
            }

            // free unmanaged objects (files, network connections, etc.)

            base.Dispose(disposing);
            isDisposed = true;
        }
    }
}