using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class CurrentPosition : Entity
    {
        public Location Location { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is CurrentPosition orig)
                return obj.Equals(orig);

            return false;
        }

        public override int GetHashCode()
        {
            return this.Location.GetHashCode();
        }
    }
}
