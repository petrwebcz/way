using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Extensions;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Services;
using WhereAreYou.Core.Utils;
using WhereAreYou.DAL.Repository;

namespace WhereAreYou.DAL.Test
{
    [TestClass]
    public class MeetRepositoryTest
    {
        IServiceCollection ServiceCollection { get; set; }
        IServiceProvider ServiceProvider { get; set; }

        public MeetRepositoryTest()
        {
            this.ServiceCollection = new ServiceCollection();
            this.ServiceCollection.AddTransient<IDalRepository, InMemoryDbRepository>();
            this.ServiceCollection.AddTransient<IHashService, AesService>(c => new AesService());
            this.ServiceCollection.AddTransient<IMeetRepository, MeetRepository>();

            this.ServiceCollection.AddTransient<IPositionService, PositionService>();
            this.ServiceCollection.AddSingleton<IAppSettings>(new AppSettings());
            this.ServiceProvider = ServiceCollection.BuildServiceProvider();
        }

        [TestMethod]
        public async Task CreateMeetTest()
        {
            var repository = ServiceProvider.GetService<IMeetRepository>();
            var meet = await repository.CreateMeetAsync("My first MEET in WAY");

            Assert.IsNotNull(meet);
        }

        [TestMethod]
        public async Task GetMeets()
        {
            var repository = ServiceProvider.GetService<IMeetRepository>();

            var meet1 = await repository.CreateMeetAsync("Bulk test MEET in WAY 1");
            var meet2 = await repository.CreateMeetAsync("Bulk test MEET in WAY 2");
            var load = await repository.GetMeetsAsync();

            var count = load
                .Where(w => w.Id == meet1.Id || w.Id == meet2.Id)
                .Count();

            Assert.IsTrue(count == 2);
        }

        [TestMethod]
        public async Task GetByInviteLinkTest()
        {
            var repository = ServiceProvider.GetService<IMeetRepository>();

            var meet = await repository.CreateMeetAsync("My first MEET in WAY");
            var load = await repository.GetMeetAsync(meet.InviteHash);

            Assert.IsNotNull(meet.Name);
            Assert.AreEqual(meet.InviteHash, load.InviteHash);
        }

        [TestMethod]
        public async Task GetByInviteLinkWithUserTest()
        {
            var repository = ServiceProvider.GetService<IMeetRepository>();
            var meet = await repository.CreateMeetAsync("My first MEET in WAY");
            var user = User.Create("TestUser", meet.InviteHash);
            var location = new Location(10, 10);

            await repository.AddLocationAsync(user, location);
            await repository.UpdateLocationAsync(user, location);
            var load = await repository.GetMeetAsync(meet.InviteHash, user);

            Assert.IsNotNull(load);
            Assert.AreEqual(meet.InviteHash, load.Meet.InviteHash);
        }

        [TestMethod]
        public async Task AddLocationAsyncTest()
        {
            var repository = ServiceProvider.GetService<IMeetRepository>();
            var meet = await repository.CreateMeetAsync("My first MEET in WAY");

            var userId = Guid.NewGuid();
            var user = User.Create("Petr Svoboda", meet.InviteHash);

            var location = new Location(10, 10);

            await repository.AddLocationAsync(user, location);
            var load = await repository.GetMeetAsync(meet.InviteHash);

            var condition = load.Positions.GetUserPositions().Any(a => a.User.Nickname == "Petr Svoboda" && a.Location.Latitude == 10 && a.Location.Longitude == 10);
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public async Task UpdateLocationAsyncTest()
        {
            var repository = ServiceProvider.GetService<IMeetRepository>();
            var meet = await repository.CreateMeetAsync("My first MEET in WAY");

            var userId = Guid.NewGuid();
            var user = User.Create("Petr Svoboda", meet.InviteHash);

            var location = new Location(10, 10);
            var newPosition = new Location(10, 20);

            await repository.AddLocationAsync(user, location);
            await repository.UpdateLocationAsync(user, newPosition);
            var load = await repository.GetMeetAsync(meet.InviteHash);

            var condition = load.Positions.GetUserPositions().Any(a => a.User.Nickname == "Petr Svoboda" && a.Location.Latitude == newPosition.Latitude && a.Location.Longitude == newPosition.Longitude);
            Assert.IsTrue(condition);
        }
    }
}
