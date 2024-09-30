using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class UserController
    {
        public static User findbyid(int id)
        {
            UserHandler userHandler = new UserHandler();
            return userHandler.GetById(id);
        }
        public static List<User> GetUsers()
        {
            UserHandler userHandler = new UserHandler();

            return userHandler.GetUsers();
        }
    }
}