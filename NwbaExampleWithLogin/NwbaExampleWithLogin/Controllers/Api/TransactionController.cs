using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NwbaExample.Models;
using NwbaExampleWithLogin.Models.DataManager;

namespace NwbaExampleWithLogin.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionManager _TransactionRepo;
        private readonly CustomerManager _customerRepo;

        public TransactionController(TransactionManager transactionRepo, CustomerManager customerRepo)
        {
            _TransactionRepo = transactionRepo;
            _customerRepo = customerRepo;
        }
        [HttpGet]
        public IEnumerable<Transaction> GetAll()
        {
            return _TransactionRepo.GetDto(_TransactionRepo.GetAll());
        }
        [HttpGet("{id}")]
        public IEnumerable<Transaction> GetUserTransaction(int id)
        {
            var ret = new List<Transaction>();
            foreach (Account acc in _customerRepo.Get(id).Accounts)
                ret.AddRange(acc.Transactions);
            return _TransactionRepo.GetDto(ret);
        }
    }
}