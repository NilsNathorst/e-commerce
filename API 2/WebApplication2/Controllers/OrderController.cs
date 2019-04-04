using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.Extensions.Configuration;
using WebApplication2.Services;
using WebApplication2.Repositories;
using System.Web.Http.Cors;
using System.Collections.Generic;
using API.Models;
using Newtonsoft.Json.Linq;
using System;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly string connectionString;
        private readonly OrderService orderService;

        public OrderController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderService = new OrderService(new OrderRepository(connectionString));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody]JObject data)
        {
            
                var customer = new Customer
                {
                    customer_name = (string)data["customer"]["name"],
                    customer_adress = (string)data["customer"]["adress"],
                    customer_zipcode = (string)data["customer"]["zip"],
                };
                int cartId = (int)data["cartid"];

                var products = data["products"].ToObject<List<int>>();

                orderService.CreateOrder(cartId, customer, true, products);
                
                return Ok();


           
        }

    }
    
}