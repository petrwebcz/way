using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Services;
using WhereAreYou.Core.Utils;
using WhereAreYou.DAL.Repository;
using WhereAreYou.MeetApi.Infrastructure;

namespace WhereAreYou.MeetApi.Extensions
{
    public static class ServiceConfiguration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddMvc(c => c.EnableEndpointRouting = true)
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
                    Title = "WAY MEET API",
                    Version = "V1",
                    Description = "WAY MEET API"
                });
            });
        }

        public static void AddWayServices(this IServiceCollection services)
        {
            services.AddSingleton<IDalRepository, InMemoryDbRepository>();
            services.AddTransient<IMeetRepository, MeetRepository>();
            services.AddTransient<IHashService,    AesService>();
            services.AddTransient<IPositionService, PositionService>();
        }

        public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();

            configuration
                .GetSection("AppSettings")
                .Bind(appSettings);

            services.AddJwt(appSettings);
            services.AddSingleton<IAppSettings>(appSettings);
        }
    }
}
