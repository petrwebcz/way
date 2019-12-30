using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Entity
{
    public class CurrentPosition : Entity
    {
        public Location Location { get; set; }
        public override bool Equals(object obj)
        {
            var orig = (CurrentPosition)obj;
            return obj.Equals(orig);
        }

        public override int GetHashCode()
        {
            return this.Location.GetHashCode();
        }
    }
}
