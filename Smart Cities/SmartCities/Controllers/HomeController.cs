namespace SmartCities.Controllers
{
    using DAL.Abstract;
    using DTO;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ViewModels;

    public class HomeController : BaseController
    {
        private readonly ICDRMapManager cdrMapManager;

        public HomeController(ICDRMapManager mapManager)
        {
            cdrMapManager = mapManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SearchPanel()
        {
            return PartialView();
        }

        public async Task<ActionResult> GetCDRcoordinates(SearchObjectModel searchObj)
        {
            var searchObjDto = MapModelToDto<SearchObjectDTO>(searchObj);

            var resultDto = await cdrMapManager.GetCDRData(searchObjDto);

            var result = MapDtoToViewModel<List<SearchResultViewModel>>(resultDto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}