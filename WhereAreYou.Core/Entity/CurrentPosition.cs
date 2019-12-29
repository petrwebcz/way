using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class CurrentPosition : IPosition
    {
        public const bool SEFPOSITION = true;
        public Location Location { get; set; }
        public User User { get; set; }
    }
}
