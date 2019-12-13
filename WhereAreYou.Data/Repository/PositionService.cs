using System;
using System.Collections.Generic;
using System.Linq;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public class PositionService : IPositionService
    {
        public ICollection<Location> Locations { get; set; }

        public PositionService()
        {
            Locations = new List<Location>();
        }

        public PositionService(ICollection<Location> locations)
        {
            Locations = locations ?? throw new ArgumentNullException(nameof(locations));
        }

        public ILocation GetCenterPoint(IEnumerable<Location> locations)
        {
            if (Locations.Count == 1)
                return Locations.Single();

            double x = 0;
            double y = 0;
            double z = 0;

            foreach (var geoCoordinate in Locations)
            {
                var latitude = geoCoordinate.Latitude * Math.PI / 180;
                var longitude = geoCoordinate.Longitude * Math.PI / 180;

                x += Math.Cos(latitude) * Math.Cos(longitude);
                y += Math.Cos(latitude) * Math.Sin(longitude);
                z += Math.Sin(latitude);
            }

            var total = Locations.Count;

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