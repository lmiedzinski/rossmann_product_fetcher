using ProductFetcherApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductFetcherApi.RabbitmqUtils
{
    public class SendMessageHandler : IHandler<SendMessage>
    {
        private readonly IProductRepository _productRepository;

        public SendMessageHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task HandleAsync(SendMessage @event, CancellationToken token)
        {
            Console.WriteLine($"Receive: {@event.Data}");
            await _productRepository.AddProduct(@event.Data.ToString());
            return;
        }
    }
}
