using pruebaSellnowapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace pruebaSellnowapi.Services
{
    public class VendedorService
    {
        private readonly IMongoCollection<Vendedor> _vendedores;

        public VendedorService(IVendedorDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _vendedores = database.GetCollection<Vendedor>(settings.VendedorCollectionName);
        }

        public List<Vendedor> Get() =>
            _vendedores.Find(vendedor => true).ToList();

        public Vendedor Get(string id) =>
            _vendedores.Find<Vendedor>(vendedor => vendedor.Id == id).FirstOrDefault();

        public List<Vendedor> GetIniciarSesion(string email,string password) =>
            _vendedores.Find<Vendedor>(vendedor => vendedor.email.Equals(email) 
            && vendedor.password.Equals(password)).ToList();

        public Vendedor Create(Vendedor vendedor)
        {
            _vendedores.InsertOne(vendedor);
            return vendedor;
        }

        public void Update(string id, Vendedor vendedorIn) =>
            _vendedores.ReplaceOne(vendedor => vendedor.Id == id, vendedorIn);

        public void Remove(Vendedor vendedorIn) =>
            _vendedores.DeleteOne(vendedor => vendedor.Id == vendedorIn.Id);

        public void Remove(string id) => 
            _vendedores.DeleteOne(vendedor => vendedor.Id == id);
    }
}