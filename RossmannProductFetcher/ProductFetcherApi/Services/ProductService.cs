using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProductFetcherApi.Managers;
using ProductFetcherApi.RabbitmqUtils;
using ProductFetcherApi.Repositories;
using RawRabbit;

namespace ProductFetcherApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BsonDocument> GetProductById(int id)
        {
            BsonDocument product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                RabbitmqManager.PublishToQueue(id);
            }
            return product;
        }
    }
}
