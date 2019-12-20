using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhereAreYou.Core.Infrastructure;
using WhereAreYou.Web.Extensions;

namespace WhereAreYou.Web
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "way-client-app";
                //spa.UseAngularCliServer(npmScript: "start  ng serve --host 0.0.0.0 --disable-host-check --public-host sso.petrweb.local");
                //spa.UseProxyToSpaDevelopmentServer(baseUri: "http://way.petrweb.local:4200");
            });

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
        }
    }
}
