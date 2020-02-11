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

        public int Update(int id, string name, string tfn, string address, string city, string state, string postcode, string phone)
        {
            Get(id).Update(name, tfn, address, city, state, postcode, phone);
            _context.SaveChanges();

            return id;
        }

        public int Lock(int id)
        {
            Get(id).Login.Lock();
            _context.SaveChanges();
            return id;
        }
        public int UnLock(int id)
        {
            Get(id).Login.Unlock();
            _context.SaveChanges();
            return id;
        }

        public Customer GetDto(Customer t)
        {
            return new Customer
            {
                CustomerID = t.CustomerID,
                Name = t.Name,
                Tfn = t.Tfn,
                Address = t.Address,
                City = t.City,
                State = t.State,
                PostCode = t.PostCode,
                Phone = t.Phone
            };
        }

        public IEnumerable<Customer> GetDto(IEnumerable<Customer> list)
        {
            List<Customer> ret = new List<Customer>();
            foreach (Customer c in list)
                ret.Add(GetDto(c));
            return ret;
        }

        public int Update(int id, Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
