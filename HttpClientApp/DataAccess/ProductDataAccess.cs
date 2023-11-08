using HttpClientApp.DataAccess;
using HttpClientApp.Models;
using System.Text.Json;

namespace HttpClientApp.DataAccess
{
    public class ProductClientService
    {
        private readonly HttpClient client;
        public ProductClientService(HttpClient _client)
        {
            client = _client;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            using (HttpResponseMessage response = await client.GetAsync("Product"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<ProductModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task CreateProduct(ProductModel product)
        {
            using (HttpResponseMessage response = await client.PostAsJsonAsync("Product", product))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task UpdateProduct(int id, ProductModel product)
        {
            using (HttpResponseMessage response = await client.PutAsJsonAsync($"Product/{id}", product))
            {
                 response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteProduct(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"Product/{id}");
        }
    }
}
