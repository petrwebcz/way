using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    [JsonObject("position")]
    public class Position : IPosition
    {
        public Position(User user, Location location)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
