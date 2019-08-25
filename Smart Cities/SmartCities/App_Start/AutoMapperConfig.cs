namespace SmartCities.App_Start
{
    using AutoMapper;
    using DTO;
    using Models;
    using ViewModels;

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
                CreateMap<SearchObjectModel, SearchObjectDTO>();
                CreateMap<SearchResultDTO, SearchResultViewModel>();
            }
        }
    }
}