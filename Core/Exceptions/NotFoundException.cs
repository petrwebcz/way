using System;
using System.Runtime.Serialization;

namespace WhereAreYou.Core.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {

        public NotFoundException(Guid id) : base($"Room {id} is not exist")
        {

        }

        public NotFoundException(string inviteHash) : base("Login token is invalid")
        {
        }

    }
}