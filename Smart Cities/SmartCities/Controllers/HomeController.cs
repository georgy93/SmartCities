namespace SmartCities.Web.Controllers
{
    using ApplicationCore.DTOs;
    using ApplicationCore.Services;
    using SmartCities.Web.Models;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ViewModels;

    public class HomeController : BaseController
    {
        private readonly ICDService cdrMapManager;

        public HomeController(ICDService cdrMapManager)
        {
            this.cdrMapManager = cdrMapManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SearchPanel()
        {
            return PartialView();
        }

        public async Task<ActionResult> GetCDRcoordinates(CallsFromLocationSearchModel searchObject)
        {
            var searchObjectDto = MapModelToDto<CallsFromLocationSearchDTO>(searchObject);

            try
            {
                var resultDto = await cdrMapManager.GetCDRDataAsync(searchObjectDto);                
                var result = MapDtoToViewModel<IEnumerable<CallsFromLocationResultViewModel>>(resultDto);                

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}