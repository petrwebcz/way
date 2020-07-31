﻿namespace WhereAreYou.MobileApp.Services.Nominatim.Model
{
    public class Address
    {
        public string house_number { get; set; }
        public string road { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }

        public override string ToString()
        {
            return $"{road} {house_number} {postcode} {city} {country}";
        }
    }
}
