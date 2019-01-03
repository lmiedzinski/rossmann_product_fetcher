using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProductFetcherApi.RabbitmqUtils;
using ProductFetcherApi.Repositories;
using RawRabbit;

namespace ProductFetcherApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBusClient _busClient;

        public ProductService(IProductRepository productRepository, IBusClient busClient)
        {
            _productRepository = productRepository;
            _busClient = busClient;
        }

        public async Task<BsonDocument> GetProductById(int id)
        {
            BsonDocument product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                await _busClient.PublishAsync(new SendMessage(id.ToString()));
            }
            return product;
        }
    }
}
