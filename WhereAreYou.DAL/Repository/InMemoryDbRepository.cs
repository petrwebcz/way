using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using System.Linq;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.DAL.Repository
{
    public class InMemoryDbRepository : IDalRepository
    {
        List<IRoom> Data = new List<IRoom>();
        public async Task<IWay> CreateItemAsync(IRoom item)
        {
            Data.Add(item);
            return item;
        }

        public async Task<IRoom> GetItemById(Guid id)
        {
            return Data.FirstOrDefault(f=>f.Id == id);
        }

        public async Task<IEnumerable<IRoom>> GetItemsAsync()
        {
            return Data;
        }

        public async Task<IWay> UpdateItemAsync(IRoom item)
        {
            var index = Data.FindIndex(f => f.Id == item.Id);
            Data[index] = item;
            return item;
        }

    }
}
