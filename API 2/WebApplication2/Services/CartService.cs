using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class CartService
    {
        private readonly string connectionString;
        private readonly CartRepository cartRepository;



        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public Cart Get (int id)
        {
            return cartRepository.Get(id);
        }

        public Cart Create(CartItem cartitem)
        {

            var cartId = cartRepository.Create();

            cartitem.CartId = cartId;

            cartRepository.Add(cartitem);

            var cart = cartRepository.Get(cartId);

            return cart;

        }

        public Cart Add(CartItem cartitem)
        {
            cartRepository.Add(cartitem);

            var cart = cartRepository.Get(cartitem.CartId);

            return cart;

        }

        public void EmptyCart(int cartId)
        {
            cartRepository.EmptyCart(cartId);
        }
    }
}
