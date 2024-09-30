using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class OrderController
    {
        public static List<Makeup> getAllMakeups()
        {
            return MakeupHandler.getAllMakeups();
        }
        public static void DeleteAllItemsFromCart()
        {
            CartHandler handler = new CartHandler();
             handler.DeleteAllItemsFromCart();
             
        }
        public static int generateid()
        {
            CartHandler handler = new CartHandler();
            Cart cart = handler.GetLastCartItem();
            if (cart == null)
            {
                return 1;
            }
            int id = cart.CartID;
            id++;
            return id;
        }
    }
}