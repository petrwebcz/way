using System;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public class WayBase : IWay
    {
        public Guid Id { get; set; }
        public override string ToString()
        {
            return Id.ToString();
        }

        public WayBase(Guid id)
        {
            this.Id = Id;
        }

        public WayBase(string  id)
        {
            this.Id = Guid.Parse(id);
        }
    }
}