using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace WhereAreYou.Core.Requests
{
    [JsonObject("createMeet")]
    public class CreateMeet
    {
        public CreateMeet()
        {

        }

        public CreateMeet(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [Required]
        [MaxLength(160)]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}