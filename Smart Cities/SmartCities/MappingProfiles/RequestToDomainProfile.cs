namespace SmartCities.Web.MappingProfiles
{
    using ApplicationCore.Domain;
    using AutoMapper;
    using SmartCities.Web.Models;

    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CallsFromLocationSearchModel, CallsFromLocationSearchFilter>();
        }
    }
}