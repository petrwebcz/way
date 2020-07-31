using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.MobileApp.Services.Nominatim.Model;

namespace WhereAreYou.MobileApp.Services
{
    public class NominatimService : INominatimService
    {
        public async Task<Address> GetAddressByGeoAsync(Location location)
        {
            using (var client = new HttpClient() { BaseAddress = new Uri("https://nominatim.openstreetmap.org/") }) //TODO: Move to configuration or constants
            {
                //TODO: Move address to configuration or constants
                var result = await client.GetAsync($"reverse?format=geojson&lat={location.Latitude}&lon={location.Longitude}&zoom=18&addressdetails=1");
                result.EnsureSuccessStatusCode();

                var json = await result.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Root>(json);

                return root.features.Select(s => s.properties.address).FirstOrDefault();
            }
        }
    }
}

