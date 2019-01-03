using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFetcherApi.Repositories
{
    public interface IProductRepository
    {
        Task<BsonDocument> GetProductById(int id);
        Task<BsonDocument> AddProduct(string productData);
    }
}
