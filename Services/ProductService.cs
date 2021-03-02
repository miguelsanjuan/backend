using pruebaSellnowapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace pruebaSellnowapi.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Productos> _productos;

        public ProductService(IProductosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _productos = database.GetCollection<Productos>(settings.ProductosCollectionName);
        }

        public List<Productos> Get() =>
            _productos.Find(producto => true).ToList();

        public Productos Get(int product_id) =>
            _productos.Find<Productos>(producto => producto.productID.Equals(product_id)).FirstOrDefault();

        public Productos Create(Productos producto)
        {
            _productos.InsertOne(producto);
            return producto;
        }

        public void Update(string id, Productos productoIn) =>
            _productos.ReplaceOne(producto => producto.Id == id, productoIn);

        public void Remove(Productos productoIn) =>
            _productos.DeleteOne(producto => producto.Id == productoIn.Id);

        public void Remove(string id) => 
            _productos.DeleteOne(producto => producto.Id == id);

        internal void Update(int product_id, Productos productoIn)
        {
            throw new NotImplementedException();
        }
    }
}