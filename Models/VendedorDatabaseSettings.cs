namespace pruebaSellnowapi.Models
{
    public class VendedorDatabaseSettings : IVendedorDatabaseSettings
    {
        public string VendedorCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IVendedorDatabaseSettings
    {
        string VendedorCollectionName { get; set; }

        string ConnectionString { get; set; }
        
        string DatabaseName { get; set; }
    }
}