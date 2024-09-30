using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositori
{
    public class CartRepo
    {

        MakeMeUpEntities1 db = DatabaseSingleton.getinstace();
        public void insert(int id, int userid, int makeupid, int quantity)
        {
            Cart cart = CartsFactory.create(id, userid, makeupid, quantity);
            db.Carts.Add(cart);
            db.SaveChanges();
        }
        public void deleteAll()
        {
            db.Carts.RemoveRange(db.Carts);
            db.SaveChanges();
        }
        public Cart getlastcart()
        {
            return db.Carts.ToList().LastOrDefault();
        }
        public List<Cart> getallcart()
        {
            return db.Carts.ToList();
        }
    }
}