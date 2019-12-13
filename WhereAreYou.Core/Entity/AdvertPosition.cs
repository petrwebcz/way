using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class AdvertPosition : IPosition
    {
        public User User { get; set; }
        public Location Location { get; set; }
    }
}
