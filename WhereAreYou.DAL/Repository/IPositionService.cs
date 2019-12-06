using System.Collections.Generic;
using System.Linq;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.DAL.Repository
{
    public interface IPositionService
    {
        ILocation GetCenterPoint(IEnumerable<Location> locations);
        AdvertPosition GetAdvertismentPoint(IEnumerable<Location> locations);
    }
}