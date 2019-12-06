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
            
            /// --- SERVICES ---///
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHashService, AesService>();
            services.AddSingleton<IAppSettings>(appSettings);

            /// --- DOCUMENTATION ---///
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Where Are You Identity API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "Where Are You Room API");
            });

            app.UseMvc();
        }
    }
}
