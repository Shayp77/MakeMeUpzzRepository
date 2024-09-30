using MakeMeUpzz.Controller;
using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System;
using System.Collections.Generic;

namespace MakeMeUpzz.Handlers
{
    public class TransactionHeaderHandler
    {
        private readonly TransactionHeaderRepo _transactionHeaderRepo;

        public TransactionHeaderHandler()
        {
            _transactionHeaderRepo = new TransactionHeaderRepo();
        }

        public void InsertTransactionHeader(int tid, int uid, DateTime dt, string status)
        {
            _transactionHeaderRepo.insertheader(tid, uid, dt, status);
        }

        public  TransactionHeader GetLastTransaction()
        {
            return _transactionHeaderRepo.getlasttransaction();
        }
        public List<TransactionHeader> getbyuserid(int id)
        {
            return _transactionHeaderRepo.getbyuserid(id);

        }
        public  List<TransactionHeader> getAllTransactionHeaders()
        {
            return _transactionHeaderRepo.getAllTransactionHeaders();
        }
        public List<TransactionHeader> getunhandledtransaction(string a)
        {
            return _transactionHeaderRepo.getunhandledtransaction(a);
        }
        public TransactionHeader search(int tid)
        {
            return _transactionHeaderRepo.search(tid);
        }
        public void updatestatusbyID(int TransactionID, string statusnew)
        {
            _transactionHeaderRepo.updatestatusbyID(TransactionID, statusnew);
        }

        public static List<TransactionHeader> getallTransaction()
        {
            return TransactionHeaderRepo.getallTransactions();
        }
        public static int generatetransactionid()
        {
            return TransactionHeaderRepo.generatetransactionid();
        }
    }
}
