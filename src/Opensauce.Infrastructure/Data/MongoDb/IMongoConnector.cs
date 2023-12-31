using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Opensauce.Infrastructure.Data.MongoDb
{
    public interface IMongoConnector
    {
        IMongoDatabase GetDatabase(string databaseName);
    }
}