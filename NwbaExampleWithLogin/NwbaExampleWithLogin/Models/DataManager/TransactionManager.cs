using NwbaExample.Data;
using NwbaExample.Models;
using NwbaExampleWithLogin.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NwbaExampleWithLogin.Models.DataManager
{
    public class TransactionManager : IDataRepository<Transaction, int>
    {
        private readonly NwbaContext _context;

        public TransactionManager(NwbaContext context)
        {
            _context = context;
        }
        public int Add(Transaction item)
        {
            _context.Transactions.Add(item);
            _context.SaveChanges();

            return item.TransactionID;
        }

        public int Delete(int id)
        {
            _context.Transactions.Remove(_context.Transactions.Find(id));
            _context.SaveChanges();

            return id;
        }

        public Transaction Get(int id)
        {
            return _context.Transactions.Find(id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public int Update(int id, Transaction item)
        {
            _context.Update(item);
            _context.SaveChanges();

            return id;
        }
    }
}
