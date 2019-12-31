using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class Position : Entity, IPosition
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

        public override bool Equals(object obj)
        {
            if (obj is Position orig)
                return this.User.Equals(orig.User);

            return false;
        }
        public override int GetHashCode()
        {
            return this.User.Id.GetHashCode();
        }
    }
}
