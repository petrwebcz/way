using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using System.Linq;
using System.Collections.Concurrent;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public class InMemoryDbRepository : IDalRepository
    {
        ConcurrentDictionary<Guid, IRoom> Data = new ConcurrentDictionary<Guid, IRoom>();
        public async Task<IWay> CreateItemAsync(IRoom room)
        {
            if (!Data.TryAdd(room.Id, room))
                throw new Exception($"IN MEMORY DB: Error in saving room {room.Id}");

            return room;
        }

        public async Task<IRoom> GetItemById(Guid id)
        {
            IRoom room;
            if (!Data.TryGetValue(id, out room))
                throw new Exception($"IN MEMORY DB: Error in loading room {room.Id}");

            return room;
        }

        public async Task<IEnumerable<IRoom>> GetItemsAsync()
        {
            return Data.Values;
        }

        public async Task<IWay> UpdateItemAsync(IRoom room)
        {
            Data[room.Id] = room;

            if (!Data.ContainsKey(room.Id))
                throw new Exception($"IN MEMORY DB: Error when updating room {room.Id}, room is not exist.");

            return room;
        }

    }
}
