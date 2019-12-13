using System;

namespace WhereAreYou.Core.Interfaces
{
    public interface IUser
    {
        string RoomInviteHash { get; set; }
        string Nickname { get; set; }
    }
}