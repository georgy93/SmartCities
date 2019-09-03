namespace SmartCities
{
    using AutoMapper;
    using System.Linq;
    using System.Reflection;

    public class AutoMapperConfig
    {
        public static void Configure()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface);

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(profiles);
            });
        }
    }
}