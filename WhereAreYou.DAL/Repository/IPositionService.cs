using System.Collections.Generic;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public interface IPositionService
    {
        ILocation GetCenterPoint(IEnumerable<Location> locations);
        AdvertPosition GetAdvertismentPoint(IEnumerable<Location> locations);
    }
}