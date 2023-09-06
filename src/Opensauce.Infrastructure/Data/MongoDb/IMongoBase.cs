using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Opensauce.Infrastructure.Data.MongoDb
{
    public interface IMongoBase
    {
        string DatabaseName
        {
            get;set;
        }
        Task InsertDataAsync<T>(string collectionName, T data) where T : class;
        IEnumerable<T> FindData<T>(string collectionName, FilterDefinition<T>? filter = null) where T : class;
    }
}