using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class CartRepository
    {
        private readonly string connectionString;
        private object product;

        public CartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Create()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cartId = connection.QuerySingle<int>(@"INSERT INTO Cart (Isordered) VALUES (0); SELECT SCOPE_IDENTITY()");
                return cartId;
            }
        }

        public void Add (CartItem cartitem)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO CartItem (CartId, ProductId, Quantity) VALUES (@cartId, @ProductId, @quantity)", cartitem);
            }
        }

        public Cart Get (int cartId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cart = connection.QuerySingleOrDefault<Cart>("SELECT * FROM Cart WHERE Id = @cartId", new { cartId });
                cart.Products = connection.Query<Product>("SELECT * FROM CartItem INNER JOIN Product p ON CartItem.ProductId = p.Id WHERE CartItem.cartId = @cartId", new { cartId }).ToList();
                return cart;
            }
        }

        public void EmptyCart(int cartId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM CartItem WHERE CartId = @cartId", new { cartId });
            }
        }
    }
}