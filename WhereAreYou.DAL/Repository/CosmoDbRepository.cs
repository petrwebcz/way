using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.DAL.Repository
{
    public class CosmosDbRepository : IDalRepository
    {
        private IDocumentClient client;
        private IAppSettings settings;

        public CosmosDbRepository(IAppSettings settings)
        {
            client = new DocumentClient(
                         new Uri(settings.CosmosEndpoint),
                         settings.EmulatorKey,
                         new ConnectionPolicy
                         {
                             ConnectionMode = ConnectionMode.Direct,
                             ConnectionProtocol = Protocol.Tcp
                         });
        }

        public async Task<IEnumerable<IRoom>> GetItemsAsync()
        {
            var request = UriFactory.CreateDocumentCollectionUri(settings.DatabaseId, settings.CollectionId);

            IDocumentQuery<IRoom> query = client.CreateDocumentQuery<IRoom>(request)
                .AsDocumentQuery();

            List<IRoom> results = new List<IRoom>();

            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<IRoom>());
            }

            return results;
        }

        public async Task<IWay> CreateItemAsync(IRoom item)
        {
            var request = UriFactory.CreateDocumentCollectionUri(settings.DatabaseId, settings.CollectionId);
            var result = await client.CreateDocumentAsync(request, item);
            var document = result.Resource;

            return document.ToWay();
        }

        public async Task<IWay> UpdateItemAsync(IRoom item)
        {
            var request = UriFactory.CreateDocumentUri(settings.DatabaseId, settings.CollectionId, item.Id.ToString());
            var result = await client.ReplaceDocumentAsync(request, item);
            var document = result.Resource;

            return document.ToWay();
        }

        public async Task<IRoom> GetItemById(Guid id)
        {
            var request = UriFactory.CreateDocumentUri(settings.DatabaseId, settings.CollectionId, id.ToString());
            var result = await client.ReadDocumentAsync<IRoom>(request);
            var document = result.Document;

            return document;
        }

        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(settings.DatabaseId));
            }

            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = settings.DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }
        private async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                var url = UriFactory.CreateDocumentCollectionUri(settings.DatabaseId, settings.CollectionId);
                await client.ReadDocumentCollectionAsync(url);
            }

            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var url = UriFactory.CreateDatabaseUri(settings.DatabaseId);

                    await client.CreateDocumentCollectionAsync(url,
                        new DocumentCollection { Id = settings.CollectionId },
                        new RequestOptions { OfferThroughput = 1000 });
                }

                else
                {
                    throw;
                }
            }
        }
    }
}


