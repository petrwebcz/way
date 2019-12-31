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
        private User user;

        public IEnumerable<Position> UsersPositions { get; private set; }
        public IEnumerable<AdvertPosition> AdvertsPositions { get; private set; }
        public Position CurrentUserPosition { get; private set; }
        public Location CenterPoint { get; private set; }

        public PositionService()
        {
            defaultLocation = new Location(50.191200, 14.657949);
            SetDefaults();
        }

        public void Compute(IEnumerable<IPosition> positions, User user)
        {
            if (positions == null)
                throw new ArgumentNullException(nameof(positions));

            this.positions = positions;
            this.user = user;

            SetDefaults();

            if (!positions.Any())
                return;

            CurrentUserPosition = positions
                .Cast<Position>()
                .SingleOrDefault(w => w.User
                .Equals(user));

            UsersPositions = positions
                .Where(w => !w.User
                .Equals(user))
                .Cast<Position>();

            CenterPoint = GetCenterPoint();

            AdvertsPositions = Enumerable.Empty<AdvertPosition>();
        }

        private Location GetCenterPoint()
        {
            var locations = positions.Select(s => s.Location);

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
        private void SetDefaults()
        {
            CenterPoint = defaultLocation;
            CurrentUserPosition = null;
            UsersPositions = Enumerable.Empty<Position>();
            AdvertsPositions = Enumerable.Empty<AdvertPosition>();
        }
    }
}