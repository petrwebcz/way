using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhereAreYou.Core.Extensions;
using WhereAreYou.MeetApi.Extensions;

namespace WhereAreYou.MeetApi
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
            app.UseWayErrorHandling();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            if (env.IsDevelopment())
                ApplyDevelopmentSpecificConfiguration(app);

            if (env.IsProduction())
                ApplyProductionSpecificConfiguration(app);

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WAY MEET API");
            });
        }

        private void ApplyProductionSpecificConfiguration(IApplicationBuilder app)
        {
        }

        private void ApplyDevelopmentSpecificConfiguration(IApplicationBuilder app)
        {
        }
    }
}
