using System;
using System.Collections.Generic;
using System.Text;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Responses
{
    public class MeetResponse
    {
        public IMeet Meet { get; set; }
        public IEnumerable<Position> Users { get; set; }
        public IEnumerable<AdvertPosition> Adverts { get; set; }
        public Position CurrentUser { get; set; }
        public Location CenterPoint { get; set; }
    }
}
