using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace pruebaSellnowapi.Models
{
    public class Productos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; private set; }

        public int productID { get; set; }

        public int categoryID { get; set; }

        public string productName { get; set; }

        public string productDescription { get; set; }

        public string supplier { get; set; }

        public int unitPrice { get; set; }

        public string color { get; set; }

        public string productURLPicture { get; set; }

        public int productDiscount { get; set; }

        public bool productAvailable { get; set; }
    }
}
