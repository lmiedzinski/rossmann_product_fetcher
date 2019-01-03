using System;
using System.Net.Http;

namespace ProductFetcherService.Services
{
    public class ProductService : IProductService
    {
        private const string PRODUCT_API_URL = "https://www.rossmann.pl/products/api/Products/%%productId%%?shopNumber=735";
        public string GetProductById(int id)
        {
            string productData = "";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("accept", "application/json");
                    productData = httpClient.GetStringAsync(new Uri(PRODUCT_API_URL.Replace("%%productId%%", id.ToString()))).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            return productData;
        }
    }
}
