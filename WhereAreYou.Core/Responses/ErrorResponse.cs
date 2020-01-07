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
        public ErrorResponse(HttpStatusCode httpStatusCode, ErrorType errorType, string errorMessage)
        {
            HttpStatusCode = httpStatusCode;
            ErrorType = errorType;
            ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public ErrorType ErrorType { get; set; }

        public string ErrorMessage { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
