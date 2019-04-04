using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public string product_image { get; set; }
        public int product_price { get; set; }
        public int product_quantity { get; set; }
        public Product()
        {
        }
    }

}
