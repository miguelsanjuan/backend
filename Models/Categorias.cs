using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace pruebaSellnowapi.Models
{
    public class Categorias
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; private set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public string imagen { get; set; }
      
    }
}