namespace pruebaSellnowapi.Models
{
    public class ProductosDatabaseSettings : IProductosDatabaseSettings
    {
        public string ProductosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProductosDatabaseSettings
    {
        string ProductosCollectionName { get; set; }

        string ConnectionString { get; set; }
        
        string DatabaseName { get; set; }
    }
}