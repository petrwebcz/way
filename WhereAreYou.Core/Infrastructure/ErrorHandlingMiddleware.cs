using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using WhereAreYou.Core.Exceptions;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.Core.Infrastructure
{
    public class ErrorHandlingMiddleware : IErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<ErrorHandlingMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                    await _next(context);
            }

            catch (NotFoundException e)
            {
                var response = new ErrorResponse(HttpStatusCode.NotFound, e.Message);
                _logger.LogWarning(e.Message);
                await WriteToResponseAsync(context, response);
            }

            catch (Exception e)
            {
                var response = new ErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                _logger.LogError(e.Message);
                await WriteToResponseAsync(context, response);
            }
        }

        private async Task WriteToResponseAsync(HttpContext context, ErrorResponse response)
        {
            if (context.Response.HasStarted)
                context.Response.Clear();

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.HttpStatusCode;

            await context.Response.WriteAsync(response.ToJson());
        }
    }
}
