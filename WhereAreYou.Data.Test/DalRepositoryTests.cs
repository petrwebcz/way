using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Utils;
using WhereAreYou.DAL.Repository;
using System.Linq;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Services;

namespace WhereAreYou.DAL.Test
{
    [TestClass]
    public class DalRepositoryTests
    {
        IServiceCollection ServiceCollection { get; set; }
        IServiceProvider ServiceProvider { get; set; }

        public DalRepositoryTests()
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

            await repository.CreateItemAsync(new Meet()
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

            await repository.CreateItemAsync(new Meet()
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
            const string MEET_NAME_ORIGIN  = "Testovací místnost";
            const string MEET_NAME_UPDATED = "Testovací místnost 2";
            Guid MEET_GUID = Guid.NewGuid();

            var repository = ServiceProvider.GetService<IDalRepository>();

            await repository.CreateItemAsync(new Meet()
            {
                Id = MEET_GUID,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                Name =  MEET_NAME_ORIGIN,
            });

            await repository.UpdateItemAsync(new Meet()
            {
                Id = MEET_GUID,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                Name = MEET_NAME_UPDATED
            });

            var result = await repository.GetItemsAsync();

            Assert.IsTrue(result.Any(a=>a.Name== MEET_NAME_UPDATED));
        }

        [TestMethod]
        public async Task GetItemByIdAsyncTest()
        {
            const string MEET_NAME = "Testovací místnost 3";

            var repository = ServiceProvider.GetService<IDalRepository>();

            var res = await repository.CreateItemAsync(new Meet()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                Name = MEET_NAME
            });

            var result = await repository.GetItemById(res.Id);

            Assert.IsTrue(result.Name == MEET_NAME);
        }
    }
}