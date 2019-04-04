using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2
{
    public interface ICartRepository
    {
        List<Product> Get();

        Product Get(int id);

        void Add(Product product);
    }
}
