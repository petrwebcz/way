using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereAreYou.Core.Entity
{
    public class Meet : Entity
    {
        public Meet()
        {
        }

        public Meet(Guid id) { }
        public Meet(string name)
        {
            this.Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }

        public ICollection<Position> Positions { get; set; }

        public string InviteUrl { get; set; }

        public string InviteHash { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Meet orig)
                return this.Id == orig.Id;

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }

}

