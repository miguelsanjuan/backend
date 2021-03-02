using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace pruebaSellnowapi.Models
{
    public class Vendedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; private set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string direccion { get; set; }

        public double valoracion { get; set; }

        public string alias { get; set; }

        public string email { get; set; }

        public decimal telefono { get; set; }

        public string password { get; set; }
    }
}