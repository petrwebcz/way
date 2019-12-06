using System;
using System.Runtime.Serialization;

namespace WhereAreYou.Core.Exceptions
{
    [Serializable]
    public class RoomAlreadyExistException : Exception
    {
        public RoomAlreadyExistException()
        {
        }

        public RoomAlreadyExistException(string roomName) : base($"Room with {roomName} is already exist")
        {
        }
    }
}