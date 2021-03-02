using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaSellnowapi.Models
{
    public class sellerLocationDatabaseSettings
    {
        
            public string sellerLocationCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface IsellerLocationDatabaseSettings
    {
            string sellerLocationCollectionName { get; set; }

            string ConnectionString { get; set; }

            string DatabaseName { get; set; }
        }
    }

