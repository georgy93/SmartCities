namespace DAL.Abstract
{
    using SmartCities.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICDRMapManager
    {
        Task<List<SearchResultDTO>> GetCDRData(SearchObjectDTO searchDto);
    }
}
