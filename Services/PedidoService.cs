using pruebaSellnowapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace pruebaSellnowapi.Services
{
    public class PedidoService
    {
        private readonly IMongoCollection<Pedido> _pedido;

        public PedidoService(IPedidoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pedido = database.GetCollection<Pedido>(settings.PedidoCollectionName);
        }

        public List<Pedido> Get() =>
            _pedido.Find(pedido => true).ToList();

        public Pedido Get(string id) =>
            _pedido.Find<Pedido>(pedido =>pedido.Id == id).FirstOrDefault();

        public Pedido Create(Pedido pedido)
        {
            _pedido.InsertOne(pedido);
            return pedido;
        }

        public void Update(string id, Pedido pedidoIn) =>
            _pedido.ReplaceOne(pedido =>pedido.Id == id,pedidoIn);

        public void Remove(Pedido pedidoIn) =>
            _pedido.DeleteOne(pedido =>pedido.Id ==pedidoIn.Id);

        public void Remove(string id) => 
            _pedido.DeleteOne(pedido =>pedido.Id == id);
    }
}