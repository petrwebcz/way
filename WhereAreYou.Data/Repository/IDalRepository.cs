using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public interface IDalRepository
    {
        Task<IMeet> CreateItemAsync(IMeet item);
        Task<IEnumerable<IMeet>> GetItemsAsync();
        Task UpdateItemAsync(IMeet item);
        Task<IMeet> GetItemById(Guid id);
    }
}