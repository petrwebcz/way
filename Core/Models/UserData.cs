using Newtonsoft.Json;
using System;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Core.Model
{
    [JsonObject("userData")]
    public class UserData
    {
        public UserData()
        {

        }

        public UserData(User user, string inviteRoomHash)
        {
            User = user;
            RoomInviteHash = inviteRoomHash;
        }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("roomInviteHash")]
        public string RoomInviteHash { get; set; }

        public override string ToString()
        {
            return ToJson();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}