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