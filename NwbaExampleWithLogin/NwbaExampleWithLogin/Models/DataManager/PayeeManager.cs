﻿using NwbaExample.Data;
using NwbaExample.Models;
using NwbaExampleWithLogin.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NwbaExampleWithLogin.Models.DataManager
{
    public class PayeeManager : IDataRepository<Payee, int>
    {
        private readonly NwbaContext _context;

        public PayeeManager(NwbaContext context)
        {
            _context = context;
        }
        public int Add(Payee item)
        {
            _context.Payees.Add(item);
            _context.SaveChanges();

            return item.PayeeID;
        }

        public int Delete(int id)
        {
            _context.Customers.Remove(_context.Customers.Find(id));
            _context.SaveChanges();

            return id;
        }

        public Payee Get(int id)
        {
            return _context.Payees.Find(id);
        }

        public IEnumerable<Payee> GetAll()
        {
            return _context.Payees.ToList();
        }

        public Payee GetDto(Payee t)
        {
            return new Payee
            {
                PayeeID = t.PayeeID,
                PayeeName = t.PayeeName,
                Address = t.Address,
                City = t.City,
                State = t.State,
                PostCode = t.PostCode,
                Phone = t.Phone
            };
        }

        public IEnumerable<Payee> GetDto(IEnumerable<Payee> list)
        {
            var ret = new List<Payee>();
            foreach (Payee t in list)
            {
                ret.Add(GetDto(t));
            }
            return ret;
        }

        public int Update(int id, Payee item)
        {
            _context.Update(item);
            _context.SaveChanges();

            return id;
        }
    }
}
