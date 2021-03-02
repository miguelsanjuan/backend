using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace pruebaSellnowapi.Models
{
    public class cartList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; private set; }

        public int productID { get; set; }

        public string userEmail { get; set; }

        public string productName { get; set; }

        public string productDescription { get; set; }

        public int unitPrice { get; set; }

        public int quantity { get; set; }

        public string productURLPicture { get; set; }

      
    }
}