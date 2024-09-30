using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class CartsFactory
    {
        public static Cart create(int id, int userid, int makeupid, int quantity)
        {
            Cart cart = new Cart();
            cart.CartID = id;
            cart.UserID = userid;
            cart.MakeupID = makeupid;
            cart.Quantity = quantity;
            return cart;
        }
    }
}