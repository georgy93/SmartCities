namespace SmartCities.MappingProfiles
{
    using ApplicationCore.DTOs;
    using AutoMapper;
    using SmartCities.Models;
    using SmartCities.ViewModels;

    public class SmartCitiesProfile : Profile
    {
        public SmartCitiesProfile()
        {
            CreateMap<CallsFromLocationSearchModel, CallsFromLocationSearchDTO>();
            CreateMap<CallsFromLocationResultDTO, CallsFromLocationResultViewModel>();
        }
    }
}