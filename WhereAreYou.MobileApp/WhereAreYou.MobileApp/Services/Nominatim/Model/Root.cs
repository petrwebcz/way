using System.Collections.Generic;

namespace WhereAreYou.MobileApp.Services.Nominatim.Model
{
    public class Root
    {
        public string type { get; set; }
        public string licence { get; set; }
        public List<Feature> features { get; set; }
    }
}
