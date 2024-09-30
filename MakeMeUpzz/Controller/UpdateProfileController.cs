using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class UpdateProfileController
    {
        public User getbyid(int id)
        {
            UserHandler uhan = new UserHandler();
            return uhan.GetById(id);
        }
        public string validateprofile(string username, string email, DateTime dateOfBirth, bool maleChecked, bool femaleChecked)
        {
            UserHandler uhan = new UserHandler();
            User user = uhan.GetByUsername(username);
            string errmess = "";

            if (string.IsNullOrEmpty(username))
            {
                errmess = "The username must be filled";
            }
            else if (username.Length < 5 || username.Length > 15)
            {
                errmess = "Please fill the username between 5 to 15 characters";
            }
            else if (string.IsNullOrEmpty(email))
            {
                errmess = "The email must be filled";
            }
            else if (!email.EndsWith(".com"))
            {
                errmess = "Email must end with .com";
            }
            else if (dateOfBirth == DateTime.MinValue)
            {
                errmess = "Date of birth must be filled";
            }
            else if (!maleChecked && !femaleChecked)
            {
                errmess = "Gender checkbox must be filled";
            }

            return errmess;
        }
        public string gendercheck(bool male, bool female)
        {
            return male ? "Male" : "Female";
        }
        public void updatebyid(User currentUser, string username, string email, string gender, DateTime dob)
        {
            int id = currentUser.UserID;
            UserHandler uhan = new UserHandler();
            uhan.UpdateUserById(id, username, email, gender, dob);
        }

        public string validatepassword(User user,string password, string newpass) 
        {
            string errmess = "";
            string oldpass = user.UserPassword;
            if (string.IsNullOrEmpty(password))
            {
                errmess = "The password must be filled";
            }
            else if (string.IsNullOrEmpty(newpass))
            {
                errmess = "New password must be filled";
            }
            else if (!password.Equals(oldpass))
            {
                errmess = "Your password don't match";
            }
            return errmess;
        }
        public void updatepass(int id, string password)
        {
            UserHandler uhan = new UserHandler();
            uhan.UpdatePassword(id, password);
        }
    }
}