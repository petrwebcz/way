using Newtonsoft.Json;
using System;
using WhereAreYou.Core.Interfaces;

namespace WhereAreYou.Core.Entity
{
    public class User : IUser
    {
        public User()
        {

        }

        public User(Guid id, string nickname, string roomInviteHash)
        {
            Id = id;
            Nickname = nickname ?? throw new ArgumentNullException(nameof(nickname));
            RoomInviteHash = roomInviteHash ?? throw new ArgumentNullException(nameof(roomInviteHash));
        }
        public Guid Id { get; set; }

        public string Nickname { get; set; }

        public string RoomInviteHash { get; set; }

        public static User Create(string nickname, string roomInviteHash)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Nickname = nickname,
                RoomInviteHash = roomInviteHash,
            };
        }
    }
}


    