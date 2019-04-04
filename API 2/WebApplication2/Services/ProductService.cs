using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repositories;
using System.Web.Http;

namespace WebApplication2.Services
{
        public class ProductService
        {
            private readonly string connectionString;
            private readonly ICartRepository productRepository;

            public ProductService(ICartRepository productRepository)
            {
                 this.productRepository = productRepository;
                 this.connectionString = connectionString;
            }

            public List<Product> Get()
            {
                return this.productRepository.Get();
            }

            public Product Get(int id)
            {
                 return this.productRepository.Get(id);
            }

            public bool Add(Product product)
            {
                this.productRepository.Add(product);
                return true;
            }

            public static void Register(HttpConfiguration config)
            {
                config.EnableCors();
            }

        }
    
}
