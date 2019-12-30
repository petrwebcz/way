using System;
using System.Collections.Generic;
using System.Linq;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public class PositionService : IPositionService
    {
        private readonly Location defaultLocation;

        private IEnumerable<IPosition> positions;

        public IEnumerable<Position> UsersPositions { get; private set; }
        public IEnumerable<AdvertPosition> AdvertsPositions { get; private set; }
        public Position CurrentUserPosition { get; private set; }
        public Location CenterPoint { get; private set; }

        public PositionService()
        {
            defaultLocation = new Location(50.191200, 14.657949);
        }

        public void Compute(IEnumerable<IPosition> positions, User User)
        {
            this.positions = positions;

            if (positions == null)
                throw new ArgumentNullException(nameof(positions));

            if (!positions.Any(a=>a.User.Id == User.Id))
                throw new ArgumentNullException(nameof(positions));

            CurrentUserPosition = positions.FirstOrDefault(f => f.User.Id == User.Id) as Position;

            if (CurrentUserPosition == null)
                throw new InvalidOperationException($"Positions not contains {User.Id}");

            CenterPoint = GetCenterPoint();

            AdvertsPositions = Enumerable.Empty<AdvertPosition>();

            UsersPositions = positions
                .Where(w => w.User.Id != User.Id)
                .Cast<Position>();
        }


        private Location GetCenterPoint()
        {
            var locations = positions.Select(s => s.Location);

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
    }
}