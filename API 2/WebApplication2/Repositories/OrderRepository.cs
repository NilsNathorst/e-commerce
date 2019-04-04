using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Dapper;
using API.Models;

namespace WebApplication2.Repositories
{
    public class OrderRepository
    {
        private readonly string connectionString;

        public OrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateOrder(int cartId, Customer customer, bool Isordered, List<int>Ids)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var customer_id = connection.Query<int>(
                   "INSERT INTO Customers (customer_name, customer_adress, customer_zipcode) VALUES (@Name, @Adress, @Zipcode); SELECT SCOPE_IDENTITY()",
                   new
                   {
                       Name = customer.customer_name,
                       Adress = customer.customer_adress,
                       Zipcode = customer.customer_zipcode
                   }
               ).Single();


                var order_id = connection.Query<int>(
                    "INSERT INTO Orders (customer_id, cartId) VALUES (@Customer, @Cart); " +
                    "SELECT SCOPE_IDENTITY()",
                    new
                    {
                        Customer = customer_id,
                        Cart = cartId
                    }
                 ).Single();


                foreach (var id in Ids)
                {
                    var Product = connection.QuerySingle<Product>("SELECT * FROM Product WHERE id = @Id", new { id });

                    connection.Execute("INSERT INTO OrderItem (order_id, product_name, product_price, product_image) VALUES (@Id, @Name, @Cost, @image)",
                    new
                    {
                        Id = order_id,
                        Name = Product.product_name,
                        Cost = Product.product_price,
                        Image = Product.product_image
                    });
                }
                connection.Execute("UPDATE Cart SET Isordered = @Isordered WHERE Id = @cartId", new { Isordered, cartId });
            }
        }
    }
}
