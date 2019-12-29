using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class Position : IPosition
    {
        public Position()
        {
            User = new User();
            Location = new Location();
        }
        public Position(User user, Location location)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }
              
        public User User { get; set; }
        public Location Location { get; set; }
    }

    public class PositionComparer : IEqualityComparer<IPosition>
    {
        public bool Equals(IPosition x, IPosition y)
        {
            return x.User.Id == y.User.Id;
        }

        public int GetHashCode(IPosition obj)
        {
            return obj.User.Id.GetHashCode();
        }
    }
}
