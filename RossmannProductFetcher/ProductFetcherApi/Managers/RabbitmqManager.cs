using RabbitMQ.Client;
using System;
using System.Text;

namespace ProductFetcherApi.Managers
{
    public static class RabbitmqManager
    {
        private const string RABBITMQ_HOSTNAME = "rabbit";
        private const string PUBLISH_QUEUE_NAME = "GetProductById";
        public static void PublishToQueue(int id)
        {
            var factory = new ConnectionFactory() { HostName = RABBITMQ_HOSTNAME };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: PUBLISH_QUEUE_NAME,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var publishBody = Encoding.UTF8.GetBytes(id.ToString());
                channel.BasicPublish(exchange: "",
                                     routingKey: PUBLISH_QUEUE_NAME,
                                     basicProperties: null,
                                     body: publishBody);
                Console.WriteLine("Sent {0}", id.ToString());
            }
        }
    }
}