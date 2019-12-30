using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public interface IDalRepository
    {
        Task<Document> CreateItemAsync(IMeet item);
        Task<IEnumerable<IMeet>> GetItemsAsync();
        Task<Document> UpdateItemAsync(IMeet item);
        Task<IMeet> GetItemById(Guid id);
    }
}