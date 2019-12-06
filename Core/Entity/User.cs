using Newtonsoft.Json;
using System;
namespace WhereAreYou.Core.Entity
{
    [JsonObject("user")]
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

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("nickName")]
        public string Nickname { get; set; }

        [JsonProperty("roomInviteHash")]
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


    