
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Utils;

namespace WhereAreYou.Core.Entity
{
    [JsonObject("meet")]
    public class Meet : IMeet
    {
        public Meet()
        {
        }

        public Meet(Guid id) { }
        public Meet(string name)
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
        public ICollection<IPosition> Positions { get; set; }

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