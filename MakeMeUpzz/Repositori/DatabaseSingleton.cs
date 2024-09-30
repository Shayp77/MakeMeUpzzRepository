using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositori
{
    public class DatabaseSingleton
    {
        private static MakeMeUpEntities1 db = null;
        public static MakeMeUpEntities1 getinstace()
        {
            if (db == null)
            {
                db = new MakeMeUpEntities1();
            }
            return db;
        }
    }
}