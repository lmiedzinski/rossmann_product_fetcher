using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFetcherApi.DbConnectors
{
    public class MongoDbConnector
    {
        public MongoDbConnector(MongoDbConfiguration config)
        {
            Client = new MongoClient(new MongoClientSettings
            {
                Server = MongoServerAddress.Parse(config.Server),
                Credential = MongoCredential.CreateCredential(config.Credentials.Database, config.Credentials.User, config.Credentials.Password),
                UseSsl = false,
                VerifySslCertificate = false,
                SslSettings = new SslSettings
                {
                    CheckCertificateRevocation = false
                }
            });

            Database = Client.GetDatabase(config.Database);
        }

        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; set; }
    }
}
