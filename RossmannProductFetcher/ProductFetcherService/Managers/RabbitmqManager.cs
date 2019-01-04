using ProductFetcherService.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFetcherService.Managers
{
    public static class RabbitmqManager
    {
        private const string RABBITMQ_HOSTNAME = "rabbit";
        private const string LISTEN_QUEUE_NAME = "GetProductById";
        private const string PUBLISH_QUEUE_NAME = "ProductFetched_/app/productfetcherapi";
        private const string PUBLISH_EXCHANGE_NAME = "";
        public static void ListenToQueue()
        {
            var factory = new ConnectionFactory() { HostName = RABBITMQ_HOSTNAME };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: LISTEN_QUEUE_NAME,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                //channel.QueueDeclare(queue: PUBLISH_QUEUE_NAME,
                //                     durable: false,
                //                     exclusive: false,
                //                     autoDelete: false,
                //                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received: {0}", message);
                    IProductService productService = new ProductService();
                    if (int.TryParse(message, out int productId))
                    {
                        string productData = productService.GetProductById(productId);
                        var publishBody = Encoding.UTF8.GetBytes(productData);
                        channel.BasicPublish(exchange: PUBLISH_EXCHANGE_NAME,
                                             routingKey: PUBLISH_QUEUE_NAME,
                                             basicProperties: null,
                                             body: publishBody);
                        Console.WriteLine("Sent {0}", productData);
                    }
                };
                channel.BasicConsume(queue: LISTEN_QUEUE_NAME,
                                     autoAck: true,
                                     consumer: consumer);
                Console.WriteLine("Started receiving");
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }
    }
}
