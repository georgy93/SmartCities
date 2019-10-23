namespace ApplicationCore.Services
{
    using ApplicationCore.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICDService
    {
        Task<IEnumerable<CallsFromLocationResult>> GetCDRDataAsync(CallsFromLocationSearchFilter searchDto);
    }
}
