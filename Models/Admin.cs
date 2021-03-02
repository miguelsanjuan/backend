using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace pruebaSellnowapi.Models
{
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; private set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string correo { get; set; }

        public string telefono { get; set; }

        public string password { get; set; }

    }
}