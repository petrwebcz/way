using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Responses;
using WhereAreYou.Core.Exceptions;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Services;
using Microsoft.Extensions.Logging;
using WhereAreYou.Core.Extensions;

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

        public async Task<Meet> CreateMeetAsync(string meetName)
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
                Positions = new HashSet<UserPosition>(new PositionComparer()) //TODO: Try Use equals
            };

            var result = await repository.CreateItemAsync(meet);

            if (result == null)
                throw new Exception($"Meet {meetName} cannot be created.");

            return meet;
        }

        public async Task<Meet> GetMeetAsync(string inviteToken)
        {
            var id = hashService.DecryptFromBase64UrlEncoded(inviteToken);
            var parsed = Guid.Parse(id);
            var result = await repository.GetItemById(parsed);

            if (result == null)
                throw new NotFoundException($"Meet {inviteToken} not found");

            return result;
        }

        public async Task<MeetResponse> GetMeetAsync(string inviteToken, User currentUser)
        {
            var meet = await GetMeetAsync(inviteToken);
            positionService.Compute(meet.Positions, currentUser);

            var response = new MeetResponse()
            {
                Meet = meet,
                Adverts = positionService.AdvertsPositions,
                CenterPoint = positionService.CenterPoint,
                CurrentUser = positionService.CurrentUserPosition,
                ZoomLevel = 17, //TODO: Compute value in position service
                Users = positionService.UsersPositions
            };

            return response;
        }

        public async Task<IEnumerable<Meet>> GetMeetsAsync()
        {
            var meets = await repository.GetItemsAsync();

            var result = meets.OrderBy(o => o.Created);

            return result;
        }

        public async Task AddLocationAsync(User user, Location location)
        {
            var meet = await GetMeetAsync(user.MeetInviteHash);

            if (meet == null)
                throw new NotFoundException(meet.InviteHash);

            var userPosition = new UserPosition(user, location);
            meet.Positions.Add(userPosition);

            await repository.UpdateItemAsync(meet);
        }

        public async Task UpdateLocationAsync(User user, Location location)
        {
            var meet = await GetMeetAsync(user.MeetInviteHash);

            if (meet == null)
                throw new NotFoundException(meet.InviteHash);

            var userPosition = meet.Positions
                .SingleOrDefault(f => f.User.Id == user.Id);

            if (userPosition == null)
                throw new Exception("User cannot have initialized position");

            userPosition.Location = location;

            await repository.UpdateItemAsync(meet);
        }
    }
}
