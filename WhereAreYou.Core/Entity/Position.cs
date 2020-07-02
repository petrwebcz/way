using System;

namespace WhereAreYou.Core.Entity
{
    public class Position : Entity
    {
        public Location Location { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Location orig)
                return this.Location.Latitude.Equals(orig.Latitude) && this.Location.Latitude.Equals(orig.Longitude);

            return false;
        }

        public override int GetHashCode()
        {
            return this.Location.Latitude.GetHashCode() ^ this.Location.Longitude.GetHashCode();
        }
    }
}
