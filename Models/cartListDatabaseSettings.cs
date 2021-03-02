namespace pruebaSellnowapi.Models
{
    public class cartListDatabaseSettings : IcartListDatabaseSettings
    {
        public string CarritoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IcartListDatabaseSettings
    {
        string CarritoCollectionName { get; set; }

        string ConnectionString { get; set; }
        
        string DatabaseName { get; set; }
    }
}