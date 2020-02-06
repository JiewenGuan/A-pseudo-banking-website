using NwbaExample.Models;
using NwbaExampleWithLogin.Models.Repository;
using System;
using System.Collections.Generic;
using NwbaExample.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NwbaExampleWithLogin.Models.DataManager
{
    public class BillsManager : IDataRepository<Bill, int>
    {
        private readonly NwbaContext _context;

        public BillsManager(NwbaContext context)
        {
            _context = context;
        }
        public int Add(Bill item)
        {
            _context.Bills.Add(item);
            _context.SaveChanges();

            return item.BillID;
        }

        public int Delete(int id)
        {
            _context.Bills.Remove(_context.Bills.Find(id));
            _context.SaveChanges();

            return id;
        }

        public Bill Get(int id)
        {
            return _context.Bills.Find(id);
        }

        public IEnumerable<Bill> GetAll()
        {
            return _context.Bills.ToList();
        }

        public int Update(int id, Bill item)
        {
            _context.Update(item);
            _context.SaveChanges();

            return id;
        }
        public int Block(int id)
        {
            Get(id).Block();
            _context.SaveChanges();
            return id;
        }
    }
}
