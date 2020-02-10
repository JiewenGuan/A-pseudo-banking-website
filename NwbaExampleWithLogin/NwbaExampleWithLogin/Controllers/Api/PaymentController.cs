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
    public class PaymentController : ControllerBase
    {
        private readonly BillsManager _billRepo;
        private readonly CustomerManager _customerRepo;

        public PaymentController(BillsManager billRepo, CustomerManager customerRepo)
        {
            _billRepo = billRepo;
            _customerRepo = customerRepo;
        }
        [HttpGet]
        public IEnumerable<Bill> GetAll()
        {
            return _billRepo.GetDto(_billRepo.GetAll());
        }
        [HttpGet("{id}")]
        public IEnumerable<Bill> GetUserBill(int id)
        {
            var ret = new List<Bill>();
            foreach (Account acc in _customerRepo.Get(id).Accounts)
                ret.AddRange(acc.Bills);
            return _billRepo.GetDto(ret);
        }
        [HttpGet("[action]/{id}")]
        public int Block(int id)
        {
            return _billRepo.Block(id);
        }
        [HttpGet("[action]/{id}")]
        public int UnBlock(int id)
        {
            return _billRepo.UnBlock(id);
        }
    }
}