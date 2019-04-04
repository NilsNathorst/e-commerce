using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public List<Product> Products { get; set; }

        public Cart()
        {
        }
    }
}
