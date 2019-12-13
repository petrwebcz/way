using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhereAreYou.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Globalization;
using WhereAreYou.Core.Exceptions;
using Newtonsoft.Json;

namespace WhereAreYou.Core.Infrastructure.Tests
{
    [TestClass()]
    public class ErrorHandlingMiddlewareTests
    {
        [TestMethod()]
        public async Task ErrorHandlingMiddlewareTest()
        {
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            var middleware = new ErrorHandlingMiddleware(
                next: (innerHttpContext) => throw new NotFoundException("TEST HASH"),
                loggerFactory: LoggerFactory.Create((c) => { }));

            await middleware.Invoke(context);
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var reader = new StreamReader(context.Response.Body);
            var streamText = reader.ReadToEnd();
            var objResponse = JsonConvert.DeserializeObject<Responses.ErrorResponse>(streamText);

            Assert.IsInstanceOfType(objResponse, typeof(Responses.ErrorResponse));
            Assert.IsTrue(objResponse.HttpStatusCode == System.Net.HttpStatusCode.NotFound);
        }
    }
}