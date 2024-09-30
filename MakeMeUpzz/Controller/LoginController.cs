using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class LoginController
    {
        public string ValidateLogin(string username, string password)
        {
            UserHandler uhan = new UserHandler();
            User user = uhan.GetByUsername(username);
            string errmess = "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                errmess = "All fields must be filled!";
            }
            else if (user == null)
            {
                errmess = "User does not exist!";
            }
            else if (user.UserPassword != password)
            {
                errmess = "Invalid credentials!";
            }

            return errmess;
        }
        public User getbyusername(string username)
        {
            UserHandler uhan = new UserHandler();
            return uhan.GetByUsername(username);
        }
    }
}