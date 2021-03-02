using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace pruebaSellnowapi.Models
{
    public class Clientes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; private set; }

        public int cliente_id { get; set; }

        public string userName { get; set; }

        public string userLast { get; set; }

        public string userEmail { get; set; }

        public string userPassword { get; set; }

        public int userCellphone { get; set; }

        public string direccion { get; set; }


    }
}