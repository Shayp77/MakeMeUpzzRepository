using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System.Collections.Generic;

namespace MakeMeUpzz.Handlers
{
    public class TransactionDetailHandler
    {
        private readonly TransactionDetailRepo _transactionDetailRepo;

        public TransactionDetailHandler()
        {
            _transactionDetailRepo = new TransactionDetailRepo();
        }

        public void InsertTransactionDetail(int tid, int mid, int quantity)
        {
            _transactionDetailRepo.inserttd(tid, mid, quantity);
        }

        public List<TransactionDetail> getAllTransactionDetails()
        {
            return _transactionDetailRepo.getAllTransactionDetails();
        }
        public List<TransactionDetail> FindByTransactionId(int tid)
        {
            return _transactionDetailRepo.FindByTransactionId(tid);
        }
    }
}
