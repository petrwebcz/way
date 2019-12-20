using System;
using System.Collections.Generic;
using System.Linq;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public class PositionService : IPositionService
    {
        private readonly ILocation defaultLocation;
        public PositionService()
        {
            defaultLocation = new Location(50.191200, 14.657949);
        }

        public PositionService(ICollection<Location> locations)
        {
            locations = locations ?? throw new ArgumentNullException(nameof(locations));
        }

        public ILocation GetCenterPoint(IEnumerable<Location> locations)
        {
            if (!locations.Any())
                return defaultLocation;

            if (locations.Count() == 1)
                return locations.Single();

            double x = 0;
            double y = 0;
            double z = 0;

            foreach (var geoCoordinate in locations)
            {
                var latitude = geoCoordinate.Latitude * Math.PI / 180;
                var longitude = geoCoordinate.Longitude * Math.PI / 180;

                x += Math.Cos(latitude) * Math.Cos(longitude);
                y += Math.Cos(latitude) * Math.Sin(longitude);
                z += Math.Sin(latitude);
            }

            var total = locations.Count();

            x = x / total;
            y = y / total;
            z = z / total;

            var centralLongitude = Math.Atan2(y, x);
            var centralSquareRoot = Math.Sqrt(x * x + y * y);
            var centralLatitude = Math.Atan2(z, centralSquareRoot);

            return new Location(centralLatitude * 180 / Math.PI, centralLongitude * 180 / Math.PI);
        }

        public AdvertPosition GetAdvertismentPoint(IEnumerable<Location> locations)
        {
            throw new NotImplementedException();
        }
    }
}