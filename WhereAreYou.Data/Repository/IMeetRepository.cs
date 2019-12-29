using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.DAL.Repository
{
    public interface IMeetRepository
    {
        Task<IMeet> CreateMeetAsync(string meetName);
        Task<IMeet> GetMeetAsync(string inviteToken);
        Task AddLocationAsync(User user, Location location);
        Task UpdateLocationAsync(User user, Location location);
        Task<IEnumerable<IMeet>> GetMeetsAsync();
    }
}