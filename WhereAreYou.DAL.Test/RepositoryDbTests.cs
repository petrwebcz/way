using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Utils;
using WhereAreYou.DAL.Repository;
using System.Linq;
using WhereAreYou.Core.Configuration;

namespace WhereAreYou.DAL.Test
{
    [TestClass]
    public class CosmoDbRepositoryTests
    {
        IServiceCollection ServiceCollection { get; set; }
        IServiceProvider ServiceProvider { get; set; }

        public CosmoDbRepositoryTests()
        {
            this.ServiceCollection = new ServiceCollection();
            this.ServiceCollection.AddTransient<IDalRepository, InMemoryDbRepository>();
            this.ServiceCollection.AddTransient<IHashService, AesService>();
         
            this.ServiceCollection.AddTransient<IPositionService, PositionService>();
            this.ServiceCollection.AddSingleton<IAppSettings>(new AppSettings());
            ServiceProvider = this.ServiceCollection.BuildServiceProvider();
        }

        [TestMethod]
        public async Task CreateItemAsyncTest()
        {
            var repository = ServiceProvider.GetService<IDalRepository>();

            await repository.CreateItemAsync(new Room()
            {
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                Name = "Testovací místnost",
            });

            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task GetItemAsyncTest()
        {
            var repository = ServiceProvider.GetService<IDalRepository>();

            await repository.CreateItemAsync(new Room()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                Name = "Testovací místnost",
            });

            var result = await repository.GetItemsAsync();
            
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task UpdateItemAsyncTest()
        {
            const string ROOM_NAME  = "Testovací místnost 2";
            Guid ROOM_GUID = Guid.NewGuid();

            var repository = ServiceProvider.GetService<IDalRepository>();

            await repository.CreateItemAsync(new Room()
            {
                Id = ROOM_GUID,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                Name = "Testovací místnost",
            });

            await repository.UpdateItemAsync(new Room()
            {
                Id = ROOM_GUID,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                Name = ROOM_NAME
            });

            var result = await repository.GetItemsAsync();

            Assert.IsTrue(result.Any(a=>a.Name== ROOM_NAME));
        }

        [TestMethod]
        public async Task GetItemByIdAsyncTest()
        {
            const string ROOM_NAME = "Testovací místnost 3";

            var repository = ServiceProvider.GetService<IDalRepository>();

            var res = await repository.CreateItemAsync(new Room()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                Name = ROOM_NAME
            });

            var result = await repository.GetItemById(res.Id);

            Assert.IsTrue(result.Name == ROOM_NAME);
        }
    }
}




