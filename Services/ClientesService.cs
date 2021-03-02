using pruebaSellnowapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace pruebaSellnowapi.Services
{
    public class ClientesService
    {
        private readonly IMongoCollection<Clientes> _clientes;

        public ClientesService(IClientesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _clientes = database.GetCollection<Clientes>(settings.ClientesCollectionName);
        }

        public List<Clientes> Get() =>
            _clientes.Find(cliente => true).ToList();

        public Clientes Get(string id) =>
            _clientes.Find<Clientes>(cliente => cliente.Id == id).FirstOrDefault();

        public List<Clientes> GetIniciarSesion(string email,string password) =>
            _clientes.Find<Clientes>(cliente => cliente.userEmail.Equals(email) && cliente.userPassword.Equals(password)).ToList();

        public Clientes Create(Clientes cliente)
        {
            _clientes.InsertOne(cliente);
            return cliente;
        }

        public void Update(string id, Clientes clienteIn) =>
            _clientes.ReplaceOne(cliente => cliente.Id == id, clienteIn);

        public void Remove(Clientes clienteIn) =>
            _clientes.DeleteOne(cliente => cliente.Id == clienteIn.Id);

        public void Remove(string id) => 
            _clientes.DeleteOne(cliente => cliente.Id == id);

    }
}