using RestSharp;
using RestSharpClient.DataAccess;
using RestSharpClient.Models;
using System.Text.Json;

namespace RestSharpClient.DataAccess
{
    public class ProductClientService
    {
        public static async Task<List<ProductModel>> GetProducts()
        {
            var request = new RestRequest("Product");
            return await RestClientWrapper.client.GetAsync<List<ProductModel>>(request);
        }

        public static async Task CreateProduct(ProductModel product)
        {
            var request = new RestRequest("Product");
            request.AddBody(product);
            await RestClientWrapper.client.PostAsync<List<ProductModel>>(request);
        }

        public static async Task UpdateProduct(int id, ProductModel product)
        {
            var request = new RestRequest($"Product/{id}");
            request.AddBody(product);
            await RestClientWrapper.client.PutAsync<List<ProductModel>>(request);
        }

        public static async Task DeleteProduct(int id)
        {
            var request = new RestRequest($"Product/{id}");
            await RestClientWrapper.client.DeleteAsync<List<ProductModel>>(request);
        }
    }
}
