using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WhereAreYou.Core.Requests
{
    [JsonObject("createMeet")]
    public class CreateMeet
    {
        [Required]
        [MaxLength(160)]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}