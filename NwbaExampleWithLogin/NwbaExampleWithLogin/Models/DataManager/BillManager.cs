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

        internal int UnBlock(int id)
        {
            Get(id).UnBlock();
            _context.SaveChanges();
            return id;
        }

        public Bill GetDto(Bill t)
        {
            return new Bill
            {
                AccountNumber = t.AccountNumber,
                PayeeID = t.PayeeID,
                Amount = t.Amount,
                ScheduleDate = t.ScheduleDate,
                Period = t.Period,
                Status = t.Status,
                ModifyDate = t.ModifyDate
            };
        }

        public IEnumerable<Bill> GetDto(IEnumerable<Bill> list)
        {
            List<Bill> ret = new List<Bill>();
            foreach (Bill b in list)
                ret.Add(GetDto(b));
            return ret;
        }
    }
}
