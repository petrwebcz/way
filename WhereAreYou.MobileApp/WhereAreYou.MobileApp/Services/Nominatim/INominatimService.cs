using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.MobileApp.Services.Nominatim.Model;

namespace WhereAreYou.MobileApp.Services
{
    public interface INominatimService
    {
        Task<Address> GetAddressByGeoAsync(Location location);
    }
}