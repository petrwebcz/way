using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WhereAreYou.Core.Responses
{
    [JsonObject("token")]
    public class Token
    {
        public Token()
        {

        }

        public Token(string jwt)
        {
            Jwt = jwt ?? throw new ArgumentNullException(nameof(jwt));
        }

        [JsonProperty("jwt")]
        [Required]
        public string Jwt { get; set; }
    }
}