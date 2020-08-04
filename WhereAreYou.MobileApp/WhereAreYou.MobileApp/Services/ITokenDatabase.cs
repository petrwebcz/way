using System.Collections.Generic;
using System.Threading.Tasks;
using WhereAreYou.MobileApp.Models;

namespace WhereAreYou.MobileApp.Services
{
    public interface ITokenDatabase
    {
        Task InsertOrReplaceTokenAsync(SavedToken token);
        Task<IEnumerable<SavedToken>> GetTokenListAsync();
        Task RemoveTokenAsync(string meetHash);
    }
}