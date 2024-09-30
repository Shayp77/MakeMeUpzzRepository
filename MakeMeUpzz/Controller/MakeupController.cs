using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class MakeupController
    {
        public static Makeup findbyid(int id)
        {
            return MakeupHandler.FindMakeupByID(id);
        }
        public static MakeupBrand FindMakeupBrandByID(int MakeupBrandID)
        {
            return MakeupHandler.FindMakeupBrandByID(MakeupBrandID);
        }
        public static MakeupType FindMakeupTypeByID(int MakeupTypeID)
        {
            return MakeupHandler.FindMakeupTypeByID(MakeupTypeID);
        }
        public static int generateMakeupTypeID()
        {
            return MakeupHandler.generateMakeupTypeID();
        }
        public static int generateMakeupBrandID()
        {
            return MakeupHandler.generateMakeupBrandID();
        }
        public static void RemoveMakeupByID(int MakeupID)
        {
            MakeupHandler.RemoveMakeupByID(MakeupID);
        }
        public static void RemoveMakeupTypeByID(int MakeupTypeID)
        {
            MakeupHandler.RemoveMakeupTypeByID(MakeupTypeID);
        }
        public static void RemoveMakeupBrandByID(int MakeupBrandID)
        {
            MakeupHandler.RemoveMakeupBrandByID(MakeupBrandID);
        }

        public static List<MakeupType> getAllMakeupTypes()
        {
            return MakeupHandler.getAllMakeupTypes();
        }

        public static List<MakeupBrand> getAllMakeupBrands()
        {
            return MakeupHandler.getAllMakeupBrands();
        }

        public static List<Makeup> getAllMakeups()
        {
            return MakeupHandler.getAllMakeups();
        }
        public static void insertMakeup(String MakeupName, int MakeupPrice, int MakeupWeight,
            int MakeupTypeID, int MakeupBrandID)
        {
            MakeupHandler.insertMakeup(MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID,
                MakeupBrandID);
        }

        public static void updateMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight,
            int MakeupTypeID, int MakeupBrandID)
        {
            MakeupHandler.updateMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID,
                MakeupBrandID);
        }
        public static void updateMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupHandler.updateMakeupType(MakeupTypeID, MakeupTypeName);
        }
        public static void updateMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupHandler.updateMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
        }
        public static void insertMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupHandler.insertMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
        }
        public static void insertMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupHandler.insertMakeupType(MakeupTypeID, MakeupTypeName);
        }
        public static string MakeupValidation(string MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            string errmess = "";
            if (MakeupName.Length < 1 || MakeupName.Length > 99)
            {
                errmess = "Please fill the Makeup Name between 1 to 99 characters";
            }
            else if (MakeupPrice < 1)
            {
                errmess = "Makeup Price should be greater than or equal to 1";
            }
            else if (MakeupWeight > 1500)
            {
                errmess = "Makeup Weight cannot be greater than 1500 grams";
            }
            else if (MakeupTypeID == 0)
            {
                errmess = "Type ID cannot be empty";
            }
            else if (MakeupBrandID == 0)
            {
                errmess = "Brand ID cannot be empty";
            }
            return errmess;
        }

        public static string MakeupBrandValidation(string MakeupBrandName, int MakeupBrandRating)
        {
            string errmess = "";
            if (MakeupBrandName.Length < 1 || MakeupBrandName.Length > 99)
            {
                errmess = "Please fill the Makeup Brand Name between 1 to 99 characters";
            }
            else if (MakeupBrandRating < 0 || MakeupBrandRating > 100)
            {
                errmess = "Makeup Brand Rating must be between 0 and 100";
            }
            return errmess;
        }
        public static string MakeupTypeValidation(string MakeupName)
        {
            string errmess = "";
            if (MakeupName.Length < 1 || MakeupName.Length > 99)
            {
                errmess = "Please fill the Makeup Name between 1 to 99 characters";
            }
            return errmess;
        }
        public static int getMakeupPrice(int id)
        {
            return MakeupHandler.getMakeupPrice(id);
        }
    }
}