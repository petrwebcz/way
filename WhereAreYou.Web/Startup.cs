using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using WhereAreYou.Web.Extensions;

namespace WbereAreYou.Web
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
            services.AddConfiguration(Configuration);
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/way-client-app";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHttpsRedirection();
           
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            loggerFactory.AddFile("Logs/mylog-{Date}.txt");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp/dist/way-client-app";
            });

            if (env.IsDevelopment())
                ApplyDevelopmentSpecificConfiguration(app);

            if (env.IsProduction())
                ApplyProductionSpecificConfiguration(app);
        }

        private void ApplyProductionSpecificConfiguration(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts(); //TODO: https://aka.ms/aspnetcore-hsts.
        }

        private void ApplyDevelopmentSpecificConfiguration(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
        }
    }
}
