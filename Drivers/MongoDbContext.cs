using database_trade_study.Models;
using MongoDB.Driver;

namespace MongoDB{

    public class MongoDbContext{
        private readonly IMongoDatabase _database;
        public MongoDbContext(string connectionString){
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("mongo");
        }

         public IMongoCollection<MockData> YourEntities => _database.GetCollection<MockData>("mock");
    }
}