namespace SmartCities.Web.MappingProfiles
{
    using ApplicationCore.DTOs;
    using AutoMapper;
    using SmartCities.Web.Models;
    using SmartCities.Web.ViewModels;

    public class SmartCitiesProfile : Profile
    {
        public SmartCitiesProfile()
        {
            CreateMap<CallsFromLocationSearchModel, CallsFromLocationSearchDTO>();
            CreateMap<CallsFromLocationResultDTO, CallsFromLocationResultViewModel>();
        }
    }
}