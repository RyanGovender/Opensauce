using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opensauce.Infrastructure.Data.MongoDb
{
    public class ProgrammingLanguage : MongoModel
    {
        public required string Name 
        { 
            get; init; 
        }
    }
}