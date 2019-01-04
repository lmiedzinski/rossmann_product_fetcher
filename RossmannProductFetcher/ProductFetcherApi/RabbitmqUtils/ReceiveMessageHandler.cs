using ProductFetcherApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductFetcherApi.RabbitmqUtils
{
    public class ReceiveMessageHandler : IHandler<ReceiveMessage>
    {
        private readonly IProductRepository _productRepository;

        public ReceiveMessageHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task HandleAsync(ReceiveMessage @event, CancellationToken token)
        {
            if (@event != null)
            {
                Console.WriteLine($"Receive: {@event.Data}");
                await _productRepository.AddProduct(@event.Data.ToString());
            }
            return;
        }
    }
}
