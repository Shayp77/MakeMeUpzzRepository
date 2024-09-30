using MakeMeUpzz.Controller;
using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MakeMeUpzz.Repositori
{
    public class TransactionHeaderRepo
    {
        MakeMeUpEntities1 db = DatabaseSingleton.getinstace();
        public void insertheader(int tid, int uid, DateTime dt, string status)
        {
            
            TransactionHeader th = TransactionHeaderFactory.create(tid, uid, dt, status);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();

        }
        public TransactionHeader getTransactionbyid(int TransactionID)
        {
            TransactionHeader th = db.TransactionHeaders.Find(TransactionID);
            return th;
        }
        public List<TransactionHeader> getbyuserid(int id)
        {
            return db.TransactionHeaders.Where(t => t.UserID == id).ToList();

        }
        public  List<TransactionHeader> getAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public TransactionHeader getlasttransaction()
        {
            return db.TransactionHeaders.ToList().LastOrDefault();
        }
        public List<TransactionHeader> getunhandledtransaction(string a)
        {
            return (from x in db.TransactionHeaders where x.Status.Equals(a) select x).ToList();
        }
        public TransactionHeader search(int tid)
        {
            return (from TransactionHeader in db.TransactionHeaders where TransactionHeader.TransactionID == tid select TransactionHeader).FirstOrDefault();
        }
        public void updatestatusbyID(int TransactionID, string statusnew)
        {
            TransactionHeader th = getTransactionbyid(TransactionID);
            th.Status = statusnew;
            db.SaveChanges();
        }
        public static List<TransactionHeader> getallTransactions()
        {
            MakeMeUpEntities1 makeMeUpEntities1 = new MakeMeUpEntities1();
            return makeMeUpEntities1.TransactionHeaders.ToList();
        }
        public static int generatetransactionid()
        {
            TransactionHController tc = new TransactionHController();
            TransactionHeader th = tc.GetLastTransaction();
            if (th == null)
            {
                return 1;
            }
            int id = th.TransactionID;
            id++;
            return id;
        }
    }
}