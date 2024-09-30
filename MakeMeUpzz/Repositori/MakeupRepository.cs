using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositori
{
    public class MakeupRepository
    {
        private static MakeMeUpEntities1 db = DatabaseSingleton.getinstace();

        public static List<Makeup> getAllMakeups()
        {
            return db.Makeups.ToList();
        }

        public static int getLastMakeupID()
        {
            return (from x in db.Makeups select x.MakeupID).ToList().LastOrDefault();
        }

        public static void insertMakeup(String MakeupName, int MakeupPrice, int MakeupWeight,
            int MakeupTypeID, int MakeupBrandID)
        {
            int newID = 0;
            int lastID = (from x in db.Makeups select x.MakeupID).ToList().LastOrDefault();

            if (db == null)
            {
                newID = 1;
            }
            else
            {
                newID = lastID + 1;
            }

            Makeup makeup = MakeupFactory.create(newID, MakeupName, MakeupPrice, MakeupWeight,
                MakeupTypeID, MakeupBrandID);
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }

        public static void RemoveMakeupByID(int MakeupID)
        {
            TransactionDetailRepo td = new TransactionDetailRepo();
            List<TransactionDetail> tList = td.FindByMakeupId(MakeupID);
            foreach (var t in tList)
            {
                db.TransactionDetails.Remove(t);
            }
            db.SaveChanges();
            Makeup makeup = db.Makeups.Find(MakeupID);
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }

        public static Makeup FindMakeupByID(int MakeupID)
        {
            Makeup makeup = db.Makeups.Find(MakeupID);
            return makeup;
        }

        public static int getMakeupPrice(int id)
        {
            return (from x in db.Makeups where x.MakeupID == id select x.MakeupPrice).FirstOrDefault();
        }
        public static void updateMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight
            , int MakeupTypeID, int MakeupBrandID)
        {
            Makeup updateMakeup = FindMakeupByID(MakeupID);
            updateMakeup.MakeupName = MakeupName;
            updateMakeup.MakeupPrice = MakeupPrice;
            updateMakeup.MakeupWeight = MakeupWeight;
            updateMakeup.MakeupTypeID = MakeupTypeID;
            updateMakeup.MakeupBrandID = MakeupBrandID;
            db.SaveChanges();
        }

        public static int getMakeupID(String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID,
            int MakeupBrandID)
        {
            return (from x in db.Makeups
                    where x.MakeupName == MakeupName &&
                    x.MakeupPrice == MakeupPrice && x.MakeupWeight == MakeupWeight &&
                    x.MakeupTypeID == MakeupTypeID && x.MakeupBrandID == MakeupBrandID
                    select x.MakeupID).FirstOrDefault();
        }
    }

}