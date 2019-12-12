using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Infrastructure;
using WhereAreYou.Core.Utils;
using WhereAreYou.RoomIdentity.Services;

namespace WhereAreYou.RoomIdentity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /// --- CONFIGURATION  ---///
            var appSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);

            /// --- DOCUMENTATION ---///
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "WAY SSO API", Version = "v1" });
            });

            /// --- SERVICES ---///
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHashService, AesService>();
            services.AddSingleton<IAppSettings>(appSettings);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WAY SSO API");
            });



            app.UseAuthentication();




        }
    }
}
