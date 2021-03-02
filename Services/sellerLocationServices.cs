using pruebaSellnowapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace pruebaSellnowapi.Services
{
    public class sellerLocationService
    {
        private readonly IMongoCollection<sellerLocation> _location;

        public sellerLocationService(IsellerLocationDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _location = database.GetCollection<sellerLocation>(settings.sellerLocationCollectionName);
        }

        public List<sellerLocation> Get() =>
            _location.Find(location => true).ToList();

        public sellerLocation Get(string id) =>
            _location.Find<sellerLocation>(location => location.Id == id).FirstOrDefault();

        public sellerLocation Create(sellerLocation location)
        {
            _location.InsertOne(location);
            return location;
        }

        public void Update(string id, sellerLocation locationIn) =>
            _location.ReplaceOne(location => location.Id == id, locationIn);

        public void Remove(sellerLocation locationIn) =>
            _location.DeleteOne(location => location.Id == locationIn.Id);

        public void Remove(string id) =>
            _location.DeleteOne(location => location.Id == id);
    }
}