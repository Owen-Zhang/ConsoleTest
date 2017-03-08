/*
using MongoDB.Bson;
//using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;

namespace Test.MongoDb
{
    public class MongoDbManager
    {
        public void TestMongo()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("mydb");
            var collection = database.GetCollection<MongoModel>("users");
            var newUser = 
            new MongoModel
                {
                    name = "huige",
                    age = 32
                };
            collection.InsertOne(newUser);
            Console.WriteLine(newUser.id);

            var builder = MongoDB.Driver.Builders<MongoModel>.Filter;
            var filter = builder.Eq("age", 32) & builder.Eq("home", "chengdu");

            var result = collection.Find(filter).ToList();
        }
    }
}
*/