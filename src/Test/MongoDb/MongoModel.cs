using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.MongoDb
{
    public class MongoModel
    {
        public ObjectId id { get; set; } 
        public string name { get; set; }
        public int age { get; set; }

        public string home { get; set; }
    }
}
