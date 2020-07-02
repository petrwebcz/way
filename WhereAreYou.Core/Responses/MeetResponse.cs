using System.Collections.Generic;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Core.Responses
{
    public class MeetResponse
    {
        public Meet Meet { get; set; }
        public IEnumerable<UserPosition> Users { get; set; }
        public IEnumerable<AdvertPosition> Adverts { get; set; }
        public UserPosition CurrentUser { get; set; }
        public Location CenterPoint { get; set; }
        public int ZoomLevel { get; set; }
    }
}
