using System.Collections.Generic;

namespace WhereAreYou.MobileApp.Services.Nominatim.Model
{
    public class Feature
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public List<double> bbox { get; set; }
        public Geometry geometry { get; set; }
    }
}
