using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Opensauce.Infrastructure.Data.MongoDb
{
    public class MongoDBConnector : IMongoConnector
    {
        private readonly MongoClient _client;
        private readonly IConfiguration _config;

        public MongoDBConnector(IConfiguration config)
        {
            _config = config;
            var settings = MongoClientSettings.FromConnectionString(_config["MongoDb:ConnectionString"]);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _client = new MongoClient(settings);
        }
        
        public IMongoDatabase GetDatabase(string databaseName)
        {
            return _client.GetDatabase(databaseName);
        }
    }
}