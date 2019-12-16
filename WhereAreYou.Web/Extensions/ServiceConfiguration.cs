using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Services;
using WhereAreYou.Core.Utils;

namespace WhereAreYou.Web.Extensions
{
    public static class ServiceConfiguration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddMvc();
        }

        public static void AddWayServices(this IServiceCollection services)
        {

        }

        public static void AddCoreConfiguration(this IServiceCollection services)
        {

        }

        public static void AddConfiguration(this IServiceCollection services)
        {

        }
    }
}
