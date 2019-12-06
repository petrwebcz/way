
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WhereAreYou.Core.Utils;

namespace WhereAreYou.Core.Entity
{
    [JsonObject("room")]
    public class Room : IRoom
    {
        public Room()
        {
        }

        public Room(Guid id) { }
        public Room(string name)
        {
            this.Name = name;
        }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("positions")]
        public List<IPosition> Positions { get; set; }

        [JsonProperty("inviteUrl")]
        public string InviteUrl { get; set; }

        [JsonProperty("inviteHash")]
        public string InviteHash { get; set; }

        [JsonProperty("centerPoint")]
        public ILocation CenterPoint { get; set; }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}