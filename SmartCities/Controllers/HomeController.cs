using AutoMapper;
using DAL.Abstract;
using SmartCities.DTO;
using SmartCities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmartCities.Controllers
{
    public class HomeController : BaseController
    {
        private ICDRMapManager cdrMapManager;

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

        public async Task<ActionResult> GetCDRcoordinates(SearchObjectVm searchObj)
        {
            var searchObjDto = Mapper.Map<SearchObjectDTO>(searchObj);
            
            var resultDto = await cdrMapManager.GetCDRData(searchObjDto);

            var result = Mapper.Map<List<SearchResultVm>>(resultDto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}