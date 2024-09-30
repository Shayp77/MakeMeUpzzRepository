using MakeMeUpzz.Factory;
using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositori
{
    public class MakeupTypeRepository
    {
        private static MakeMeUpEntities1 db = DatabaseSingleton.getinstace();

        public static List<MakeupType> getAllMakeupTypes()
        {
            return db.MakeupTypes.ToList();
        }

        public static int getLastMakeupTypeID()
        {
            return (from x in db.MakeupTypes select x.MakeupTypeID).ToList().LastOrDefault();
        }

        public static List<int> getAllMakeupTypeIDs()
        {
            return (from x in db.MakeupTypes select x.MakeupTypeID).ToList();
        }

        public static void insertMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType makeupType = MakeupTypeFactory.Create(MakeupTypeID, MakeupTypeName);
            db.MakeupTypes.Add(makeupType);
            db.SaveChanges();
        }

        public static MakeupType FindMakeupTypeByID(int MakeupTypeID)
        {
            MakeupType makeupType = db.MakeupTypes.Find(MakeupTypeID);
            return makeupType;
        }

        public static void RemoveMakeupTypeByID(int MakeupTypeID)
        {
            MakeupType makeupType = db.MakeupTypes.Find(MakeupTypeID);
            db.MakeupTypes.Remove(makeupType);
            db.SaveChanges();
        }

        public static void updateMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType makeupType = FindMakeupTypeByID(MakeupTypeID);
            makeupType.MakeupTypeID = MakeupTypeID;
            makeupType.MakeupTypeName = MakeupTypeName;
            db.SaveChanges();
        }

        public static int getMakeupTypeIDbyName(String MakeupTypeName)
        {
            return (from x in db.MakeupTypes
                    where x.MakeupTypeName == MakeupTypeName
                    select x.MakeupTypeID).FirstOrDefault();
        }
        public static int generateMakeupTypeID()
        {
            int newID = 0;
            int lastID = MakeupHandler.getLastMakeupTypeID();
            int? lastIDLogic = lastID;
            if (lastIDLogic == null)
            {
                newID = 1;
            }
            else
            {
                newID = lastID;
                newID++;
            }
            return newID;
        }
    }

}