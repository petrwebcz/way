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
    public class MeetRepository : IMeetRepository
    {
        private IDalRepository repository;
        private IHashService hashService;
        private IPositionService positionService;
        private IAppSettings appSettings;

        public MeetRepository(IDalRepository repository, IHashService service, IPositionService positionService, IAppSettings appSettings)
        {
            this.repository = repository;
            this.hashService = service;
            this.positionService = positionService;
            this.appSettings = appSettings;
        }

        public async Task<IMeet> CreateMeetAsync(string meetName)
        {
            var id = Guid.NewGuid();
            var hash = hashService.EncryptToBase64UrlEncoded(id.ToString());

            var meet = new Meet()
            {
                Id = id,
                LastUpdated = DateTime.UtcNow,
                Name = meetName,
                Created = DateTime.UtcNow,
                InviteHash = hash,
                InviteUrl = String.Concat(appSettings.BaseInviteUrl, hash),
                Positions = new HashSet<IPosition>(new PositionComparer()) { }
            };

            var result = await repository.CreateItemAsync(meet);

            if (result == null)
                throw new Exception($"Meet {meetName} cannot be created.");

            return meet;
        }

        public async Task<IMeet> GetMeetAsync(string inviteToken)
        {
            var id = hashService.DecryptFromBase64UrlEncoded(inviteToken);
            var parsed = Guid.Parse(id);

            var result = await repository.GetItemById(parsed);
            var locations = result.Positions.Select(s => s.Location);

            result.CenterPoint = positionService.GetCenterPoint(locations);
            return result;
        }

        public async Task<IEnumerable<IMeet>> GetMeetsAsync()
        {
            var result = await repository.GetItemsAsync();
            return result;
        }

        public async Task AddLocationAsync(User user, Location location)
        {
            var meet = await GetMeetAsync(user.MeetInviteHash);

            if (meet == null)
                throw new NotFoundException(meet.InviteHash);

            var userPosition = new Position(user, location);
            meet.Positions.Add(userPosition);

            await repository.UpdateItemAsync(meet);
        }


        public async Task UpdateLocationAsync(User user, Location location)
        {
            var meet = await GetMeetAsync(user.MeetInviteHash);

            if (meet == null)
                throw new NotFoundException(meet.InviteHash);

            var userPosition = meet.Positions.Single(f => f.User.Id == user.Id);
            userPosition.Location = location;

            await repository.UpdateItemAsync(meet);
        }
    }
}
