using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class OrderService
    {

        public OrderRepository orderRepository { get; set; }

        public OrderService(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void CreateOrder(int cartId, Customer customer, bool Isordered, List<int>Ids)
        {
            this.orderRepository.CreateOrder(cartId, customer, Isordered, Ids);
        }
    }
}
