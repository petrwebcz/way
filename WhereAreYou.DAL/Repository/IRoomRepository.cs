using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Requests;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.DAL.Repository
{
    public interface IRoomRepository
    {
        Task<IRoom> CreateRoom(string roomName);
        Task<IRoom> GetRoomAsync(string inviteToken);
        Task PutLocationAsync(User user, Location location);
    }
}