using System.Collections.Generic;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
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
