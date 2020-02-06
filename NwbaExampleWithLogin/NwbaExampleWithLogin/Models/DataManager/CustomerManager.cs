using NwbaExample.Models;
using NwbaExampleWithLogin.Models.Repository;
using System;
using System.Collections.Generic;
using NwbaExample.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NwbaExampleWithLogin.Models.DataManager
{
    public class CustomerManager : IDataRepository<Customer, int>
    {
        private readonly NwbaContext _context;

        public CustomerManager(NwbaContext context)
        {
            _context = context;
        }
        public int Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();

            return item.CustomerID;
        }

        public int Delete(int id)
        {
            _context.Customers.Remove(_context.Customers.Find(id));
            _context.SaveChanges();

            return id;
        }

        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public int Update(int id, Customer item)
        {
            _context.Update(item);
            _context.SaveChanges();

            return id;
        }

        public int Lock(int id)
        {
            Get(id).Login.Lock();
            _context.SaveChanges();
            return id;
        }
    }
}
