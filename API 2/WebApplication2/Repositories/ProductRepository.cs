using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Dapper;

namespace WebApplication2.Repositories
{
    public class ProductRepository : WebApplication2.ICartRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
            
        public List<Product> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                return connection.Query<Product>("SELECT * FROM Product").ToList();
            }
        }

        public Product Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var product = connection.QuerySingleOrDefault<Product>("SELECT * FROM Product WHERE Id = @id", new { id });
                return product;
            }
        }

        public void Add(Product product)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Product (product_name, product_description, product_price, product_image) " +
                                   "VALUES(@product_name, @product_description, @product_price, @product_image)", product);
            }
        }

        public void AddToCart(Product product)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Cart (product_name, product_description, product_quantity, product_price, product_image) " +
                                   "VALUES(@product_name, @product_description, @product_quantity, @product_price, @product_image)", product);
            }
        }
    }
    
}
