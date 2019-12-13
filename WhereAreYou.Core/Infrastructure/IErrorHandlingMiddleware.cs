using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WhereAreYou.Core.Infrastructure
{
    public interface IErrorHandlingMiddleware
    {
        Task Invoke(HttpContext context);
    }
}