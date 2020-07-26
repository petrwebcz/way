using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Core.Requests
{
    public class AddOrUpdatePosition
    {
        public AddOrUpdatePosition()
        {
        }

        public AddOrUpdatePosition(Location location)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }

        [Required]
        public Location Location { get; set; }
    }
}