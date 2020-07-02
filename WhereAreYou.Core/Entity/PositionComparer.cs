using System.Collections.Generic;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class PositionComparer : IEqualityComparer<UserPosition>
    {
        public bool Equals(UserPosition x, UserPosition y)
        {
            return x.User.Id == y.User.Id;
        }
        public int GetHashCode(UserPosition obj)
        {
            return obj.User.Id.GetHashCode();
        }
    }
}
