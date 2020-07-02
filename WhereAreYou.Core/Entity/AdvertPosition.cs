using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class AdvertPosition : Entity
    {
        public object Advertiser { get; set; }
        public Location Location { get; set; }
        public User User { get; set; }

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
