using System;

namespace WhereAreYou.Core.Entity
{
    public class UserPosition : Position
    {
        public UserPosition()
        {
            User = new User();
            Location = new Location();
        }

        public UserPosition(User user, Location location)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }

        public User User { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is UserPosition orig)
                return this.User.Equals(orig.User);

            return false;
        }

        public override int GetHashCode()
        {
            return this.User.Id.GetHashCode();
        }
    }
}
