namespace DAL.Abstract
{
    using SmartCities.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICDRMapManager
    {
        Task<IReadOnlyCollection<CallsFromLocationResultDTO>> GetCDRDataAsync(CallsFromLocationSearchDTO searchDto);
    }
}
