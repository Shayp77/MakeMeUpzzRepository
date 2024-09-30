using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositori
{
    public class UserRepo
    {
        MakeMeUpEntities1 db = DatabaseSingleton.getinstace();
        public User login(string username, string password)
        {
            return (from x in db.Users where x.Username.Equals(username) && x.UserPassword.Equals(password) select x).FirstOrDefault();
        }
        public void insert(int userid, string username, string useremail, DateTime userdob, string userpassword, string userrole, string usergender)
        {
            User user = UserFactory.create(userid, username, useremail, userdob, userpassword, userrole, usergender);
            db.Users.Add(user);
            db.SaveChanges();
        }
        public User getlastuser()
        {
            return db.Users.ToList().LastOrDefault();
        }
        public User samename(string username)
        {
            return (from x in db.Users where x.Username == username select x).FirstOrDefault();
        }
        public List<User> getusers()
        {
            return db.Users.ToList();
        }
        public User byid(int id)
        {
            return (from x in db.Users where x.UserID == id select x).FirstOrDefault();
        }
        public void updatebyid(int id, string username, string email, string gender, DateTime dob)
        {
            User user = byid(id);
            user.Username = username;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = dob;
            db.SaveChanges();
        }
        public void updatepassword(int id, string password)
        {
            User user = byid(id);
            user.UserPassword = password;
            db.SaveChanges();
        }
    }
}