using System;
using System.Net;
using System.Runtime.Serialization;

namespace WhereAreYou.Core.Exceptions
{
    [Serializable]
    public class NotFoundException : WayException 
    {
        public NotFoundException(string inviteHash) : base($"Room with Invite hash {inviteHash} is  not exist")
        {
             base.StatusCode = HttpStatusCode.NotFound;
        }

        public NotFoundException() : base($"Room not found ")
        {
            base.StatusCode = HttpStatusCode.NotFound;
        }
    }
}