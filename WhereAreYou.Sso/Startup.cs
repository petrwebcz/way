﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WhereAreYou.Core.Extensions;
using WhereAreYou.Sso.Extensions;
using Microsoft.Extensions.Hosting;
using System;

namespace WhereAreYou.Sso
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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/mylog-{Date}.txt");

            app.UseWayErrorHandling();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WAY SSO API");
            });

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCorsMiddleware();
            app.UseAuthorization();
            app.UseAuthentication();

            if (env.IsDevelopment())
                ApplyDevelopmentSpecificConfiguration(app);

            if (env.IsProduction())
                ApplyProductionSpecificConfiguration(app);
        }

        private void ApplyProductionSpecificConfiguration(IApplicationBuilder app)
        {
        }

        private void ApplyDevelopmentSpecificConfiguration(IApplicationBuilder app)
        {
        }
    }
}
