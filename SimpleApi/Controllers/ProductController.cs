using Microsoft.AspNetCore.Mvc;
using SimpleApi.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<ProductModel> products = new()
        {
            new ProductModel { Id = 1, Name = "Coca-Cola 0.5L", Price = 4.99 },
            new ProductModel { Id = 2, Name = "Pringles Orginal", Price = 9.99 },
            new ProductModel { Id = 3, Name = "White wine", Price = 29.99 }
        }; 

        // GET: api/<ProductController>
        [HttpGet]
        public List<ProductModel> Get()
        {
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            return products.Where(p => p.Id == id).FirstOrDefault();
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductModel value)
        {
            products.Add(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductModel value)
        {
            products.Remove(products.Where(p => p.Id == id).FirstOrDefault());
            products.Add(value);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            products.Remove(products.Where(p => p.Id == id).FirstOrDefault());
        }
    }
}
