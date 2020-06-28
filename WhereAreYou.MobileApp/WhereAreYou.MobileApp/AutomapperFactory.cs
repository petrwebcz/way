using AutoMapper;

namespace WhereAreYou.MobileApp
{
    public class AutomapperFactory
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new string[] { "WhereAreYou.MobileApp" });
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
