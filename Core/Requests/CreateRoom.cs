using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WhereAreYou.Core.Requests
{
    [JsonObject("createRoom")]
    public class CreateRoom
    {
        [Required]
        [MaxLength(160)]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}