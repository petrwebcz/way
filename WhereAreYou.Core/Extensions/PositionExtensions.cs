using System.Collections.Generic;
using System.Linq;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Core.Extensions
{
    public static class PositionExtensions
    {
        public static ICollection<UserPosition> GetUserPositions(this IEnumerable<Position> Positions)
        {
            return Positions.Where(w => w is UserPosition).Cast<UserPosition>().ToList();
        }
    }

}

