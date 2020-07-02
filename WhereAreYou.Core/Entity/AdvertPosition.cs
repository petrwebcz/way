namespace WhereAreYou.Core.Entity
{
    public class AdvertPosition : Position
    {
        public object Advertiser { get; set; }

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
