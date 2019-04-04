using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderItem
    {
        public int order_id { get; set; }
        public string product_name { get; set; }
        public int product_price{ get; set; }
        public string product_image{ get; set; }
    }
}
