using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.DAL.Repository
{
    public interface IDalRepository 
    {
        Task<IWay> CreateItemAsync(IRoom item);
        Task<IEnumerable<IRoom>> GetItemsAsync();
        Task<IWay> UpdateItemAsync(IRoom item);
        Task<IRoom> GetItemById(Guid id);
    }
}