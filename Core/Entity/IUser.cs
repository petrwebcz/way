using System;

namespace WhereAreYou.Core.Entity
{
    public interface IUser 
    {
        string RoomInviteHash { get; set; }
        string Nickname { get; set; }
    }
}