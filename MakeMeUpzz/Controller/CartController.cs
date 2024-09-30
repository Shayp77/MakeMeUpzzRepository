using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class CartController
    {
        public static void InsertToCart(int userId,int makeupId,int quantity)
        {
            CartHandler handler = new CartHandler();
            int id = OrderController.generateid();

            handler.InsertToCart(id, userId, makeupId, quantity);
        }
        public static List<Cart> getallcart()
        {
            CartHandler h = new CartHandler();
            return h.GetAllCartItems();
        }
    }
}