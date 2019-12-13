using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    [JsonObject("location")]
    public class Location : ILocation
    {
        public Location()
        {
        }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        [Required]
        [JsonProperty("lat")]
        public double Latitude { get; }

        [Required]
        [JsonProperty("lng")]
        public double Longitude { get; }

        public override bool Equals(object obj)
        {
            var orig = (Location)obj;
            return this.Latitude == orig.Latitude && this.Longitude == orig.Longitude;
        }

        public override int GetHashCode()
        {
            return (int)this.Latitude ^ (int)this.Longitude;
        }

    }
}