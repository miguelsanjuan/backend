using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace pruebaSellnowapi.Models
{
    public class Pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; private set; }

        public int cliente_id { get; set; }


        public int product_id { get; set; }


        public int total { get; set; }

        public string direccion { get; set; }

        public string fecha { get; set; }

        public string num_envio { get; set; }

        public int pago_id { get; set; }

        public bool orderstatus { get; set; }

        public string orderTitle { get; set; }

        public string orderDescription { get; set; }






    }
}