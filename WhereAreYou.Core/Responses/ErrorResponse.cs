using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using WhereAreYou.Core.Interfaces;

namespace WhereAreYou.Core.Responses
{
    public class ErrorResponse : ISelfSerializable
    {
        public ErrorResponse()
        {
        
        }
        public ErrorResponse(HttpStatusCode httpStatusCode, string errorMessage)
        {
            HttpStatusCode = httpStatusCode;
            ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
