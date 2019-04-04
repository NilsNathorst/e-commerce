using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string customer_name { get; set; }
        public string customer_adress { get; set; }
        public string customer_zipcode { get; set; }
    }
}

