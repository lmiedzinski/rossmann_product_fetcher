using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ProductFetcherApi.DbConnectors;

namespace ProductFetcherApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private const string PRODUCTS_COLLECTION_NAME = "products";
        private readonly IMongoCollection<BsonDocument> _products;

        public ProductRepository(MongoDbConnector mongoDbConnector)
        {
            _products = mongoDbConnector.Database.GetCollection<BsonDocument>(PRODUCTS_COLLECTION_NAME);
        }

        public async Task<BsonDocument> AddProduct(string productData)
        {
            var document = BsonSerializer.Deserialize<BsonDocument>(productData);
            await _products.InsertOneAsync(document);
            return document;
        }

        public async Task<BsonDocument> GetProductById(int id)
        {
            return await _products.Find(new BsonDocument("id", id)).FirstOrDefaultAsync();
        }
    }
}
