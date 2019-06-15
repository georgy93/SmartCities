using SmartCities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ICDRMapManager
    {
        Task<List<SearchResultDTO>> GetCDRData(SearchObjectDTO searchDto);
    }
}
