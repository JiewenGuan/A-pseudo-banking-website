using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NwbaExample.Models;
using NwbaExampleWithLogin.Models.DataManager;

namespace NwbaExampleWithLogin.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class AdminController : Controller
    {
        public AccountManager _accountRepo;
        public BillsManager _billRepo;
        public CustomerManager _customerRepo;
        public TransactionManager _transactionRepo;

        public AdminController(AccountManager accountRepo, BillsManager billRepo, CustomerManager customerRepo, TransactionManager transactionRepo)
        {
            _accountRepo = accountRepo;
            _billRepo = billRepo;
            _customerRepo = customerRepo;
            _transactionRepo = transactionRepo;
        }

        public IEnumerable<Transaction> UserTransaction(int id, int sYear = 1, int sMonth = 1, int sDay = 1, int eYear = 9999, int eMonth = 12, int eDay = 31)
        {
            DateTime starttime = new DateTime(sYear, sMonth, sDay), endtime = new DateTime(eYear, eMonth, eDay);

            var customer = _customerRepo.Get(id);
            var transactionlist = new List<Transaction>();
            foreach (Account acc in customer.Accounts)
                transactionlist.AddRange(acc.Transactions);
            transactionlist = transactionlist.Where(x => x.TransactionTimeUtc < endtime).Where(x => x.TransactionTimeUtc > starttime).ToList();
            return StripTransactionList(transactionlist);
        }

        public int LockUser(int id)
        {
            return _customerRepo.Lock(id);
        }
        [HttpDelete("{id}")]
        public int DeleteUser(int id)
        {
            _customerRepo.Delete(id);
            return id;
        }
        [HttpPut]
        public int UpdateUser([FromBody] Customer customer)
        {
            _customerRepo.Update(customer.CustomerID, customer);
            return customer.CustomerID;
        }
        [HttpPost]
        public void AddUser([FromBody] Customer customer)
        {
            _customerRepo.Add(customer);
        }
        [HttpGet]
        public IEnumerable<Customer> GetAllUser()
        {
            var list = _customerRepo.GetAll();
            var ret = new List<Customer>();
            foreach (Customer c in list)
                ret.Add(StripCustomer(c));
            return ret;
        }

        // GET api/movies/1
        [HttpGet]
        public Customer GetUser(int id)
        {
            return StripCustomer( _customerRepo.Get(id));
        }
        [HttpGet]
        public IEnumerable<Bill> AllBills()
        {
            var ret = new List<Bill>();
            foreach (Bill b in _billRepo.GetAll())
                ret.Add(StripBill(b));
            return ret;
        }
        [HttpGet]
        public Bill GetBill(int id)
        {
            return StripBill(_billRepo.Get(id));
        }
        public int BlockBill(int id)
        {
            return _billRepo.Block(id);
        }

        private Bill StripBill(Bill b)
        {
            return new Bill
                {
                    AccountNumber = b.AccountNumber,
                    PayeeID = b.PayeeID,
                    Amount = b.Amount,
                    ScheduleDate = b.ScheduleDate,
                    Period = b.Period,
                    Status = b.Status,
                    ModifyDate = b.ModifyDate
                };
        }

        private Customer StripCustomer(Customer customer)
        {
            return new Customer
            {
                CustomerID = customer.CustomerID,
                Name = customer.Name,
                Tfn = customer.Tfn,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                PostCode = customer.PostCode,
                Phone = customer.Phone
            };
        }

        private List<Transaction> StripTransactionList(List<Transaction> transactionlist)
        {
            var ret = new List<Transaction>();
            foreach (Transaction t in transactionlist)
            {
                ret.Add(new Transaction
                {
                    TransactionID = t.TransactionID,
                    TransactionType = t.TransactionType,
                    AccountNumber = t.AccountNumber,
                    Account = null,
                    DestinationAccountNumber = t.DestinationAccountNumber,
                    DestinationAccount = null,
                    Amount = t.Amount,
                    Comment = t.Comment,
                    TransactionTimeUtc = t.TransactionTimeUtc
                });
            }
            return ret;
        }
    }
}