using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace WhereAreYou.Core.Requests
{
    public class EnterTheMeet
    {
        public EnterTheMeet()
        {
        }

        public EnterTheMeet(string inviteHash, string inviteUrl)
        {
            InviteHash = inviteHash ?? throw new ArgumentNullException(nameof(inviteHash));
            InviteUrl = inviteUrl ?? throw new ArgumentNullException(nameof(inviteUrl));
        }

        [Required]
        [MaxLength(100)]
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [Required]
        [JsonProperty("inviteHash")]
        public string InviteHash { get; set; }

        [Required]
        [JsonProperty("inviteUrl")]
        public string InviteUrl{ get; set; }
    }
}