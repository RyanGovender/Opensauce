using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Opensauce.Infrastructure.Data.MongoDb
{
    public abstract class MongoModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public required string Id
        {
            get;init;
        }
    }
}