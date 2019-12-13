using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Core.Requests
{
    [JsonObject("updatePosition")]
    public class UpdatePosition
    {
        [Required]
        public Location Location { get; set; }
    }
}