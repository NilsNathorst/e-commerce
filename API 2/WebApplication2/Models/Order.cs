using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Order
    {
        public int CartId { get; set; }
        public int TotalPrice { get; set; }
        public int Id { get; set; }
        public string customer_name { get; set; }
        public int customer_id { get; set; }
        

        public Order()
        {
        }
    }
}
