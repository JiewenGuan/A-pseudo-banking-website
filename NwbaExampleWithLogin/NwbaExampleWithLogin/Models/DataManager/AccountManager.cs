using NwbaExample.Models;
using NwbaExampleWithLogin.Models.Repository;
using System;
using System.Collections.Generic;
using NwbaExample.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NwbaExampleWithLogin.Models.DataManager
{
    public class AccountManager : IDataRepository<Account, int>
    {
        private readonly NwbaContext _context;

        public AccountManager(NwbaContext context)
        {
            _context = context;
        }
        public int Add(Account item)
        {
            _context.Accounts.Add(item);
            _context.SaveChanges();

            return item.AccountNumber;
        }

        public int Delete(int id)
        {
            _context.Accounts.Remove(_context.Accounts.Find(id));
            _context.SaveChanges();

            return id;
        }

        public Account Get(int id)
        {
            return _context.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public Account GetDto(Account t)
        {
            return new Account
            {
                AccountNumber = t.AccountNumber,
                AccountType = t.AccountType,
                CustomerID = t.CustomerID,
                Balance = t.Balance,
                ModifyDate = t.ModifyDate
            };
        }

        public IEnumerable<Account> GetDto(IEnumerable<Account> list)
        {
            var ret = new List<Account>();
            foreach (Account t in list)
            {
                ret.Add(GetDto(t));
            }
            return ret;
        }

        public int Update(int id, Account item)
        {
            _context.Update(item);
            _context.SaveChanges();

            return id;
        }
    }
}
