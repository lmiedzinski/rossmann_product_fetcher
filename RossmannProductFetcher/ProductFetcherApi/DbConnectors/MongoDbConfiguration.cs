using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFetcherApi.DbConnectors
{
    public class MongoDbCredentials
    {
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
    public class MongoDbConfiguration
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public MongoDbCredentials Credentials { get; set; }
    }
}
