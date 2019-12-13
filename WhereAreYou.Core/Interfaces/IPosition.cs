using System;
using System.Collections.Generic;
using System.Text;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Core.Intefaces
{
    public interface IPosition
    {
        User User { get; set; }
        Location Location { get; set; }
    }
}
