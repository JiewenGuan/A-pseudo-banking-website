using NwbaExample.Models;
using NwbaExampleWithLogin.Models.Repository;
using System;
using System.Collections.Generic;
using NwbaExample.Data;
using System.Linq;
using System.Threading.Tasks;
namespace NwbaExampleWithLogin.Models.DataManager
{
    public class LoginManager : IDataRepository<Login, string>
    {
        private readonly NwbaContext _context;

        public LoginManager(NwbaContext context)
        {
            _context = context;
        }
        public string Add(Login item)
        {
            _context.Logins.Add(item);
            _context.SaveChanges();
            return item.LoginID;
        }

        public string Delete(string id)
        {
            _context.Logins.Remove(_context.Logins.Find(id));
            _context.SaveChanges();
            return id;
        }

        public Login Get(string id)
        {
            return _context.Logins.Find(id);
        }

        public IEnumerable<Login> GetAll()
        {
            return _context.Logins.ToList();
        }

        public string Update(string id, Login item)
        {
            _context.Update(item);
            _context.SaveChanges();

            return id;
        }
    }
}
