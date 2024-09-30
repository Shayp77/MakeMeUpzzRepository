using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class UserFactory
    {
        public static User create(int userid, string username, string useremail, DateTime userdob, string userpassword, string userrole, string usergender)
        {
            User user = new User();
            user.UserID = userid;
            user.Username = username;
            user.UserPassword = userpassword;
            user.UserGender = usergender;
            user.UserEmail = useremail;
            user.UserDOB = userdob;
            user.UserRole = userrole;
            return user;
        }
    }
}