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

        public User(Guid id, string nickname, string meetInviteHash)
        {
            Id = id;
            Nickname = nickname ?? throw new ArgumentNullException(nameof(nickname));
            MeetInviteHash = meetInviteHash ?? throw new ArgumentNullException(nameof(meetInviteHash));
        }

        public Guid Id { get; set; }

        public string Nickname { get; set; }

        public string MeetInviteHash { get; set; }

        public static User Create(string nickname, string meetInviteHash)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Nickname = nickname,
                MeetInviteHash = meetInviteHash,
            };
        }

        public override bool Equals(object obj)
        {
            var orig = (User)obj;
            return this.Id == orig.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}


    