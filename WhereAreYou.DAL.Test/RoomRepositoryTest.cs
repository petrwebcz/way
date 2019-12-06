using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Utils;
using WhereAreYou.DAL.Repository;

namespace WhereAreYou.DAL.Test
{
    [TestClass]
    public class RoomRepositoryTest
    {
        IServiceCollection ServiceCollection { get; set; }
        IServiceProvider ServiceProvider { get; set; }

        public RoomRepositoryTest()
        {
            this.ServiceCollection = new ServiceCollection();

            this.ServiceCollection.AddTransient<IDalRepository, InMemoryDbRepository>();
            this.ServiceCollection.AddTransient<IHashService, AesService>(c=>new AesService());
            this.ServiceCollection.AddTransient<IRoomRepository, RoomRepository>();
            this.ServiceCollection.AddTransient<IPositionService, PositionService>();

            this.ServiceProvider = ServiceCollection.BuildServiceProvider();
        }

        [TestMethod]
        public async Task CreateRoomTest()
        {
            var repository = ServiceProvider.GetService<IRoomRepository>();
            var room = await repository.CreateRoom("My first ROOM in WAY");
            
            Assert.IsNotNull(room);
        }

        [TestMethod]
        public async Task GetByInviteLinkTest()
        {
            var repository = ServiceProvider.GetService<IRoomRepository>();

            var room = await repository.CreateRoom("My first ROOM in WAY");
            var load = await repository.GetRoomAsync(room.InviteHash);

            Assert.IsNotNull(room.Name);
            Assert.AreEqual(room.InviteHash, load.InviteHash);
        }

        [TestMethod]
        public async Task PutLocationAsyncTest()
        {
            var repository = ServiceProvider.GetService<IRoomRepository>();
            var room = await repository.CreateRoom("My first ROOM in WAY");
            
            var userId = Guid.NewGuid();
            var user = new User(userId, "Petr Svoboda", room.InviteHash);
           
            var location = new Location(10, 10);
           
            await repository.PutLocationAsync(user, location);
            var load = await repository.GetRoomAsync(room.InviteHash);

            var condition = load.Positions.Any(a => a.User.Nickname == "Petr Svoboda" && a.Location.Latitude == 10 && a.Location.Longitude == 10);
            Assert.IsTrue(condition);
        }
    }
}
