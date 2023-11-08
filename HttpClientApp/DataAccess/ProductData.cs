using HttpClientApp.Models;

namespace HttpClientApp.DataAccess
{
    public class ProductData
    {
        public static async Task<List<ProductModel>> GetProducts()
        {
            var client = new HttpClient();
            using (HttpResponseMessage response = await client.GetAsync("https://localhost:7049/api/Product"))
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

        public static async Task CreateProduct(ProductModel product)
        {
            var client = new HttpClient();

            using (HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7049/api/Product", product))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public static async Task UpdateProduct(int id, ProductModel product)
        {
            var client = new HttpClient();

            using (HttpResponseMessage response = await client.PutAsJsonAsync($"https://localhost:7049/api/Product/{id}", product))
            {
                 response.EnsureSuccessStatusCode();
            }
        }

        public static async Task DeleteProduct(int id)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7049/api/Product/{id}");
        }
    }
}
