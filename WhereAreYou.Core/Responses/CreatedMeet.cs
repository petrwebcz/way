using System;
using Newtonsoft.Json;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Core.Responses
{
    [JsonObject("createdMeet")]
    public class CreatedMeet 
    {
        public CreatedMeet()
        {
        }

        public CreatedMeet(string inviteUrl, string inviteHash, string name)
        {
            InviteUrl = inviteUrl ?? throw new ArgumentNullException(nameof(inviteUrl));
            InviteHash = inviteHash ?? throw new ArgumentNullException(nameof(inviteHash));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [JsonProperty("inviteUrl")]
        public string InviteUrl{ get; set; }

        [JsonProperty("inviteHash")]
        public string InviteHash { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}