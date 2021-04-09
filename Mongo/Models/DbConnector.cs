using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo
{
    public class DbConnector
    {
        private IMongoCollection<BsonDocument> collection;
        
        public DbConnector()
        {
            var dbClient = new MongoClient(Environment.GetEnvironmentVariable("MongoDBConnectionString"));
            var database = dbClient.GetDatabase("caprsa");
            collection = database.GetCollection<BsonDocument>("keys");
        }

        public void Insert(EncryptedItem item)
        {
            collection.InsertOne(new BsonDocument
            {
                {"text", item.Text},
                {"privateKey", item.PrivateKey},
                {"alias", item.Alias}
            });
        }

        public List<EncryptedItem> FindAll()
        {
            return collection.Find(new BsonDocument()).ToEnumerable().Select(x => new EncryptedItem(x["text"].ToString(), x["privateKey"].ToString(), x["alias"].ToString())).ToList();
        }

        public void Remove(EncryptedItem item)
        {
            collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("text", item.Text));
        }
    }
}