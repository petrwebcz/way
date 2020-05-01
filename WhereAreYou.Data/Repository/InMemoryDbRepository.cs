using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using System.Linq;
using System.Collections.Concurrent;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Exceptions;

namespace WhereAreYou.DAL.Repository
{
    public class InMemoryDbRepository : IDalRepository
    {
        ConcurrentDictionary<Guid, IMeet> Data = new ConcurrentDictionary<Guid, IMeet>();
        public async Task<IMeet> CreateItemAsync(IMeet meet)
        {
            if (!Data.TryAdd(meet.Id, meet))
                throw new Exception($"IN MEMORY DB: Error in saving meet {meet.Id}");

            return meet;
        }

        public async Task<IMeet> GetItemById(Guid id)
        {
            Data.TryGetValue(id, out var meet);

            return meet;
        }

        public async Task<IEnumerable<IMeet>> GetItemsAsync()
        {
            return Data.Values;
        }

        public async Task UpdateItemAsync(IMeet meet)
        {
            Data[meet.Id] = meet;

            if (!Data.ContainsKey(meet.Id))
                throw new NotFoundException(meet.InviteHash);
        }
    }
}
