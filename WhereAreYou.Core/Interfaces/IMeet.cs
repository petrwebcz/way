using System;
using System.Collections.Generic;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Core.Intefaces
{
    public interface IMeet
    {
        Guid Id { get; set; }
        DateTime Created { get; set; }
        string InviteHash { get; }
        string InviteUrl { get; }
        DateTime LastUpdated { get; set; }
        string Name { get; set; }
        ICollection<IPosition> Positions { get; set; }
    }
}