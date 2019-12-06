using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Infrastructure;
using WhereAreYou.Core.Utils;
using WhereAreYou.DAL.Repository;
using WhereAreYou.RoomApi.Infrastructure;

namespace WhereAreYou.RoomApi
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
               c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "WAY ROOM API", Version = "v1" });
           });

            /// --- SERVICES ---///
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddJwt(appSettings);
            services.AddSingleton<IAppSettings>(appSettings);
            services.AddSingleton<IDalRepository, InMemoryDbRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddTransient<IHashService, AesService>();
            services.AddTransient<IPositionService, PositionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            else
                app.UseHsts();

            //app.UseHttpsRedirection();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WAY ROOM API");
            });
        }
    }
}
