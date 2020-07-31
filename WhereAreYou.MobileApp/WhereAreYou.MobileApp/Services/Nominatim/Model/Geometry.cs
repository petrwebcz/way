using System.Collections.Generic;

namespace WhereAreYou.MobileApp.Services.Nominatim.Model
{
    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
}
