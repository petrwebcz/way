using System;

namespace WhereAreYou.Core.Interfaces
{
    public interface IUser
    {
        string MeetInviteHash { get; set; }
        string Nickname { get; set; }
    }
}