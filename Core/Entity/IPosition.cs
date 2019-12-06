using System;
using System.Collections.Generic;
using System.Text;

namespace WhereAreYou.Core.Entity
{
    public interface IPosition
    {
        User User { get; set; }
        Location Location { get; set; }
    }
}
