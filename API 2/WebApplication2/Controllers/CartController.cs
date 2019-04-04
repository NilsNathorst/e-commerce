using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.Extensions.Configuration;
using WebApplication2.Services;
using WebApplication2.Repositories;
using System.Web.Http.Cors;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly string connectionString;
        private readonly ProductService productService;
        private readonly CartService cartService;

        public CartController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(connectionString));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var cart = cartService.Get(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody]CartItem cartItem)
        {

            if (cartItem.CartId < 1)
            {
                var cart = cartService.Create(cartItem);
                return Ok(cart);
            }
            else
            {
                var cart = cartService.Add(cartItem);
                return Ok(cart);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Emptycart(int id)
        {
            try
            {
                this.cartService.EmptyCart(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}