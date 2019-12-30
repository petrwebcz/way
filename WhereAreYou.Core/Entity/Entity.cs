namespace WhereAreYou.Core.Entity
{
    public abstract class Entity
    {
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}