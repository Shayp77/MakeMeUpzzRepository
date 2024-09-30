using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader create(int tid, int uid, DateTime dt, string status)
        {
            TransactionHeader transactionHeader = new TransactionHeader();
            transactionHeader.TransactionID = tid;
            transactionHeader.UserID = uid;
            transactionHeader.Status = status;
            transactionHeader.TransactionDate = dt;
            return transactionHeader;
        }
    }
}