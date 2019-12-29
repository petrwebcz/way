using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public interface IDalRepository 
    {
        Task<IWay> CreateItemAsync(IMeet item);
        Task<IEnumerable<IMeet>> GetItemsAsync();
        Task<IWay> UpdateItemAsync(IMeet item);
        Task<IMeet> GetItemById(Guid id);
    }
}