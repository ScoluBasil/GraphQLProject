using GraphQLProject.Intefaces;
using GraphQLProject.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphQLProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IproductServices _productservices;

        public ProductController(IproductServices productservices)
        {
            this._productservices = productservices;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productservices.getAllProduct();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productservices.GetProductById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            return _productservices.AddProduct(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            return _productservices.UpdateProduct(id, product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productservices.deleteProduct(id);
        }
    }
}
