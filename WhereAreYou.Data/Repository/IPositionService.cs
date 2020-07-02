using System.Collections.Generic;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public interface IPositionService
    {
        IEnumerable<AdvertPosition> AdvertsPositions { get; }
        Location CenterPoint { get; }
        UserPosition CurrentUserPosition { get; }
        IEnumerable<UserPosition> UsersPositions { get; }
        void Compute(IEnumerable<UserPosition> positions, User user);
    }
}