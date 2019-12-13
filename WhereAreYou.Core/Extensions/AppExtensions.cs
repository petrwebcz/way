using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.Text;
using WhereAreYou.Core.Infrastructure;

namespace WhereAreYou.Core.Extensions
{
    public static class AppExtensions
    {
        public static void UseWayErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
