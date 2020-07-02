using System;

namespace WhereAreYou.Core.Entity
{
    public class User
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
            if (obj is User orig)
                return this.Id == orig.Id;

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}


    