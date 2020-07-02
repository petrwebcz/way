using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public interface IDalRepository
    {
        Task<Meet> CreateItemAsync(Meet item);
        Task<IEnumerable<Meet>> GetItemsAsync();
        Task UpdateItemAsync(Meet item);
        Task<Meet> GetItemById(Guid id);
    }
}