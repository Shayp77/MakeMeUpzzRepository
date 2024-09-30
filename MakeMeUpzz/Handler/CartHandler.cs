using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System.Collections.Generic;

namespace MakeMeUpzz.Handlers
{
    public class CartHandler
    {
        private readonly CartRepo _cartRepo;

        public CartHandler()
        {
            _cartRepo = new CartRepo();
        }

        public void InsertToCart(int id, int userid, int makeupid, int quantity)
        {
            _cartRepo.insert(id, userid, makeupid, quantity);
        }

        public void DeleteAllItemsFromCart()
        {
            _cartRepo.deleteAll();
        }

        public Cart GetLastCartItem()
        {
            return _cartRepo.getlastcart();
        }

        public List<Cart> GetAllCartItems()
        {
            return _cartRepo.getallcart();
        }
    }
}
