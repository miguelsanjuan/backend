using pruebaSellnowapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace pruebaSellnowapi.Services
{
    public class AdminService
    {
        private readonly IMongoCollection<Admin> _admin;

        public AdminService(IAdminDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _admin = database.GetCollection<Admin>(settings.AdminCollectionName);
        }

        public List<Admin> Get() =>
            _admin.Find(admin => true).ToList();

        public Admin Get(string id) =>
            _admin.Find<Admin>(admin => admin.Id == id).FirstOrDefault();

        public List<Admin> GetIniciarSesion(string correo,string password) =>
            _admin.Find<Admin>(admin => admin.correo.Equals(correo) 
            && admin.password.Equals(password)).ToList();

        public Admin Create(Admin admin)
        {
            _admin.InsertOne(admin);
            return admin;
        }

        public void Update(string id, Admin adminIn) =>
            _admin.ReplaceOne(admin => admin.Id == id, adminIn);

        public void Remove(Admin adminIn) =>
            _admin.DeleteOne(admin => admin.Id == adminIn.Id);

        public void Remove(string id) => 
            _admin.DeleteOne(admin => admin.Id == id);

    }
}