namespace SmartCities.ApplicationCore.Services
{
    using ApplicationCore.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICDService
    {
        Task<IEnumerable<CallsFromLocationResultDTO>> GetCDRDataAsync(CallsFromLocationSearchDTO searchDto);
    }
}
