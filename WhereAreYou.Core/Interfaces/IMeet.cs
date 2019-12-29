using System;
using System.Collections.Generic;

namespace WhereAreYou.Core.Intefaces
{
    public interface IMeet : IWay
    {
        DateTime Created { get; set; }
        string InviteHash { get; }
        string InviteUrl { get; }
        DateTime LastUpdated { get; set; }
        string Name { get; set; }
        ICollection<IPosition> Positions { get; set; }
        ILocation CenterPoint { get; set; }
    }
}