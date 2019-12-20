using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class Position : IPosition
    {
        public Position()
        {

        }
        public Position(User user, Location location)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }

        public User User { get; set; }
        public Location Location { get; set; }
    }
}
