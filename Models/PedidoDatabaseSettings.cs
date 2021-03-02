namespace pruebaSellnowapi.Models
{
    public class PedidoDatabaseSettings : IPedidoDatabaseSettings
    {
        public string PedidoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPedidoDatabaseSettings
    {
        string PedidoCollectionName { get; set; }

        string ConnectionString { get; set; }
        
        string DatabaseName { get; set; }
    }
}