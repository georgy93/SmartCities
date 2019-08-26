namespace SmartCities.App_Start
{
    using AutoMapper;
    using DTO;
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
                CreateMap<CallsFromLocationSearchViewModel, CallsFromLocationSearchDTO>();
                CreateMap<CallsFromLocationResultDTO, CallsFromLocationResultViewModel>();
            }
        }
    }
}