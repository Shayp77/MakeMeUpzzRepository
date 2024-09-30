using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class TransactionDetailsFactory
    {
        public static TransactionDetail create(int tid, int mid, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = tid;
            transactionDetail.MakeupID = mid;
            transactionDetail.Quantity = quantity;
            return transactionDetail;
        }
    }
}