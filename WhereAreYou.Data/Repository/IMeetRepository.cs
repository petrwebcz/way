using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.DAL.Repository
{
    public interface IMeetRepository
    {
        Task<Meet> CreateMeetAsync(string meetName);
        Task<Meet> GetMeetAsync(string inviteToken);
        Task<MeetResponse> GetMeetAsync(string inviteToken, User currentUser);
        Task<IEnumerable<Meet>> GetMeetsAsync();
        Task AddLocationAsync(User user, Location location);
        Task UpdateLocationAsync(User user, Location location);
    }
}