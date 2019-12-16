using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.Text;
using WhereAreYou.Core.Infrastructure;

namespace WhereAreYou.Core.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseWayErrorHandling(this IApplicationBuilder app)
        {
           return  app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsMiddleware>();
        }
    }
}
