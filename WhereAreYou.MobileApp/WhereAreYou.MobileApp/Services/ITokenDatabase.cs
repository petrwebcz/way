using System.Collections.Generic;
using System.Threading.Tasks;
using WhereAreYou.MobileApp.Models;

namespace WhereAreYou.MobileApp.Services
{
    public interface ITokenDatabase
    {
        Task AddTokenAsync(SavedToken token);
        Task<IEnumerable<SavedToken>> GetTokenListAsync();
        Task RemoveTokenAsync(SavedToken token);
    }
}