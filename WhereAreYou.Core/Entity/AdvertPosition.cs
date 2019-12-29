using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class AdvertPosition : IPosition
    {
        public Advertiser Advertiser { get; }
        public Location Location { get; set; }
        public User User { get; set; }
    }
}
