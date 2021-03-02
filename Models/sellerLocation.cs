using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaSellnowapi.Models
{
    public class sellerLocation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; private set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        public string sellerURLPicture { get; set; }

        public double sellerName { get; set; }

    }
}
