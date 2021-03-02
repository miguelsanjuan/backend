using pruebaSellnowapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace pruebaSellnowapi.Services
{
    public class cartListService
    {
        private readonly IMongoCollection<cartList> _carrito;

        public cartListService(IcartListDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carrito = database.GetCollection<cartList>(settings.CarritoCollectionName);
        }

        public List<cartList> Get() =>
            _carrito.Find(carrito => true).ToList();

        public cartList Get(string id) =>
            _carrito.Find<cartList>(carrito => carrito.Id == id).FirstOrDefault();


        public cartList Create(cartList carrito)
        {
            _carrito.InsertOne(carrito);
            return carrito;
        }

        public void Update(string id, cartList carritoIn) =>
            _carrito.ReplaceOne(carrito => carrito.Id == id, carritoIn);

        public void Remove(cartList carritoIn) =>
            _carrito.DeleteOne(carrito => carrito.Id == carritoIn.Id);

        public void Remove(string id) => 
            _carrito.DeleteOne(carrito => carrito.Id == id);

    }
}