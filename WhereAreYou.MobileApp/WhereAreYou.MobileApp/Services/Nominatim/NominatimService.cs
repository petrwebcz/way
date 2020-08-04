using Newtonsoft.Json;
using System;
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
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                var result = await client.GetAsync($"reverse?format=geojson&lat={location.Latitude}&lon={location.Longitude}&zoom=18&addressdetails=1");
                result.EnsureSuccessStatusCode();

                var json = await result.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Root>(json);

                if(json.Contains("error")) //Nominatim return 200OK for successful response.
                {
                    return null;
                }

                return root.features.Select(s => s.properties.address).FirstOrDefault();
            }
        }
    }
}

