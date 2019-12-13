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
            var appSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddJwt(appSettings);
            services.AddSingleton<IAppSettings>(appSettings);
            services.AddSingleton<IDalRepository, InMemoryDbRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddTransient<IHashService, AesService>();
            services.AddTransient<IPositionService, PositionService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "WAY ROOM API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseWayErrorHandling();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            else
                app.UseHsts();
            
            //app.UseHttpsRedirection();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseExceptionHandler();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WAY ROOM API");
            });
        }
    }
}
