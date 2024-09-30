using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class TransactionDController
    {
        public void InsertTransactionDetail(int tid, int makeupid, int quantity)
        {
           
            TransactionDetailHandler transactionDetailHandler = new TransactionDetailHandler();
            transactionDetailHandler.InsertTransactionDetail(tid, makeupid, quantity);
        }
        public static List<TransactionDetail> getAllTransactionDetails()
        {
            TransactionDetailHandler transactionDetailHandler = new TransactionDetailHandler();

            return transactionDetailHandler.getAllTransactionDetails();
        }
        public static List<TransactionDetail> FindByTransactionId(int tid)
        {
            TransactionDetailHandler transactionDetailHandler = new TransactionDetailHandler();

            return transactionDetailHandler.FindByTransactionId(tid);
        }
    }
}