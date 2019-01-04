using Microsoft.AspNetCore.Builder;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductFetcherApi.RabbitmqUtils
{
    public static class ApplicationBuilderExtensions
    {
        private const string PUBLISH_QUEUE_NAME = "GetProductById";
        private const string LISTEN_QUEUE_NAME = "ProductFetched";
        private const string LISTEN_EXCHANGE_NAME = "products";

        public static IApplicationBuilder AddHandler<T>(this IApplicationBuilder app, IBusClient client)
            where T : IMessage
        {
            if (!(app.ApplicationServices.GetService(typeof(IHandler<T>)) is IHandler<T> handler))
                throw new NullReferenceException();

            client.SubscribeAsync<T>(async (msg, context) => await handler.HandleAsync(msg, CancellationToken.None), cfg => cfg.WithExchange(e => e.WithName(LISTEN_EXCHANGE_NAME)).WithQueue(q => q.WithName(LISTEN_QUEUE_NAME)));
            return app;
        }
        public static IApplicationBuilder AddHandler<T>(this IApplicationBuilder app)
            where T : IMessage
        {
            if (!(app.ApplicationServices.GetService(typeof(IBusClient)) is IBusClient busClient))
                throw new NullReferenceException();

            return AddHandler<T>(app, busClient);
        }
    }
}
