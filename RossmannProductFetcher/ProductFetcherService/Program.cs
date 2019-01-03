using ProductFetcherService.Services;
using System;

namespace ProductFetcherService
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductService();
            Console.WriteLine(productService.GetProductById(279622));
            Console.ReadLine();
        }
    }
}
