namespace pruebaSellnowapi.Models
{
    public class ClientesDatabaseSettings : IClientesDatabaseSettings
    {
        public string ClientesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IClientesDatabaseSettings
    {
        string ClientesCollectionName { get; set; }

        string ConnectionString { get; set; }
        
        string DatabaseName { get; set; }
    }
}