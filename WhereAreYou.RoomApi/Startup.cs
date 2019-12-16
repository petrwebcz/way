using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Extensions;
using WhereAreYou.Core.Infrastructure;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Services;
using WhereAreYou.Core.Utils;
using WhereAreYou.DAL.Repository;
using WhereAreYou.RoomApi.Infrastructure;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using WhereAreYou.RoomApi.Extensions;

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
            services.AddCoreServices();
            services.AddWayServices();
            services.AddConfiguration(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            else
                app.UseHsts();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseWayErrorHandling();
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WAY ROOM API");
            });
        }
    }
}
