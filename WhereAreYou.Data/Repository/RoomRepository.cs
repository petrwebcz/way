using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Responses;
using WhereAreYou.Core.Exceptions;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Services;

namespace WhereAreYou.DAL.Repository
{
    public class RoomRepository :  IRoomRepository
    {
        private IDalRepository repository;
        private IHashService hashService;
        private IPositionService positionService;

        public RoomRepository(IDalRepository repository, IHashService service, IPositionService positionService)
        {
            this.repository = repository;
            this.hashService = service;
            this.positionService = positionService;
        }

        public async Task<IRoom> CreateRoom(string roomName)
        {
            var id = Guid.NewGuid();
            var hash = hashService.EncryptToBase64UrlEncoded(id.ToString());

            var room = new Room()
            {
                Id = id,
                LastUpdated = DateTime.UtcNow,
                Name = roomName,
                Created = DateTime.UtcNow,
                InviteHash = hash,
                InviteUrl = String.Concat(Constants.BASE_INVITE_URL, hash),
                Positions = new List<IPosition>() { }
            };

            var result =  await repository.CreateItemAsync(room);

            if (result == null)
                throw new Exception($"Room {roomName} cannot be created.");

            return room;
        }

        public async Task<IRoom> GetRoomAsync(string inviteToken)
        {
            var id = hashService.DecryptFromBase64UrlEncoded(inviteToken);
            var parsed = Guid.Parse(id);

            var result = await repository.GetItemById(parsed);
            var locations = result.Positions.Select(s => s.Location);

            result.CenterPoint = positionService.GetCenterPoint(locations);
    
            return result;
        }

        public async Task PutLocationAsync(User user, Location location)
        {
            var room = await GetRoomAsync(user.RoomInviteHash);

            if (room == null)
                throw new NotFoundException(room.InviteHash);

            var userPosition = room.Positions
                .SingleOrDefault(f => f.User.Id == user.Id);

            if (userPosition == null)
                room.Positions.Add(new Position(user, location));

            else
                userPosition = new Position(user, location);

            await repository.UpdateItemAsync(room);
        }
    }
}
