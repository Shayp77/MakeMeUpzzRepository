using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositori
{
    public class TransactionDetailRepo
    {
        MakeMeUpEntities1 db = DatabaseSingleton.getinstace();
        public void inserttd(int tid, int mid, int quantity)
        {
            TransactionDetail td = TransactionDetailsFactory.create(tid, mid, quantity);
            db.TransactionDetails.Add(td);
            db.SaveChanges();

        }

        public List<TransactionDetail> FindByTransactionId(int tid)
        {
            return db.TransactionDetails.Where(t => t.TransactionID == tid).ToList();
        }
        public List<TransactionDetail> FindByMakeupId(int tid)
        {
            return db.TransactionDetails.Where(t => t.MakeupID == tid).ToList();
        }
        public  List<TransactionDetail> getAllTransactionDetails()
        {
            return db.TransactionDetails.ToList();
        }

    }
}