namespace SmartCities.Controllers
{
    using DAL.Abstract;
    using DTO;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ViewModels;

    public class HomeController : BaseController
    {
        private readonly ICDRMapManager cdrMapManager;

        public HomeController(ICDRMapManager cdrMapManager)
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

        public async Task<ActionResult> GetCDRcoordinates(CallsFromLocationSearchViewModel searchObject)
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