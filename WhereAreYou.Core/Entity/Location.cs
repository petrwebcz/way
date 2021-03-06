﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WhereAreYou.Core.Entity
{
    public class Location : Entity
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
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Location orig)
                return this.Latitude == orig.Latitude && this.Longitude == orig.Longitude;

            return false;

        }

        public override int GetHashCode()
        {
            return this.Latitude.GetHashCode() ^ (int)this.Longitude.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Latitude} - {this.Longitude}";
        }
    }
}