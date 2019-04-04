using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.Extensions.Configuration;
using WebApplication2.Services;
using WebApplication2.Repositories;
using System.Web.Http.Cors;

namespace WebApplication2.Controllers
{
    [EnableCors(origins: "http://localhost:3000/", headers: "", methods: "*")]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly string connectionString;
        private readonly ProductService productService;


        public ProductController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.productService = new ProductService(new ProductRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var result = this.productService.Get();

            if (result == null)
            {
                return NotFound();
            }
            return this.Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var result = this.productService.Get(id);

            if (result == null)
            {
                return NotFound();
            }
            return this.Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post([FromBody]Product product)
        {
            var result = productService.Add(product);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        //[HttpDelete]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult DeleteAll()
        //{
        //    productService.DeleteAll();
        //    return Ok();
        //}
    
    }
}