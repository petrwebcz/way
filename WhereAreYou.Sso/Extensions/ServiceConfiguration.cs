using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Services;
using WhereAreYou.Core.Utils;
using WhereAreYou.Sso;
using WhereAreYou.Sso.Services;

namespace WhereAreYou.Sso.Extensions
{
    public static class ServiceConfiguration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddMvc()
                 .AddNewtonsoftJson()
                 .AddJsonOptions(o =>
                 {
                     o.JsonSerializerOptions.PropertyNamingPolicy = null;
                     o.JsonSerializerOptions.DictionaryKeyPolicy = null;
                 });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "WAY SSO API",
                    Version = "V1",
                    Description = "WAY SSO API"
                });
            });
        }

        public static void AddWayServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHashService, AesService>();
        }

        public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();

            configuration
                .GetSection("AppSettings")
                .Bind(appSettings);

            services.AddSingleton<IAppSettings>(appSettings);
        }
    }
}
