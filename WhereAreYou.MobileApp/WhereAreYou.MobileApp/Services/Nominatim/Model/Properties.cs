namespace WhereAreYou.MobileApp.Services.Nominatim.Model
{
    //TODO: Use json property and use right code style.
    public class Properties
    {
        public string place_id { get; set; }
        public string osm_type { get; set; }
        public string osm_id { get; set; }
        public string place_rank { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string importance { get; set; }
        public string addresstype { get; set; }
        public object name { get; set; }
        public string display_name { get; set; }
        public Address address { get; set; }
    }
}
