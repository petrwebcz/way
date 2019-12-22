using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhereAreYou.Web.Configuration;

namespace WhereAreYou.Web.Extensions
{
    public static class ServiceConfiguration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/way-client-app";
            });
        }

        public static void AddWayServices(this IServiceCollection services)
        {

        }

        public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var spaSettings = new SpaSettings();
            configuration.GetSection("AppSettings").Bind(spaSettings);
            services.AddSingleton<ISpaSettings>(spaSettings);
        }
    }
}
