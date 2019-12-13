using System;
using System.Net;
using System.Runtime.Serialization;

namespace WhereAreYou.Core.Exceptions
{
    [Serializable]
    public class InvalidTokenException : WayException 
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public InvalidTokenException(string inviteHash) : base($"Invalid token {inviteHash}")
        {
            this.HttpStatusCode = HttpStatusCode.Unauthorized;
        }
    }
}