using Refit;
using RefitClient.Models;

namespace RefitClient.DataAccess
{
    public interface IProductData
    {
        [Get("/Product")]
        Task<List<ProductModel>> GetProducts();

        [Get("/Product/{id}")]
        Task<ProductModel> GetProduct(int id);

        [Post("/Product")]
        Task CreateProduct([Body] ProductModel product);

        [Put("/Product/{id}")]
        Task UpdateProduct(int id, [Body] ProductModel product);

        [Delete("/Product/{id}")]
        Task DeleteProduct(int id);
    }
}
