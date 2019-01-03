using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductFetcherApi.DbConnectors;
using ProductFetcherApi.RabbitmqUtils;
using ProductFetcherApi.Repositories;
using ProductFetcherApi.Services;

namespace ProductFetcherApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration.GetSection("MongoDbConfiguration").Get<MongoDbConfiguration>());
            services.AddSingleton<MongoDbConnector>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddTransient<IHandler<ReceiveMessage>, SendMessageHandler>();
            services.AddScoped<IProductService, ProductService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddRabbitMq(Configuration.GetSection("rabbitmq"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.AddHandler<ReceiveMessage>();
        }
    }
}
