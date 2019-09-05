namespace SmartCities.Web.MappingProfiles
{
    using ApplicationCore.DTOs;
    using AutoMapper;
    using SmartCities.Web.Models;

    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CallsFromLocationSearchModel, CallsFromLocationSearchDTO>();
        }
    }
}