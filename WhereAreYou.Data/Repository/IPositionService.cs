using System.Collections.Generic;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public interface IPositionService
    {
        IEnumerable<AdvertPosition> AdvertsPositions { get; }
        Location CenterPoint { get; }
        Position CurrentUserPosition { get; }
        IEnumerable<Position> UsersPositions { get; }
        void Compute(IEnumerable<IPosition> positions, User user);
    }
}