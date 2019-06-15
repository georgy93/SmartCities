using AutoMapper;
using SmartCities.DTO;
using SmartCities.Models;

namespace SmartCities.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SmartCitiesProfile>();
            });
        }

        private class SmartCitiesProfile : Profile
        {
            public SmartCitiesProfile()
            {
                CreateMap<SearchObjectVm, SearchObjectDTO>().ReverseMap();
                CreateMap<SearchResultVm, SearchResultDTO>().ReverseMap();
            }
        }
    }
}