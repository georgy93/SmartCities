namespace SmartCities.Web.MappingProfiles
{
    using ApplicationCore.DTOs;
    using AutoMapper;
    using SmartCities.Web.ViewModels;

    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<CallsFromLocationResultDTO, CallsFromLocationResultViewModel>();
        }
    }
}