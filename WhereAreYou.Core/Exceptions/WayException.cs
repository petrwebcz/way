using System;
using System.Net;
using System.Runtime.Serialization;

namespace WhereAreYou.Core.Exceptions
{
    public class WayException : Exception
    {
        public HttpStatusCode StatusCode;

        public WayException(string message) : base(message)
        {
        }
    }
}