namespace Infrastructure.Services
{
    using ApplicationCore.Domain;
    using ApplicationCore.Services;
    using Infrastructure.DAL.StoredProcedures;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CDRService : ICDService
    {
        public Task<IEnumerable<CallsFromLocationResult>> GetCDRDataAsync(CallsFromLocationSearchFilter searchDto)
        {
            var result = SpShowCallDetailRecords.ExecuteAsync(
                searchDto.IncludeMale,
                searchDto.IncludeFemale,
                searchDto.IncludeUnknowGender,
                searchDto.Include_18_to_25,
                searchDto.Include_26_to_35,
                searchDto.Include_36_to_45,
                searchDto.Include_46_to_65, 
                searchDto.Include_66_to_100,
                searchDto.StartDate);

            return result;
        }
    }
}
