using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System;
using System.Collections.Generic;

namespace MakeMeUpzz.Handlers
{
    public class MakeupHandler
    {
        //Access Makeup Repo
        public static List<Makeup> getAllMakeups()
        {
            return MakeupRepository.getAllMakeups();
        }

        public static int getLastMakeupID()
        {
            return MakeupRepository.getLastMakeupID();
        }

        public static void insertMakeup(String MakeupName, int MakeupPrice, int MakeupWeight,
            int MakeupTypeID, int MakeupBrandID)
        {
            MakeupRepository.insertMakeup(MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID,
                MakeupBrandID);
        }

        public static Makeup FindMakeupByID(int MakeupID)
        {
            return MakeupRepository.FindMakeupByID(MakeupID);
        }

        public static void RemoveMakeupByID(int MakeupID)
        {
            MakeupRepository.RemoveMakeupByID(MakeupID);
        }

        public static void updateMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight,
            int MakeupTypeID, int MakeupBrandID)
        {
            MakeupRepository.updateMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID,
                MakeupBrandID);
        }
        public static int getMakeupID(String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID,
            int MakeupBrandID)
        {
            return MakeupRepository.getMakeupID(MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID,
                MakeupBrandID);
        }

        //Access MakeupType Repo
        public static List<MakeupType> getAllMakeupTypes()
        {
            return MakeupTypeRepository.getAllMakeupTypes();
        }

        public static List<int> getAllMakeupTypeIDs()
        {
            return MakeupTypeRepository.getAllMakeupTypeIDs();
        }

        public static int getLastMakeupTypeID()
        {
            return MakeupTypeRepository.getLastMakeupTypeID();
        }
        public static int generateMakeupTypeID()
        {
            return MakeupTypeRepository.generateMakeupTypeID();
        }
        public static void insertMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupTypeRepository.insertMakeupType(MakeupTypeID, MakeupTypeName);
        }

        public static MakeupType FindMakeupTypeByID(int MakeupTypeID)
        {
            return MakeupTypeRepository.FindMakeupTypeByID(MakeupTypeID);
        }

        public static void RemoveMakeupTypeByID(int MakeupTypeID)
        {
            MakeupTypeRepository.RemoveMakeupTypeByID(MakeupTypeID);
        }

        public static void updateMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupTypeRepository.updateMakeupType(MakeupTypeID, MakeupTypeName);
        }
        public static int getMakeupTypeIDbyName(String MakeupTypeName)
        {
            return MakeupTypeRepository.getMakeupTypeIDbyName(MakeupTypeName);
        }

        //Access MakeupBrand Repo
        public static List<MakeupBrand> getAllMakeupBrands()
        {
            return MakeupBrandRepository.getAllMakeupBrands();
        }

        public static List<int> getAllMakeupBrandIDs()
        {
            return MakeupBrandRepository.getAllMakeupBrandIDs();
        }

        public static int getLastMakeupBrandID()
        {
            return MakeupBrandRepository.getLastMakeupBrandID();
        }
        public static int generateMakeupBrandID()
        {
            return MakeupBrandRepository.generateMakeupBrandID();
        }
        public static void insertMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrandRepository.insertMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
        }

        public static MakeupBrand FindMakeupBrandByID(int MakeupBrandID)
        {
            return MakeupBrandRepository.FindMakeupBrandByID(MakeupBrandID);
        }

        public static void RemoveMakeupBrandByID(int MakeupBrandID)
        {
            MakeupBrandRepository.RemoveMakeupBrandByID(MakeupBrandID);
        }

        public static void updateMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrandRepository.updateMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
        }
        public static int getMakeupBrandIDbyName(String MakeupBrandName)
        {
            return MakeupBrandRepository.getMakeupBrandIDbyName(MakeupBrandName);
        }
        public static int getMakeupPrice(int id)
        {
            return MakeupRepository.getMakeupPrice(id);
        }
    }
}
