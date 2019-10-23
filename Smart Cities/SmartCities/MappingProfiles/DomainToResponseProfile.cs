namespace SmartCities.Web.MappingProfiles
{
    using ApplicationCore.Domain;
    using AutoMapper;
    using SmartCities.Web.ViewModels;

    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<CallsFromLocationResult, CallsFromLocationResultViewModel>();
        }
    }
}