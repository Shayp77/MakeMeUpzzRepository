using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class RegisController
    {

        public void doregister( string username, string useremail, DateTime userdob, string userpassword, string userrole, string usergender)
        {
            UserHandler uhan = new UserHandler();
            uhan.InsertUser( username, useremail, userdob, userpassword, userrole, usergender);
        }
        public string gendercheck(bool male,bool female)
        {
            return male? "Male" : "Female";
        }
        public string ValidateRegistration(string username, string password, string confpass, string email, DateTime dateOfBirth, bool maleChecked, bool femaleChecked)
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
            else if (user != null)
            {
                errmess = "The Username is already taken";
            }
            else if (string.IsNullOrEmpty(email))
            {
                errmess = "The email must be filled";
            }
            else if (!email.EndsWith(".com"))
            {
                errmess = "Email must end with .com";
            }
            else if (string.IsNullOrEmpty(password))
            {
                errmess = "The password must be filled";
            }
            else if (string.IsNullOrEmpty(confpass))
            {
                errmess = "Confirmation password must be filled";
            }
            else if (!password.Equals(confpass))
            {
                errmess = "Password and Confirm Password must be the same";
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
    }
}