using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Opensauce.Infrastructure.Data.MongoDb.Models;

namespace Opensauce.Infrastructure.Data.MongoDb
{
    public class MongoBase : IMongoBase
    {
        private readonly IMongoConnector _client;
        public required string DatabaseName{
            get;set;
        }
        public MongoBase(IMongoConnector mongoConnector)
        {
            _client = mongoConnector;
        }

        public Task InsertDataAsync<T>(string collectionName, T data) where T : class
        {
            var collection = _client.GetDatabase(Database.OpensauceDB).GetCollection<T>(collectionName);
            return collection.InsertOneAsync(data);
                
        }

         public IEnumerable<T> FindData<T>(string collectionName, FilterDefinition<T>? filter = null) where T : class
        {
            var collection = _client.GetDatabase(Database.OpensauceDB).GetCollection<T>(collectionName);
            var results = filter == null ? collection.Find(_ => true) : collection.Find(filter);
            return results?.ToList() ?? new List<T>();
        }
    }
}